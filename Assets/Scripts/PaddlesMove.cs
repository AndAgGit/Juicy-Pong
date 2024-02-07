using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlesMove : MonoBehaviour
{
    public float speed;
    public Transform lPad, rPad;
    public Rigidbody lRB, rRB;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float lAxis = Input.GetAxis("Horizontal");
        float rAxis = Input.GetAxis("Vertical");

        lRB.AddForce(lAxis * Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
        rRB.AddForce(rAxis * Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);

    }
}
;