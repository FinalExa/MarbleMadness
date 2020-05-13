using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject[] trapSpikes;
    public int numberOfSpikes;
    public int[] randomizedSpikes;
    public int[] idArray;
    string state;
    bool firstTime;
    float timer;
    public float maxTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
        state = "initialize";
    }

    // Update is called once per frame
    void Update()
    {
        Trap();
    }

    void Trap()
    {
        if (state == "initialize")
        {
            firstTime = true;
            for (int i = 0; i<idArray.Length; i++)
            {
                idArray[i] = i;
                randomizedSpikes[i] = 0;
            }
            numberOfSpikes = Random.Range(1, trapSpikes.Length);
            for (int i = 0; i < numberOfSpikes; i++)
            {
                int temp = Random.Range(0, trapSpikes.Length-i);
                randomizedSpikes[i] = idArray[temp];
                for (int y = temp; y < trapSpikes.Length-i; y++)
                {
                    if (y != trapSpikes.Length - 1 - i)
                    {
                        idArray[y] = idArray[y + 1];
                    }
                }
            }
            state = "move";
        }
        else if (state == "move")
        {
            if (firstTime == true)
            {
                for (int i = 0; i < numberOfSpikes; i++)
                {
                    trapSpikes[randomizedSpikes[i]].SetActive(true);
                }
                firstTime = false;
            }
            if (timer > 0)
            {
                timer -= 1 * Time.deltaTime;
            }
            if (timer <= 0)
            {
                timer = maxTimer;
                state = "initialize";
            }
        }
    }
}