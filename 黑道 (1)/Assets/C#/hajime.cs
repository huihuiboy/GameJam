using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hajime : MonoBehaviour
{
    public GameObject gogo,druman;
    Animator anim;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        anim = druman.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3.5 && timer <=5.5)
        {
            gogo.SetActive(true);
            anim.SetBool("drum",true);
        }
        else if(timer >= 5.5)
        {
            gogo.SetActive(false);
            anim.SetBool("drum", false);
        }
    }
}
