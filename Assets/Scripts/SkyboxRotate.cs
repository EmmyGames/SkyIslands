using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotate : MonoBehaviour
{
    public float rotationSpeed;

    private void Update()
    {
        //GET RENDERER OF SKYBOX AND ROTATE IT
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
