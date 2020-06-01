using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    Rigidbody2D rd;
    Animator My_aniT;
    int state = 5;
    int upordown;
    float walkdis, timer, resttimer, startcount, rand, ramd, firstrand, firstime;
    cursor my_cursor;
    bool ishit = false;
    bool outAmmo = false;
    shoot shoo;

    // Start is called before the first frame update
    void Start()
    {
        shoo = GameObject.Find("shoot").GetComponent<shoot>();
        my_cursor = GameObject.Find("Cursor").GetComponent<cursor>();
        My_aniT = GetComponent<Animator>();
        rd = GetComponent<Rigidbody2D>();
        firstrand = Random.Range(0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        rd.AddForce(Vector2.down * 5 * Time.deltaTime);
        outAmmo = shoo.outAm;
        switch (state)
        {
            case 1:
                upordown = Random.Range(0, 4);
                rand = Random.Range(2f, 5f);
                ramd = Random.Range(2f, 5f);
                resttimer = 0;
                state++;
                break;
            case 2:               
                if (upordown == 0)
                {
                    
                    rd.AddForce(Vector2.up * 300 * Time.deltaTime);
                    My_aniT.SetTrigger("WalkUp");
                }
                if (upordown == 1)
                {
                    rd.AddForce(Vector2.down * 300 * Time.deltaTime);
                    My_aniT.SetTrigger("WalkDown");
                }                    
                if (upordown == 2)
                {
                    rd.AddForce(Vector2.left * 300 * Time.deltaTime);
                    this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 180, this.transform.rotation.z);
                    My_aniT.SetTrigger("WalkL");
                }
                if (upordown == 3)
                {
                    rd.AddForce(Vector2.right * 300 * Time.deltaTime);
                    this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 0, this.transform.rotation.z);
                    My_aniT.SetTrigger("WalkR");
                } 
                timer += Time.deltaTime;
                if (timer >= rand) state++;
                break;
            case 3:
                timer = 0;
                switch (upordown)
                {
                    case 0:
                        My_aniT.ResetTrigger("WalkUp");
                        break;
                    case 1:
                        My_aniT.ResetTrigger("WalkDown");
                        break;
                    case 2:
                        My_aniT.ResetTrigger("WalkL");
                        break;
                    case 3:
                        My_aniT.ResetTrigger("WalkR");
                        break;
                }
                state++;
                break;
            case 4:
                resttimer += Time.deltaTime;
                if (resttimer >= ramd) state = 1;
                break;
            case 5:
                startcount += Time.deltaTime;
                if (startcount >= 5) state = 6;
                break;
            case 6:                
                firstime += Time.deltaTime;
                if (firstime >= firstrand) state = 1;
                break;
            default:
                break;
        }
        if (this.transform.position.x <= -8.57f) this.transform.position = new Vector3(-8.57f,this.transform.position.y);
        if (this.transform.position.x >= 8.61f) this.transform.position = new Vector3(8.61f, this.transform.position.y);
        if (this.transform.position.y <= -5.15f) this.transform.position = new Vector3(this.transform.position.x, -5.15f);
        if (this.transform.position.y >= 0.88f) this.transform.position = new Vector3(this.transform.position.x, 0.88f);
    }

    //private void OnMouseEnter()
    //{
    //    my_cursor.SetAttackCursor();
    //}

    //private void OnMouseExit()
    //{
    //    my_cursor.SetMoveCursor();
    //}

    private void OnMouseDown()
    {
        if (outAmmo == false && Input.GetMouseButtonDown(0))
        {
            My_aniT.SetTrigger("die");
            FindObjectOfType<bgmanager>().Play("小弟死亡");
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(this);
        }

        //Debug.Log("yomamadie");
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, -1); ;
        //        if (hit.collider)
        //        {
        //            Destroy(gameObject);
        //        }
        //    }
        //} 
    }

    public void JoeMaMa()
    {
        My_aniT.SetTrigger("die");
        FindObjectOfType<bgmanager>().Play("小弟死亡");
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(this);
    }
}
