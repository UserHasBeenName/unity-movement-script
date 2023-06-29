using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hierarchy should look like this:
// Manager (empty object)
//     Player (Capsule with rigidbody)
//         Camera (Player Camera)

public class PlayerController : MonoBehaviour
{
    [Header("Player Aspects")]
    public GameObject player;
    public float speed = 5;
    public float gravity = 5;
    public float jumpForce = 1;
    [Header("Player Jump Boxcasting Aspects")]
    public float maxDistance = 1;
    public LayerMask layerMask;
    public Vector3 boxsize;
    public bool showBoxCast = false;
    public bool giveJetPack = false;
    [Header("Controls")]
    public KeyCode buttonForward = KeyCode.W;
    public KeyCode buttonLeft = KeyCode.A;
    public KeyCode buttonBackward = KeyCode.S;
    public KeyCode buttonRight = KeyCode.D;
    public KeyCode jumpButton = KeyCode.Space;
    [Header("Camera Options")]
    public Camera playerCamera;
    public float cameraSensitivity = 1;
    Rigidbody playerRigidbody;


    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        if (showBoxCast){
            Gizmos.DrawCube(player.transform.position-transform.up*maxDistance, boxsize);
        }
    }

    bool IsGrounded() {
        if (Physics.BoxCast(player.transform.position, boxsize, -transform.up, player.transform.rotation, maxDistance, layerMask)) {
            return true;
        } else {
            return giveJetPack;
        }
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
        if (Input.GetKey(jumpButton) && IsGrounded()) {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    

    void Update() {
        float horizontalInput = cameraSensitivity * Input.GetAxis("Mouse X");
        float verticalInput = cameraSensitivity * Input.GetAxis("Mouse Y");

        if ((horizontalInput != 0) || (verticalInput != 0)) {
            player.transform.Rotate(new Vector3(0, horizontalInput, 0));
            playerCamera.transform.Rotate(new Vector3(-verticalInput, 0, 0));
        }
    }
}
