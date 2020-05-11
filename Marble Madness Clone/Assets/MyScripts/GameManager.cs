using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float scoreTimer;
    public float scoreTimerMax;
    public string gamestate;
    public int score;
    public int checkpointScore;
    bool pause = false;
    static public int finalScore;
    UIManager uimanager;

    // Start is called before the first frame update
    void Start()
    {
        uimanager = FindObjectOfType<UIManager>();
        scoreTimer = scoreTimerMax;
        gamestate = "normal";
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseTimer();
        GameStateHandler();
    }

    void DecreaseTimer()
    {
        if (scoreTimer > 1)
        {
            scoreTimer -= 1 * Time.deltaTime;
        }
        else if (scoreTimer < 1)
        {
            scoreTimer = 0;
            gamestate = "lost";
        }
    }

    public void AddScoreOnCheckPoint()
    {
        score += checkpointScore;
    }

    void GameStateHandler()
    {
        if (Input.GetKeyDown(KeyCode.Return) && gamestate == "normal")
        {
            if (pause == false)
            {
                PauseEnter();
            }
            else
            {
                PauseExit();
            }
        }
        else if (gamestate == "lost")
        {
            uimanager.lostGameUI.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                goToLeaderboard();
            }
        }
        else if (gamestate == "win")
        {
            uimanager.wonGameUI.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                reloadLevel();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                goToLeaderboard();
            }
        }
    }

    void PauseEnter()
    {
        pause = !pause;
        uimanager.pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void PauseExit()
    {
        pause = !pause;
        uimanager.pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void goToLeaderboard()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }

    void reloadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
}