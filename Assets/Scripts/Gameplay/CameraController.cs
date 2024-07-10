using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;

    private float _xRotation = 0f;
    private float _mouseX, _mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * GameSettings.Settings.mouseSensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * GameSettings.Settings.mouseSensitivity * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up*_mouseX);
    }
}