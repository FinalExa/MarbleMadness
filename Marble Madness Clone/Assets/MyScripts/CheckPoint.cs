using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Player playerscript;
    public Vector3 currentCheckpointPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerscript = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerscript.lastCheckpoint = currentCheckpointPosition;
        }
    }
}