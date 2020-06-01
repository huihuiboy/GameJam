using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playsound : MonoBehaviour
{
    public string clip;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<bgmanager>().Play(clip);
    }

}
