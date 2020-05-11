﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalReached : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gamemanager;
    void Start()
    {

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
