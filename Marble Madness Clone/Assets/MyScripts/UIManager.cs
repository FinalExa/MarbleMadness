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
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
        UpdateTimer();
    }

    void UpdateScoreText()
    {
        text_score.text = "Score:\n" + gamemanager.score.ToString();
    }

    

    void UpdateTimer()
    {
        int intScore = (int)gamemanager.scoreTimer;
        text_timer.text = intScore.ToString();
    }

}
