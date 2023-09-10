using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    public Vector3 offset;
    void Start()
    {
        offset = transform.position - followTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followTarget.transform.position + offset;
    }
}
