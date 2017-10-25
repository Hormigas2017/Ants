using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 20f;
    public float panBorderThickness = 10f;

    // Update is called once per frame
    void Update ()
    {
        Vector3 position = transform.position;


        if(Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.position += transform.forward * panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= panBorderThickness)
        {
            transform.position -= transform.forward * panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.position += transform.right * panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= panBorderThickness)
        {
            transform.position -= transform.right * panSpeed * Time.deltaTime;
        }

        //position.x = Mathf.Clamp();

        //transform.position = position;


    }
}
