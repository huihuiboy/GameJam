using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    static Manager Instance;

    public int[] PlayerScore;
    public int Round;
    public int Stuse;
    public bool R1Win = false, R2Win = false, R3Win = false;
    public bool Over = false;
    public float Timer;
    public bool TwoPlayer = false, ThreePlayer = false;

    public int BossPlayer;
    public int PlayerNumber;

    //public GameObject[] Player;
    //public GameObject[] Player_Image;
    //public GameObject[] Control;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            Debug.Log("刪除場景" + sceneName + "的" + name);
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (Stuse)
        {
            case -1:
                for (int i = 0; i < PlayerScore.Length; i++)
                {
                    PlayerScore[i] = 0;
                }
                Over = false;
                PlayerNumber = 0;
                Round = 0;
                Stuse = 0;
                break;
            case 0: // UI
                if(PlayerNumber !=  0)
                {
                    Round = PlayerNumber;
                    AddRoundNumber();
                }

                break;
            case 1:
                
                if(Over == true)
                {
                    PlayerScore[0] += GameObject.Find("inGameManager").GetComponent<InGame>().Score[0];
                    PlayerScore[1] += GameObject.Find("inGameManager").GetComponent<InGame>().Score[1];
                    PlayerScore[2] += GameObject.Find("inGameManager").GetComponent<InGame>().Score[2];
                    Round -= 1;
                    if (Round != 0 )
                    {
                        Over = false;
                        SceneManager.LoadScene(1);
                    }
                    else
                    {
                        SceneManager.LoadScene(0);
                        Debug.Log("P1 = " + PlayerScore[0] + " P2 = " + PlayerScore[1] + "P3 = " + PlayerScore[2]);
                        Stuse = -1;
                    }
                }


                break;
            case 2:
                
                break;
            case 3:

                break;
            case 4:
                break;
            case 5:
                break;

        }
    }

    public void AddRoundNumber()
    {
        Stuse += 1;
        SceneManager.LoadScene(1);
    }

    public void RectRoundNumber()
    {
        Stuse = -1;
    }

}

