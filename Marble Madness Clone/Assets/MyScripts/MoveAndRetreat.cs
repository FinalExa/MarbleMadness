using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRetreat : MonoBehaviour
{
    string state;
    public float speed1, speed2;
    public float value1, value2;
    public float yPosition,xPosition,zPosition;
    // Start is called before the first frame update
    void Start()
    {
        value1 = this.transform.localPosition.y + 1;
        value2 = this.transform.localPosition.y - 1;
        yPosition = this.transform.position.y;
        xPosition = this.transform.position.x;
        zPosition = this.transform.position.z;
        state = "exit";
    }

    // Update is called once per frame
    void Update()
    {
        Action();
    }

    void Action()
    {
        if (state == "exit")
        {
            if (this.transform.localPosition.y‬ < value1)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed1);
            }
            else
            {
                state = "enter";
            }
        }
        else if (state == "enter")
        {
            if (this.transform.localPosition.y > value2)
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed2);
            }
            else
            {
                state = "exit";
                this.transform.position = new Vector3(xPosition,yPosition,zPosition);
                gameObject.SetActive(false);
            }
        }
    }
}