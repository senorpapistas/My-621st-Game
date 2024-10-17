using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public LayerMask groundLayer;

    CharacterController characterController;
    private Vector3 move;

    [Header("Speed")]
    public float speed;

    [Header("States")]
    public bool isGrounded;
    public bool isJumping;

    [Header("Jumping")]
    public float jumpHeight;
    public float gravityValue;
    public float yVelocity;
    float yVelocityMax;

    [Header("Camera")]
    public float xsens = 400;
    public float ysens = 400;

    float xRotation;
    float yRotation;

    public GameObject cameraPosParent;

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
        RotationCheck();
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
        move = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right;
        characterController.Move(move * speed * Time.deltaTime);
    }

    void JumpCheck()
    {
        if (isGrounded) { yVelocity = 0f; }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("jumping");
            isJumping = true;
            yVelocityMax = jumpHeight;
        }

        if (isJumping)
        {
            yVelocity += .05f;
            yVelocityMax -= .05f;
        }

        if (isGrounded && !isJumping)
        {
            isJumping = false;
        }

        if (yVelocityMax <= 0)
        {
            isJumping = false;
        }
    }

    void GravityCheck()
    {

        if (!isGrounded) 
        {
            yVelocity += gravityValue * Time.deltaTime;
        }
            characterController.Move(new Vector3(0, yVelocity, 0));
    }

    void RotationCheck()    //rotates player and camera pos parent
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xsens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ysens;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -15f, 80f);
        this.gameObject.transform.rotation = Quaternion.Euler(0, yRotation, 0);

        cameraPosParent.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
