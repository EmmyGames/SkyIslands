using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSens = 50.0f;
    public Transform playerbody;
    float xRotation = 0.0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;

        //Cap look up/down look direction
        if (xRotation > 90f)
            xRotation = 90;
        else if (xRotation < -90)
            xRotation = -90;
        
        // Look up and down
        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

        //Look left and right
        playerbody.Rotate(Vector3.up * mouseX);
    }
}
