using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject CameraPos;

    public float xsens;
    public float ysens;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = CameraPos.transform.position;
        transform.forward = CameraPos.transform.forward;
    }
}
