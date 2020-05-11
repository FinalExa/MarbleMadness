using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timer;
    public float timerMax;
    public string gamestate;
    public int score;
    public int checkpointScore;
    public int timeBonusMultiplier;
    bool pause = false;
    static public int finalScore;
    UIManager uimanager;

    // Start is called before the first frame update
    void Start()
    {
        uimanager = FindObjectOfType<UIManager>();
        timer = timerMax;
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
        if (timer > 1)
        {
            timer -= 1 * Time.deltaTime;
        }
        else if (timer < 1)
        {
            timer = 0;
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
            Loss();
        }
        else if (gamestate == "win")
        {
            Victory();
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

    void Loss()
    {
        uimanager.lostGameUI.SetActive(true);
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            goToLeaderboard();
        }
    }

    void Victory()
    {
        int FS = score + timeBonusMultiplier * (int)timer;
        finalScore = FS;
        uimanager.victory_text.text = "YOU WIN\nFINAL SCORE => " + FS + "\nPRESS START TO CONTINUE\nPRESS ESC TO GO TO\nTHE LEADERBOARD";
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