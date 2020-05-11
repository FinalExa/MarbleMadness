using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalReached : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gamemanager;
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gamemanager.gamestate = "win";
        }
    }
}
