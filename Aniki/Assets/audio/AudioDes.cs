using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDes : MonoBehaviour
{
    float Timer;
    AudioSource myAud;


    // Start is called before the first frame update
    void Start()
    {
        myAud = GetComponent<AudioSource>();
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > myAud.clip.length)
        {
            Destroy(this.gameObject);
        }
    }
}
