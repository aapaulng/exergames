using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour {
    float timeRemaining = 10;
    float timeExtension = 3f;
    float timeDeduction = 2f;
    float totalTimeElapsed = 0;
    float score = 0f;
    public bool isGameOver = false;
    public PauseMenuScript UI_PauseMenu;

    public Text UI_TimeLeft;
    public Text UI_Score;
    public Text UI_ScoreInGameOver;
    public Text UI_TimeRemainingInGameOver;
    public Text UI_TotalScoreInGameOver;
    public MenuManager UI_MenuManager;
    public Menu UI_MainMenu;
    public Menu UI_GameOver;
    public GameObject PlayerNCamera;
    public GameObject ResetTimeScaleA;
    public GameObject ResetTimeScaleB;
    public GameObject BossJumpWall;
    public GameObject BossRound;

    private CountDownScript countDownScript;
    private int BossJumpWallCount = 0;
    int tmpTime =0 ;
    int tmpScore = 0;


    public void Awake()
    {
        Time.timeScale = 1f;
        gameObject.GetComponent<CountDownScript>().enabled = true;
        ChangeToStart();
    }

    public void PowerUpCollected() {
        timeRemaining += timeExtension;
    }

    public void AlcoholCollected() {
        timeRemaining -= timeDeduction;
    }

    public void JumpWallCollected()
    {
        isGameOver = true;
    }


	// Update is called once per frame
	void Update () {

        if (isGameOver){
            Time.timeScale = 0;
            UI_MenuManager.ShowMenu(UI_GameOver);
            UI_ScoreInGameOver.text = ""+tmpScore;
            UI_TimeRemainingInGameOver.text = "Time x 200 : " + (tmpTime *200);
           // UI_TotalScoreInGameOver.text = "Total           : " + ( ((int)(Mathf.FloorToInt(score)) + ((int)(Mathf.FloorToInt(timeRemaining))*200) ));
            UI_TotalScoreInGameOver.text = "Total           : " + (tmpScore + tmpTime*200);
            return;
        }
        else
        {
            tmpTime = Mathf.FloorToInt(timeRemaining);
            tmpScore = Mathf.FloorToInt(score);
            
            UI_Score.text = "Score : "+tmpScore;
            UI_TimeLeft.text = "Time Remain : "+tmpTime;
        }

        totalTimeElapsed += Time.deltaTime;
        score = totalTimeElapsed * 100;
        timeRemaining -= Time.deltaTime;
        UI_PauseMenu.PauseMenu();
        

        if (timeRemaining <= 0) {
            isGameOver = true;
            timeRemaining = 0;
        }


       
        if (score >= 1500 && score <= 1550)
        {
            ChangeToBoss();
        }

        else if (score > 3000)
        {
            isGameOver = true;
        }

	}

    public void StartGame()
    {
        Debug.Log("StartGame");
        Time.timeScale = 1f;
        
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }

    public void Restart()
    {
        Debug.Log("RestartGame");
        DestroyImmediate(Camera.main.gameObject);
        //DeleteAll();
        Application.LoadLevel(Application.loadedLevel);
        
    }

    public void MainMenu()
    {
        DestroyImmediate(Camera.main.gameObject);
        Application.LoadLevel("MainMenuScene");
    }

    public void DeleteAll()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Destroy(o);
        }
    }

    public void SlowMotion()
    {
        Debug.Log("SlowMotion Start");
        Time.timeScale = 0.2f;
    }

    public void NormalMotion()
    {
        Debug.Log("Normal Speed");
        Time.timeScale = 1f;
    }

    public void ChangeToBoss()
    {
        BossRound.SetActive(true);
        Time.timeScale = 0.2f;
        PlayerNCamera.transform.position = new Vector3(80,0,0);
        Instantiate(ResetTimeScaleB);
        if (BossJumpWallCount == 0)
        {
            Instantiate(BossJumpWall);
            BossJumpWallCount = 1;
        }
    }

    public void ChangeToNormal()
    {
        BossRound.SetActive(false);
        Time.timeScale = 0.2f;
        PlayerNCamera.transform.position = new Vector3(0, 0, 0);
        Instantiate(ResetTimeScaleA);
        BossJumpWallCount = 0;
    }

    public void ChangeToStart()
    {
        BossRound.SetActive(false);
        PlayerNCamera.transform.position = new Vector3(0, 0, 0);
       // Instantiate(ResetTimeScaleA);
    }

}
