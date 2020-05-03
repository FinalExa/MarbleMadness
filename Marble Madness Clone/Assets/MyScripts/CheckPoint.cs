using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CheckPoint : MonoBehaviour
{
    Player playerscript;
    public Vector3 currentCheckpointPosition;
    bool firstTime;
    ScoreManager scoremanager;
    // Start is called before the first frame update
    void Start()
    {
        playerscript = FindObjectOfType<Player>();
        scoremanager = FindObjectOfType<ScoreManager>();
        firstTime = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (firstTime == false)
            {
                playerscript.lastCheckpoint = currentCheckpointPosition;
                scoremanager.AddScoreOnCheckPoint();
                firstTime = true;
            }
        }
    }
}