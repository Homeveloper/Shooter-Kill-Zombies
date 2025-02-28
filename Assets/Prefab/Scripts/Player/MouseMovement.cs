using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mousesensivity = 600f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {        
        float mouseX = Input.GetAxis("Mouse X") * mousesensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesensivity * Time.deltaTime;
              
        xRotation -= mouseY;
                
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);
                
        yRotation += mouseX;
           
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
