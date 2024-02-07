using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    public Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ball.GetComponent<Rigidbody>().velocity.magnitude > 0f)
        {
            transform.position = ball.position + ball.GetComponent<Rigidbody>().velocity.normalized;
        }
        
    }
}
