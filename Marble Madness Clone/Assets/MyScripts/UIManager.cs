using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text_score;
    public Text text_timer;
    public GameObject pauseUI;
    public GameObject lostGameUI;
    public GameObject wonGameUI;
    bool pause = false;
    ScoreManager scoremanager;
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        scoremanager = FindObjectOfType<ScoreManager>();
        gamemanager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
        UpdateTimer();
        MenuHandler();
    }

    void UpdateScoreText()
    {
        text_score.text = "Score:\n" + scoremanager.score.ToString();
    }

    void MenuHandler()
    {
        if (Input.GetKeyDown(KeyCode.Return) && gamemanager.gamestate == "normal")
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
        else if (gamemanager.gamestate == "lost")
        {
            lostGameUI.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                goToLeaderboard();
            }
        }
        else if (gamemanager.gamestate == "win")
        {
            wonGameUI.SetActive(true);
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
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void PauseExit()
    {
        pause = !pause;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void goToLeaderboard()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }

    void UpdateTimer()
    {
        int intScore = (int)gamemanager.scoreTimer;
        text_timer.text = intScore.ToString();
    }

    void reloadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
}
