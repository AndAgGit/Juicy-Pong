using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSize : MonoBehaviour
{
    public Transform topSphere, botSphere, paddle;
    public BoxCollider boxCollider;
    public float size;
    // Start is called before the first frame update
    void Start()
    {
        size = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        topSphere.localPosition = transform.localPosition + (Vector3.forward * size);
        botSphere.localPosition = transform.localPosition + (Vector3.back * size);
    }

    public void Resize(float newSize)
    {
        size = newSize;

        transform.localScale = new Vector3(1f, size, 1f);
        boxCollider.size = new Vector3(1f, 1f, (2 * size) + 1f);
        
    }
}
