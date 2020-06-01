using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Speed = 500;
    private Rigidbody2D r2d;
    public GameObject Instantiate_Position;
    public GameObject N;
    public float coolingTime = 2.0f;
    private float currenTime = 0.0f;
    public GameObject Aniki;
    public GameObject buiiet;
    public GameObject killrange;
    attackrange atk;
    InGame ig;
    public bool outAmmo = false;
    shoot shoo;
    Animator My_aniT;

    // Start is called before the first frame update
    void Start()
    {
        My_aniT = GetComponent<Animator>();
        ig = GameObject.Find("inGameManager").GetComponent<InGame>();
        atk = killrange.GetComponent<attackrange>();
        r2d = GetComponent<Rigidbody2D>();
        currenTime = coolingTime;
    }

    // Update is called once per frame
    void Update()
    {
        shoo = GameObject.Find("shoot").GetComponent<shoot>();
        outAmmo = shoo.outAm;
        if (Input.GetKey(KeyCode.W))
        {
            r2d.AddForce(Vector2.up * Speed * Time.deltaTime);
            My_aniT.SetTrigger("up");
        }
        if (Input.GetKey(KeyCode.S))
        {
            r2d.AddForce(Vector2.down * Speed * Time.deltaTime);
            My_aniT.SetTrigger("down");
        }
        if (Input.GetKey(KeyCode.D))
        {
            r2d.AddForce(Vector2.right * Speed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 0, this.transform.rotation.z);
            My_aniT.SetTrigger("right");
        }
        if (Input.GetKey(KeyCode.A))
        {
            r2d.AddForce(Vector2.left * Speed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 180, this.transform.rotation.z);
            My_aniT.SetTrigger("right");
        }

        if (Input.GetKeyUp(KeyCode.W)) My_aniT.ResetTrigger("up");
        if (Input.GetKeyUp(KeyCode.S)) My_aniT.ResetTrigger("down");
        if (Input.GetKeyUp(KeyCode.D)) My_aniT.ResetTrigger("right");
        if (Input.GetKeyUp(KeyCode.A)) My_aniT.ResetTrigger("right");

        if (this.transform.position.x <= -8.57f) this.transform.position = new Vector3(-8.57f, this.transform.position.y);
        if (this.transform.position.x >= 8.61f) this.transform.position = new Vector3(8.61f, this.transform.position.y);
        if (this.transform.position.y <= -5.15f) this.transform.position = new Vector3(this.transform.position.x, -5.15f);
        if (this.transform.position.y >= 1.61f) this.transform.position = new Vector3(this.transform.position.x, 1.61f);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(N, Instantiate_Position.transform.position, Instantiate_Position.transform.rotation);
            FindObjectOfType<bgmanager>().Play("小弟砍");
            atk.kill = true;
        }

        if (currenTime < coolingTime)
        {
            currenTime += Time.deltaTime;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.tag == "GG")
        //{
        //    Debug.Log("132");
        //    if (Input.GetKeyDown(KeyCode.Q))
        //    {
        //        Destroy(collision.gameObject);
        //    }
        //}
        if (collision.tag == "Kill")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Aniki.SetActive(true);
                buiiet.SetActive(false);
                ig.Score[0] += 5;
                ig.playerwin = true;
            }
        }
        //if (collision.tag == "AI")
        //{
        //    if (Input.GetKeyDown(KeyCode.Q))
        //    {
        //        Destroy(collision.gameObject);
        //    }
        //}
    }
    public void JoeMaMa()
    {
        ig.gotkilled += 1;
        My_aniT.SetTrigger("die");
        FindObjectOfType<bgmanager>().Play("小弟死亡");
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(this);
    }

    private void OnMouseDown()
    {
        if (outAmmo == false && Input.GetMouseButtonDown(0))
        {
            My_aniT.SetTrigger("die");
            FindObjectOfType<bgmanager>().Play("小弟死亡");
            GetComponent<BoxCollider2D>().enabled = false;
            ig.gotkilled += 1;      
            ig.bossscore += 3;
            Destroy(this);
        }
    }
}
