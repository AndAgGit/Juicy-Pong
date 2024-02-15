using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlesMove : MonoBehaviour
{
    public static float speed;
    public Transform lPad, rPad;
    public Rigidbody lRB, rRB;
    private float lAxis, rAxis;
    // Start is called before the first frame update
    void Start()
    {
        speed = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        lAxis = Input.GetAxis("Horizontal");
        rAxis = Input.GetAxis("Vertical");

        lRB.AddForce(lAxis * Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
        rRB.AddForce(rAxis * Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
;