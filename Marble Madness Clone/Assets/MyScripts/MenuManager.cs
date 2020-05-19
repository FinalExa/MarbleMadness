using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text text_press_start;
    public float maxTimer;
    [SerializeField]
    private float timer;
    [SerializeField]
    private bool status;
    static public int timesPlayed;
    

    // Start is called before the first frame update
    void Start()
    {
        timesPlayed = 0;
        status = true;
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
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
    void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
