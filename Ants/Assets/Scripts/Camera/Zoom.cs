using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    Camera mCamera;

	void Start ()
    {
        mCamera = GetComponentInChildren<Camera>();
	}

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            mCamera.orthographicSize--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            mCamera.orthographicSize++;
        }
    }
}
