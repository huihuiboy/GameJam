using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public GameObject ButtonAud;
    public GameObject R, L;
    public void TwoPlayer()
    {
        Instantiate(ButtonAud).SetActive(true);
        GameObject.Find("Manager").GetComponent<Manager>().PlayerNumber = 2;
    }

    public void ThreePlayer()
    {
        Instantiate(ButtonAud).SetActive(true);
        GameObject.Find("Manager").GetComponent<Manager>().PlayerNumber = 3;
    }

    public void RRR()
    {
        Instantiate(ButtonAud).SetActive(true);
        R.SetActive(true);
    }

    public void LLL()
    {
        Instantiate(ButtonAud).SetActive(true);
        L.SetActive(true);
    }

    public void Back()
    {
        Instantiate(ButtonAud).SetActive(true);
        if (R.activeInHierarchy == true)
        {
            R.SetActive(false);
        
        }else if (L.activeInHierarchy == true)
        {
            L.SetActive(false);
        }
    }

}
