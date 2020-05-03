using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text_score;
    ScoreManager scoremanager;
    // Start is called before the first frame update
    void Start()
    {
        scoremanager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        text_score.text = "Score:\n" + scoremanager.score.ToString();
    }
}
