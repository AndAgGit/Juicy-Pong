using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public static bool isTracking;
    public Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        isTracking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTracking)
        {
            transform.position = new Vector3(0f, 1f, 0f);
        }
        else
        {
            transform.position = new Vector3(0f, 3f, 0f);
        }
    }
}
