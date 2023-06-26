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

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        // Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;
    }

    bool IsGrounded() {
        // return Physics.Raycast(transform.position, -Vector3.up, dist);
        return true;
    }


    void FixedUpdate()
    {
        // if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0) {
        //     playerRigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), -gravity, Input.GetAxisRaw("Vertical")) * speed / 2;
        // } else {
        //     playerRigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), -gravity, Input.GetAxisRaw("Vertical")) * speed;
        // }
        // if (Input.GetKey(buttonForward)) {
        //     Debug.Log(player.transform.rotation);
        //     player.transform.position += transform.forward * speed * Time.deltaTime;
        //     // playerRigidbody.velocity = transform.forward * speed * Time.deltaTime;
        // }
        // if (Input.GetKey(buttonLeft)) {
        //     player.transform.position -= transform.right * speed * Time.deltaTime;
        // }
        // if (Input.GetKey(buttonBackward)) {
        //     player.transform.position -= transform.forward * speed * Time.deltaTime;
        // }
        // if (Input.GetKey(buttonRight)) {
        //     player.transform.position += transform.right * speed * Time.deltaTime;
        // }        
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
                // cameraStabiliser.transform.Rotate(new Vector3(0, horizontalInput, 0));
                player.transform.Rotate(new Vector3(0, horizontalInput, 0));
                playerCamera.transform.Rotate(new Vector3(-verticalInput, 0, 0));
            }
        }
        MouseLook();
    }
}
