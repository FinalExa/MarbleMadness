using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type2EnemyScript : MonoBehaviour
{
    [SerializeField]
    float radius;
    [SerializeField]
    float attractionForce;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Attract();
    }

    void Attract()
    {
        Collider[] playerCollider = Physics.OverlapSphere(this.transform.position, radius);

        foreach (Collider collider in playerCollider)
        {
            if (collider.gameObject.GetComponent<Player>() != null)
            {
                Vector3 direction = player.transform.position - this.transform.position;
                player.gameObject.GetComponent<Rigidbody>().AddForce(attractionForce * -direction);
            }
        }
    }
}
