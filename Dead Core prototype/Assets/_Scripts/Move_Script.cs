using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Script : MonoBehaviour
{
    //Variables
    public float gravity = 10.0f;
    public float speed = 1f;
    public Vector3 moveDirection = Vector3.zero;

    private Camera playerCam;

    void Start()
    {
        playerCam = FindObjectOfType<Camera>();
    }

    void Update ()
    {
        //Player moves
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //Sets camera position
        playerCam.transform.position = new Vector3(transform.position.x, 25, transform.position.z);
    }
}
