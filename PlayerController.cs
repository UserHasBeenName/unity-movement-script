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
    public KeyCode i_forward;
    public KeyCode i_left;
    public KeyCode i_backward;
    public KeyCode i_right;
    [Header("Camera Options")]
    public Camera playerCamera;
    public GameObject cameraStabiliser;
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
        if (Input.GetKeyDown(i_forward)) {
            player.transform.position = transform.forward;
        }
        if (Input.GetKeyDown(i_left)) {
            player.transform.position = -transform.right;
        }
        if (Input.GetKeyDown(i_backward)) {
            player.transform.position = -transform.forward;
        }
        if (Input.GetKeyDown(i_right)) {
            player.transform.position = transform.right;
        }
    }
    void Update() {
        float horizontalInput = cameraSensitivity * Input.GetAxis("Mouse X");
        float verticalInput = cameraSensitivity * Input.GetAxis("Mouse Y");
        void MouseLook() {
            if ((horizontalInput != 0) || (verticalInput != 0)) {
                cameraStabiliser.transform.Rotate(new Vector3(0, horizontalInput, 0));
                player.transform.Rotate(new Vector3(0, horizontalInput, 0));
                playerCamera.transform.Rotate(new Vector3(-verticalInput, 0, 0));
            } else {
                Debug.Log("No cam movement");
            }
        }
        MouseLook();
    }
}
