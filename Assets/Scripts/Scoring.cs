using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int leftScore, rightScore;
    public GameObject middlePaddle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Left Score") || other.gameObject.CompareTag("Right Score"))
        {
            middlePaddle.SetActive(false);
            BallBouncing.volleys = 0;

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0f, 0f, 0f);

            if (other.gameObject.CompareTag("Left Score"))
            {
                leftScore++;
                Debug.Log($"Left Scored! Now has {leftScore} point(s)");
                rb.AddForce(Vector3.right * BallBouncing.startSpeed, ForceMode.VelocityChange);
            }
            else
            {
                rightScore++;
                Debug.Log($"Right Scored! Now has {rightScore} point(s)");
                rb.AddForce(Vector3.left * BallBouncing.startSpeed, ForceMode.VelocityChange);
            }

            transform.position = new Vector3(0f, 0f, 0f);
        }
        
    }
}
