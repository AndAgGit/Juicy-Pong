using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Transform leftPaddle, rightPaddle, topWall, botWall, middlePaddle;
    public Rigidbody ball;
    public float minPaddleSize, maxPaddleSize;
    public BoxCollider leftBC, rightBC;
    public GameObject illumination, entireMiddlePaddle;

    private bool eventEnabled, wallsShrunk, middleActive, isLight;
    private Vector3 ballVelocity;
    // Start is called before the first frame update
    void Start()
    {
        eventEnabled = true;
        wallsShrunk = false;
        middleActive = false;
        isLight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if event can be picked
        if(BallBouncing.bounces % 5 == 0 && eventEnabled && BallBouncing.bounces != 0)
        {
            //event is able to be picked on the fifth * n bounce
            eventEnabled = false;
            StartEvent();
            
        }

        if ((BallBouncing.bounces - 1) % 5 == 0 && !eventEnabled)
        {
            // ensures we're not picking events multiple times per valid volley
            eventEnabled = true;
            
        }
    }

    void StartEvent()
    {
        //Invoke("BallFreeze", 0.1f);

        int num = (int) Random.Range(0f, 5f);
        float size;
        switch (num)
        {
            case 0: //paddle size
                do
                {
                    size = Random.Range(minPaddleSize, maxPaddleSize);
                } while (Mathf.Abs(size - leftPaddle.GetComponent<PaddleSize>().size) <= 0.5f);
                
                leftPaddle.GetComponent<PaddleSize>().Resize(size);
                rightPaddle.GetComponent<PaddleSize>().Resize(size);
                break;
            case 1: //wall shrink
                Transform ballTransform = ball.GetComponent<Transform>();
                
                if (wallsShrunk)
                {
                    topWall.position = new Vector3(0f, 0f, 10f);
                    botWall.position = new Vector3(0f, 0f, -10f);
                    wallsShrunk = false;
                }
                else
                {
                    topWall.position = new Vector3(0f, 0f, 5f);
                    botWall.position = new Vector3(0f, 0f, -5f);

                    float offset = 5.5f;

                    if (ballTransform.position.z > 4.5f)
                    {
                        ballTransform.position += Vector3.back * (ballTransform.position.z - 4.5f);
                    }

                    if (ballTransform.position.z < -4.5f)
                    {
                        ballTransform.position += Vector3.back * (ballTransform.position.z + 4.5f);
                    }


                    float zDifference = leftBC.bounds.max.z - offset;
                    if (zDifference > 0)
                    {
                        leftBC.transform.position += Vector3.back * zDifference;
                    }

                    zDifference = leftBC.bounds.min.z + offset;
                    if (zDifference < 0)
                    {
                        leftBC.transform.position += Vector3.back * zDifference;
                    }

                    zDifference = rightBC.bounds.max.z - offset;
                    if (zDifference > 0)
                    {
                        rightBC.transform.position += Vector3.back * zDifference;
                    }

                    zDifference = rightBC.bounds.min.z + offset;
                    if (zDifference < 0)
                    {
                        rightBC.transform.position += Vector3.back * zDifference;
                    }

                    wallsShrunk = true;
                }
                ballTransform.parent = null;
                break;
            case 2: //middle paddle
                if (entireMiddlePaddle.activeSelf)
                {
                    do
                    {
                        size = Random.Range(minPaddleSize, maxPaddleSize);
                    } while (Mathf.Abs(size - middlePaddle.GetComponent<PaddleSize>().size) <= 0.5f);

                    middlePaddle.GetComponent<PaddleSize>().Resize(size);
                }

                entireMiddlePaddle.SetActive(true);
                break;
            case 3: //night mode
                isLight = !isLight;
                illumination.SetActive(isLight);
                break;
            case 4: //track ball
                CameraTracking.isTracking = !CameraTracking.isTracking;
                break;
            default:
                if (entireMiddlePaddle.activeSelf)
                {
                    do
                    {
                        size = Random.Range(minPaddleSize, maxPaddleSize);
                    } while (Mathf.Abs(size - middlePaddle.GetComponent<PaddleSize>().size) <= 0.5f);

                    middlePaddle.GetComponent<PaddleSize>().Resize(size);
                }

                entireMiddlePaddle.SetActive(true);
                break;
                break;

        }

        //Invoke("BallContinue", 1);
    }

    void BallFreeze()
    {
        ballVelocity = ball.velocity;
        ball.velocity = Vector3.zero;
    }
    void BallContinue()
    {
        ball.AddForce(ballVelocity, ForceMode.VelocityChange);
    }
}
