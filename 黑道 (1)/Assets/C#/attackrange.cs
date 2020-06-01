using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackrange : MonoBehaviour
{
    public bool kill = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(kill == true && collision.tag == "AI")
        {
            collision.SendMessage("JoeMaMa");
            kill = false;
        }

        if (kill == true && collision.tag == "GG")
        {
            collision.SendMessage("JoeMaMa");
            kill = false;
        }
    }
}
