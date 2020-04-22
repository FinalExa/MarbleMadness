using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    Player playerscript;
    GameObject player;
    public float reactivateY;

    void Start()
    {
        playerscript = FindObjectOfType<Player>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = playerscript.lastCheckpoint;
            playerscript.rb.velocity = Vector3.zero;
            playerscript.rb.angularVelocity = Vector3.zero;
        }
    }
}