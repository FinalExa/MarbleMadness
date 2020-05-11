using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text_score;
    public Text text_name;
    public GameObject pauseUI;
    bool pause = false;
    ScoreManager scoremanager;
    // Start is called before the first frame update
    void Start()
    {
        scoremanager = FindObjectOfType<ScoreManager>();
        PlayerNameShow();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
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
    }

    void UpdateScoreText()
    {
        text_score.text = "Score:\n" + scoremanager.score.ToString();
    }

    void PlayerNameShow()
    {
        text_name.text = NameSelect.PlayerName;
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
}
