using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    public float speed;
    public float gravity;
    [Header("Controls")]
    public KeyCode buttonForward;
    public KeyCode buttonLeft;
    public KeyCode buttonBackward;
    public KeyCode buttonRight;
    [Header("Camera Options")]
    public Camera playerCamera;
    public float cameraSensitivity;

    Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        // Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;
    }

    bool IsGrounded() {
        return true;
    }


    void FixedUpdate()
    {      
        if (Input.GetKey(buttonForward)) {
            player.transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(buttonLeft)) {
            player.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(buttonBackward)) {
            player.transform.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(buttonRight)) {
            player.transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
        }
    }
    void Update() {
        float horizontalInput = cameraSensitivity * Input.GetAxis("Mouse X");
        float verticalInput = cameraSensitivity * Input.GetAxis("Mouse Y");
        void MouseLook() {
            if ((horizontalInput != 0) || (verticalInput != 0)) {
                player.transform.Rotate(new Vector3(0, horizontalInput, 0));
                playerCamera.transform.Rotate(new Vector3(-verticalInput, 0, 0));
            }
        }
        MouseLook();
    }
}
