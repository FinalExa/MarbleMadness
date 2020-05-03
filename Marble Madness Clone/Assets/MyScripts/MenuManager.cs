using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public float maxTimer;
    public float timer;
    public Text text_press_start;
    private bool status;

    // Start is called before the first frame update
    void Start()
    {
        status = true;
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timerMoving();
    }

    void timerMoving()
    {
        if (timer>0)
        {
            timer -= 1 * Time.deltaTime;
        }
        else if (timer < 0)
        {
            timer = 0;
        }
        else
        {
            status = !status;
            text_press_start.enabled = status;
            timer = maxTimer;
        }
    }
}
