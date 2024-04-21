using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.XR;


[RequireComponent(typeof(CharacterController))]

public class ThirdPersonControllerM : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float gravity = 40.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    //Rigidbody mC;
    private Animator animator;
    int movementPressedHash;
    private Vector3 movement;
    //private VariableDeclaration someBone = Bone.get < ("Hatbone1") >;

    //BL_Hat01_MOD_V1.transform.parent = Hatbone1;
    //public bool CartCollection { get; private set; }


    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    //public VariableDeclaration SomeBone { get => someBone; set => someBone = value; }

    void Start()
    {
        characterController = GetComponent<CharacterController>();

       // mC = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        movementPressedHash = Animator.StringToHash("Movement Pressed");


        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canMove = true;
    }

    private bool getCartHeld(CartCollection cartCollection)
    {
        return cartCollection;
    }


    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);

    

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX); //+ (right * curSpeedY);


        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = 0;

        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

            //for animations
            bool movementPressed = animator.GetBool(movementPressedHash);
            bool forwardPressed = Input.GetKey("w");
            // bool isEmoting = input.GetKey("f");
            bool getCartHeld = true;
            //isRunning boolean is already called at top of update function
 
            //walking
            if (!movementPressed && forwardPressed)
            {
                animator.SetBool(movementPressedHash, true);
            }
            //not walking, back to idle?
            if (movementPressed && !forwardPressed)
            {
                animator.SetBool(movementPressedHash, false);
            }
            //running 
            if (isRunning && forwardPressed)
            {
                animator.SetBool("Shift Pressed", true);
            }
            //not running, back to idle?
            if (!isRunning && !forwardPressed)
            {
                animator.SetBool("Shift Pressed", false);
                animator.SetBool("Movement Pressed", false);
            }
            //idle with cart
            if (!movementPressed && getCartHeld)
            {
                animator.SetBool("Movement Pressed", false);
                animator.SetBool("Cart Held", true);

            }
            // idle without cart
            if (!movementPressed && !getCartHeld)
            {
                animator.SetBool("Movement Pressed", false);
                animator.SetBool("Cart Held", false);
            }
            //emoting when its added
            //if (isEmoting)
            //{
            //  animator.SetBool("isEmoting", true);
            //}

            //if (!isEmoting && movementPressed)
            //{
            //  animator.SetBool("isEmoting", false);
            //  animator.SetBool("Movement Pressed", true);
            //}

            //walking with cart
            if (movementPressed && getCartHeld)
            {
                animator.SetBool("Movement Pressed", true);
                animator.SetBool("Cart Held", true);
            }
            //running with cart?
            //if (isRunning && getCartHeld)
            //{
             //   animator.SetBool("Shift Pressed", true);
             //   animator.SetBool("Cart Held", true);
           // }
        }
    }

    private void FixedUpdate()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       // CheckAnimation();
    }
   
        //private void changeAnimation(string animation, float crossfade = 0.2F)
        //{
          //  if (currentAnimation != animation)
            //{
              //  currentAnimation = animation;
                //animator.CrossFade(animation, crossfade);
            //}
        //}
}
