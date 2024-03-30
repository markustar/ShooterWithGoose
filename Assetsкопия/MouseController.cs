using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    float mouseSens = 400;
    float rotation = 0;
    [SerializeField] Transform player;


    private void Start() {

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update() {

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        player.transform.Rotate(Vector3.up * mouseX);

        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -95, 90);
        transform.localRotation = Quaternion.Euler(rotation, 0, 0);
    }
}
