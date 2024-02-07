using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePaddleRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.zero;
        transform.Rotate(0f, 15f * Time.deltaTime, 0f);
    }
}
