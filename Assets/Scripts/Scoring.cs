using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public int leftScore, rightScore;
    public GameObject middlePaddle;
    public TextMeshProUGUI leftDisplay, rightDisplay;
    public AudioSource scoreSound;

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

            scoreSound.Play();

            if (other.gameObject.CompareTag("Left Score"))
            {
                leftScore++;
                Debug.Log($"Left Scored! Now has {leftScore} point(s)");
                transform.position = new Vector3(-10f, 0f, 0f);
                rb.AddForce(Vector3.right * BallBouncing.startSpeed, ForceMode.VelocityChange);
            }
            else
            {
                rightScore++;
                Debug.Log($"Right Scored! Now has {rightScore} point(s)");
                transform.position = new Vector3(10f, 0f, 0f);
                rb.AddForce(Vector3.left * BallBouncing.startSpeed, ForceMode.VelocityChange);
            }
        }

        leftDisplay.text = leftScore.ToString();
        if(leftScore <= 3)
        {
            leftDisplay.color = new Color(0f, 0f, 255f);
        }else if (leftScore <= 6)
        {
            leftDisplay.color = new Color(0f, 255f, 0f);
        }else if (leftScore <= 9)
        {
            leftDisplay.color = new Color(255f, 0f, 255f);
        }
        else
        {
            leftDisplay.color = new Color(255f, 0f, 0f);
        }

        rightDisplay.text = rightScore.ToString();
        if (rightScore <= 3)
        {
            rightDisplay.color = new Color(0f, 0f, 255f);
        }
        else if (rightScore <= 6)
        {
            rightDisplay.color = new Color(0f, 255f, 0f);
        }
        else if (rightScore <= 9)
        {
            rightDisplay.color = new Color(255f, 0f, 255f);
        }
        else
        {
            rightDisplay.color = new Color(255f, 0f, 0f);
        }

        if (rightScore == 11)
        {
            Debug.Log("Right Wins!");
            rightDisplay.text = "Winner!";
            leftDisplay.text = "Better luck next time.";
            rightScore = 0;
            leftScore = 0;
        }

        if (leftScore == 11)
        {
            leftDisplay.text = "Winner!";
            rightDisplay.text = "Better luck next time.";
            Debug.Log("Left Wins!");
            rightScore = 0;
            leftScore = 0;
        }
    }
}
