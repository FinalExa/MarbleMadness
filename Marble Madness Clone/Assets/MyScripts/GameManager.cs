using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public float scoreTimer;
    public float scoreTimerMax;
    public string gamestate;
    // Start is called before the first frame update
    void Start()
    {
        scoreTimer = scoreTimerMax;
        gamestate = "normal";
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseTimer();
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
}
