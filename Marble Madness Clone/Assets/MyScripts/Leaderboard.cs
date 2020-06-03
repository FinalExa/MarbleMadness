using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text leaderboard_text;
    public string[] leaderboard;
    public string[] leaderboard_names;
    public int[] leaderboard_score;
    public int score;
    public string playername;
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        leaderboard_text.text = "Leaderboard:\n";
        UpdateAndShowLeaderboard();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ReturnToMainMenu();
        }
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void UpdateAndShowLeaderboard()
    {
        int tempscore;
        string tempname;
        score = GameManager.finalScore;
        playername = NameSelect.PlayerName;
        for (int i = 0; i < 10; i++)
        {
            if (score >= leaderboard_score[i])
            {
                tempscore = leaderboard_score[i];
                tempname = leaderboard_names[i];
                leaderboard_score[i] = score;
                leaderboard_names[i] = playername;
                score = tempscore;
                playername = tempname;
            }
            leaderboard[i] = (i+1) + ". " + leaderboard_names[i] + " " + leaderboard_score[i];
            leaderboard_text.text += leaderboard[i] + "\n";
        }
        SaveData();
    }

    void SaveData()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt("scores" + i, leaderboard_score[i]);
            PlayerPrefs.SetString("names" + i, leaderboard_names[i]);
        }
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.GetInt("scores" + i) != 0)
            {
                leaderboard_score[i] = PlayerPrefs.GetInt("scores" + i);
                leaderboard_names[i] = PlayerPrefs.GetString("names" + i);
            }
        }
    }
}