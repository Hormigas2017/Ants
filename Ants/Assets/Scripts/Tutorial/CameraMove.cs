using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    Transform mTransform;
    Camera cameraHija;

    Vector3 pos;
   // int sizeCamera = 10;

    public delegate void CameraMovement();
    public static event CameraMovement OnCameraMove;
    public static event CameraMovement OnCameraSize;

    void Start()
    {
        pos = new Vector3(173, 0, 71);
        mTransform = GetComponent<Transform>();
        cameraHija = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        MovementCamera();
        SizeCamera();
    }

    public void MovementCamera()
    {
        if (pos != mTransform.position)
        {
            OnCameraMove();
        }
    }

    public void SizeCamera()
    {
        if (10 != cameraHija.orthographicSize)
        {
            OnCameraSize();
        }
    }
}
