using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffTrap : MonoBehaviour
{
    public float startingDelay;
    float timer;
    bool initialize;
    bool onoffstate;
    public float maxTimer;
    public GameObject internalElement;
    // Start is called before the first frame update
    void Start()
    {
        timer = startingDelay;
        initialize = true;
        onoffstate = true;
    }

    // Update is called once per frame
    void Update()
    {
        OnOffSwitch();
    }

    void OnOffSwitch()
    {
        if (initialize == true)
        {
            if (timer > 0)
            {
                timer -= 1 * Time.deltaTime;
            }
            else if (timer < 0)
            {
                timer = 0;
            }
            else
            {
                initialize = false;
                timer = maxTimer;
            }
        }
        else
        {
            if (timer > 0)
            {
                timer -= 1 * Time.deltaTime;
            }
            else if (timer < 0)
            {
                timer = 0;
            }
            else
            {
                onoffstate = !onoffstate;
                internalElement.SetActive(onoffstate);
                timer = maxTimer;
            }
        }
    }
}
