using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    public GameObject go, si, curtain,presscontinue,pressconwhite,bgm;
    float startimer;
    int state;
    [Header("玩家")]
    public GameObject[] player;
    int win,howmany,whoisboss,round,roundcav;
    public bool bosswin, timeup;
    public bool playerwin;
    public int bossscore,gotkilled,startcav;
    float timer,bosscavtime;
    Manager man;
    [Header("棺材區")]
    public GameObject lilbroDead, bigbroDead, niggers;
    public GameObject[] playeround;

    // 有改須告知
    public int[] Score; // [0] = P1 [1] = P2 [2]=P3
    public bool GameOver = false; // 這回合結束的bool 獲勝條件寫這裡 告訴我結束了即可


    private void Awake()
    {
        man = GameObject.Find("Manager").GetComponent<Manager>();
        howmany = man.PlayerNumber;
        round = man.Round;

        if (howmany == 3)
        {
            if (round == 3) whoisboss = 3;
            if (round == 2) whoisboss = 1;
            if (round == 1) whoisboss = 2;

            if (whoisboss == 1) player[0].SetActive(false);
            if (whoisboss == 2) player[1].SetActive(false);
            if (whoisboss == 3) player[2].SetActive(false);
        }

        if (howmany == 2)
        {
            if (round == 2) whoisboss = 3;
            if (round == 1) whoisboss = 1;

            if (whoisboss == 1)
            {
                player[0].SetActive(false);
                player[1].SetActive(false);
            }
            if (whoisboss == 3)
            {
                player[1].SetActive(false);
                player[2].SetActive(false);
            } 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerwin == true || bosswin == true)
        {
            bgm.SetActive(false);
        }

        //123開始前的圖
        timer += Time.deltaTime;
        if (howmany == 3)
        {
            switch (roundcav)
            {
                default:
                    roundcav = round;
                    break;
                case 1:
                    pressconwhite.SetActive(true);
                    playeround[2].SetActive(true);
                    roundcav = 4;
                    break;
                case 2:
                    pressconwhite.SetActive(true);
                    playeround[1].SetActive(true);
                    roundcav = 4;
                    break;
                case 3:
                    pressconwhite.SetActive(true);
                    playeround[0].SetActive(true);
                    roundcav = 4;
                    break;
                case 4:
                    break;
            }
            if (gotkilled >= 2) bosswin = true;
        }
        if (howmany == 2)
        {
            switch (roundcav)
            {
                default:
                    roundcav = round;
                    break;
                case 1:
                    pressconwhite.SetActive(true);
                    playeround[4].SetActive(true);
                    roundcav = 3;
                    break;
                case 2:
                    pressconwhite.SetActive(true);
                    playeround[3].SetActive(true);
                    roundcav = 3;
                    break;
                case 3:
                    break;

            }
            if (gotkilled >= 1) bosswin = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 1)
        {
            foreach (GameObject x in playeround)
            {
                x.SetActive(false);
            }
            if (Input.anyKeyDown) Time.timeScale = 1;
            pressconwhite.SetActive(false);
        }

        if (playerwin== true)
        {
            Invoke("bossnigger", 2);
            if (Input.GetKeyDown(KeyCode.Space)) EndGame();
        }

        if(bosswin == true)
        {
            lilbroDead.SetActive(true);
            niggers.SetActive(true);
            presscontinue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space)) EndGame();
        }
       
        if(timer >= 180f)
        {
            Invoke("TimeupEnd", 2);
            curtain.SetActive(true);
            presscontinue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space)) EndGame();
        }

        if(howmany == 3)
        {
            switch (round)
            {
                default:
                    break;
                case 1:
                    Score[0] = bossscore;
                    break;
                case 2:
                    Score[1] = bossscore;
                    break;
                case 3:
                    Score[2] = bossscore;
                    break;
            }
        }
        if (howmany == 2)
        {
            switch (round)
            {
                default:
                    break;
                case 1:
                    Score[0] = bossscore;
                    break;
                case 2:
                    Score[2] = bossscore;
                    break;
            }
        }
    }

    void bossnigger()
    {
        bigbroDead.SetActive(true);
        niggers.SetActive(true);
        si.SetActive(false);
        presscontinue.SetActive(true);
    }

    void EndGame()
    {
        GameOver = true;
        man.Over = GameOver;
    }

    void TimeupEnd()
    {
        bossscore += 5;
    }
}
