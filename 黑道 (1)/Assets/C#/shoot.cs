using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject[] bull;
    int count = 0;
    public bool outAm = false;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GameObject.Find("保鑣").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            if(outAm == false)
            {
                ani.SetTrigger("shoot");
                FindObjectOfType<bgmanager>().Play("開槍");
            }
                
        } 
        switch (count)
        {
            default:
                break;
            case 1:
                bull[0].SetActive(false);
                break;
            case 2:
                bull[1].SetActive(false);
                break;
            case 3:
                bull[2].SetActive(false);
                break;
            case 4:
                bull[3].SetActive(false);
                break;
            case 5:
                bull[4].SetActive(false);
                break;
        }
        if (count >= 5) outAm = true;
    }
}
