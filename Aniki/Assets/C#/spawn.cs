using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    GameObject[] player;
    GameObject[] spawnpoint;
    int pick;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("GG");
        spawnpoint = GameObject.FindGameObjectsWithTag("AI");
        for (int i = 0; i < player.Length; i++)
        {
            pick = Random.Range(0, spawnpoint.Length);
            player[i].transform.position = spawnpoint[pick].transform.position;
            spawnpoint[pick].SetActive(false);
        }
        Debug.Log(pick);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) test();
    }

    void test()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i);
        }
    }
}
