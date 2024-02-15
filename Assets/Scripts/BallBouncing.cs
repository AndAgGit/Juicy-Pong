using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncing : MonoBehaviour
{
    public static float startSpeed, deltaSpeed;
    public int maxVolleys;
    public static int volleys, bounces;
    public Transform cam, bgBlue, bgRed, bgGreen, bgBlack;
    public AudioSource bounceSound, volleySound, twinkleSound;
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        startSpeed = 5f;
        deltaSpeed = 2f;
        volleys = 0;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * startSpeed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        particles.Play();
        volleySound.pitch = 1f + ((volleys - 1) * 0.05f);
        bounceSound.pitch = 1f + ((volleys - 1) * 0.05f);
        twinkleSound.pitch = 0.75f + ((volleys - 1) * 0.05f);

        Vector3 collisionNormal = collision.GetContact(0).normal;
        //Debug.Log(collisionNormal);

        bgBlue.position += Vector3.forward * 4;
        bgRed.position += Vector3.forward * 4;
        bgGreen.position += Vector3.forward * 4;
        bgBlack.position += Vector3.forward * 4;

        if (bgBlue.position.z >= 60)
        {
            bgBlue.position = new Vector3(0f, -10f, -20f);
        }

        if (bgRed.position.z >= 60)
        {
            bgRed.position = new Vector3(0f, -10f, -20f);
        }

        if (bgGreen.position.z >= 60)
        {
            bgGreen.position = new Vector3(0f, -10f, -20f);
        }

        if (bgBlack.position.z >= 60)
        {
            bgBlack.position = new Vector3(0f, -10f, -20f);
        }

        bounces++;

        if (collision.gameObject.CompareTag("Player")){
            volleySound.Play();

            if (volleys < maxVolleys)
            {
                volleys++;
            }

            BoxCollider paddleCollider = collision.gameObject.GetComponent<BoxCollider>();
            Bounds paddleBounds = paddleCollider.bounds;

            float maxZ = paddleBounds.max.z;
            float zPos = transform.position.z;
            //Debug.Log($"maxZ = {maxZ}");
            //Debug.Log($"Current zPos = {zPos}");

            float checkZPos = 1 - (maxZ - zPos) / (paddleCollider.size.z / 2f);
            
            //Debug.Log($"checkZPos = {checkZPos}");
            
            
            Quaternion rotation;
            if (collision.gameObject.name.Equals("L Paddle"))
            {
                rotation = Quaternion.Euler(0f, -60f * checkZPos, 0f);
            }
            else
            {
                rotation = Quaternion.Euler(0f, 60f * checkZPos, 0f);
            }

            Vector3 bounceDirection = rotation * collisionNormal;

            //Debug.Log($"bounceDirection: {bounceDirection}");

            float newSpeed = startSpeed + (deltaSpeed * volleys);

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(bounceDirection * newSpeed, ForceMode.VelocityChange);
        }
        else
        {
            bounceSound.Play();
        }
    }
}
