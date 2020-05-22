using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTriggers : MonoBehaviour
{
    Player playerscript;
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
            if (playerscript.state != "airborne" && playerscript.timer < playerscript.DeathByFallingDown)
            {
                PointTriggerEffect();
            }
        }
    }

    void PointTriggerEffect()
    {
        gamemanager.AddScoreOnCheckPoint();
        this.gameObject.SetActive(false);
    }
}
