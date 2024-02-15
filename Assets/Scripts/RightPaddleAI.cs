using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddleAI : MonoBehaviour
{
    public Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.position.z > transform.position.z + 0.5f)
        {
            GetComponent<Rigidbody>().AddForce(0.75f * Vector3.forward * PaddlesMove.speed * Time.deltaTime, ForceMode.Impulse);
        }

        if (ball.position.z < transform.position.z - 0.5f)
        {
            GetComponent<Rigidbody>().AddForce(-0.75f * Vector3.forward * PaddlesMove.speed * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
