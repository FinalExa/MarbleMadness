using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public float timer;
    public float timerMax;
    public float timerMaxAfterFirstPlay;
    public string gamestate;
    public int score;
    public int checkpointScore;
    public int timeBonusMultiplier;
    bool pause = false;
    static public int finalScore;
    static public int secondsLeft;
    UIManager uimanager;

    // Start is called before the first frame update
    void Start()
    {
        if (MenuManager.timesPlayed == 0)
        {
            timer = timerMax;
            score = 0;
        }
        else
        {
            timer = timerMaxAfterFirstPlay + secondsLeft;
            score = finalScore;
        }
        uimanager = FindObjectOfType<UIManager>();
        gamestate = "normal";

        AudioManager.Instance.PlaySound("MainTrack");
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseTimer();
        GameStateHandler();
    }

    void DecreaseTimer()
    {
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
        else if (timer < 0)
        {
            timer = -1;
            gamestate = "lost";
        }
    }

    public void AddScoreOnCheckPoint()
    {
        score += checkpointScore;
    }

    void GameStateHandler()
    {
        if (gamestate == "normal")
        {
            if (Input.GetKeyDown(KeyCode.Return))
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
            else if (Input.GetKeyDown(KeyCode.Escape) && pause == true)
            {
                BackToMainMenu();
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

    void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void GoToLeaderboard()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }

    void ReloadLevel()
    {
        MenuManager.timesPlayed++;
        secondsLeft = (int)timer;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    void Loss()
    {
        AudioManager.Instance.StopSound("MainTrack");
        int FS = score;
        finalScore = FS;
        uimanager.loss_text.text = "YOU LOSE\nFINAL SCORE => " + FS + "\nPRESS START TO CONTINUE";
        uimanager.lostGameUI.SetActive(true);
        uimanager.text_timer.text = "0";
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GoToLeaderboard();
        }
    }

    void Victory()
    {
        AudioManager.Instance.StopSound("MainTrack");
        int FS = score + timeBonusMultiplier * (int)timer;
        finalScore = FS;
        uimanager.victory_text.text = "YOU WIN\nFINAL SCORE => " + FS + "\nPRESS START TO CONTINUE\nPRESS ESC TO GO TO\nTHE LEADERBOARD";
        uimanager.wonGameUI.SetActive(true);
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ReloadLevel();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            finalScore = 0;
            GoToLeaderboard();
        }
    }
}