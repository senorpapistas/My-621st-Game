using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public LayerMask groundLayer;

    public float speed;
    CharacterController characterController;
    private Vector3 move;
    public bool isGrounded;
    public bool isJumping;

    public float jumpHeight;
    public float gravityValue;
    public float yVelocity;

    //cam
    public float xsens = 400;
    public float ysens = 400;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        MoveCheck();
        JumpCheck();
        GravityCheck();

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xsens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ysens;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -25f, 90f);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void CheckGrounded()
    {
        Ray ray = new Ray(transform.position, -transform.up * 1.08f);
        Debug.DrawRay(ray.origin, -transform.up * 1.08f, Color.yellow);

        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 1.08f, groundLayer))
        { 
            isGrounded = true;
        }
        else
        {
            isGrounded= false;
        }
    }

    void MoveCheck()
    {
        //move = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right;
        characterController.Move(move * speed * Time.deltaTime);
    }

    void JumpCheck()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("jumping");
            //yVelocity += jumpHeight;
            isJumping = true;
            yVelocity += jumpHeight;
        }

    }

    void GravityCheck()
    {

        if (!isGrounded) 
        {
            yVelocity = gravityValue * Time.deltaTime;
        }
            characterController.Move(new Vector3(0, yVelocity, 0));
    }
}
