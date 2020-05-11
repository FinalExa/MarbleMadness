using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CheckPoint : MonoBehaviour
{
    Player playerscript;
    public Vector3 currentCheckpointPosition;
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        playerscript = FindObjectOfType<Player>();
        gamemanager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerscript.lastCheckpoint = currentCheckpointPosition;
            gamemanager.AddScoreOnCheckPoint();
            this.gameObject.SetActive(false);
        }
    }
}