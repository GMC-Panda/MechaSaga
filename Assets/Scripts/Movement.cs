﻿// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControl.inputactions'

using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float accelerationModifier = 800f;
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float jumpHeightMultiplier = 2f;
    [SerializeField] Camera playerCamera;
    [SerializeField] float rayCastDistance;

    Rigidbody playerRigidbody;
    PlayerControl playerControl;
    bool isGrounded = true;
    BoxCollider boxCollider;
    bool manipulateGravity = false;

    Quaternion currentRotation = Quaternion.identity;

    Keyboard kb;
    Gamepad gp;

    private void Awake()
    {
        kb = InputSystem.GetDevice<Keyboard>();       
        playerControl = new PlayerControl();
        boxCollider = GetComponent<BoxCollider>();
        playerRigidbody = GetComponent<Rigidbody>();
        
    }
    private void OnEnable()
    {
        EnablePlayerControls();
        GroundCheck();
    }

    private bool GroundCheck()
    {
        RaycastHit hit;

        isGrounded = Physics.BoxCast(transform.position, transform.lossyScale / 2, Vector3.down, out hit,
            Quaternion.identity, rayCastDistance, layerMask);
        return isGrounded;
    }

    private void EnablePlayerControls()
    {
        
        isGrounded = Physics.BoxCast(transform.position, transform.lossyScale/2, Vector3.down, Quaternion.identity, 2f, layerMask) ;
        playerControl.Player.Enable();
      
    }

    private void OnDisable()
    {
        playerControl.Player.Disable();
    }

    void Start()
    {

    }
    private void FixedUpdate()
    {
        GravityManipulation();
    }
    void Update()
    {
        print(isGrounded);
        Moving();                         
    }
    public void Moving()
    {        
        var movementInput = playerControl.Player.Move.ReadValue<Vector2>();

        if (movementInput == Vector2.zero)
        {
            transform.rotation = currentRotation;
        }

        else
        {
            var movement = new Vector3(movementInput.x, 0f, movementInput.y).normalized;
            movement = Quaternion.Euler(0, playerCamera.gameObject.transform.eulerAngles.y, 0) * movement;

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.5f);

            transform.forward = movement;              
            currentRotation = transform.rotation;
            
            transform.Translate(movement * moveSpeed * Time.deltaTime,Space.World);
        
            Sprint(movement);
        }
    }

    public void Sprint(Vector3 movement)
    {
        if ((kb.shiftKey.IsPressed(0)))
        {
            moveSpeed = 15f;
        }
        else
        {
            moveSpeed = 5f;
        }
        /*
        if ((kb.shiftKey.IsPressed(0)) && isGrounded && rigidbody.velocity.magnitude < maxSpeed || kb.spaceKey.wasPressedThisFrame)
        {                    
            rigidbody.AddForce(movement * accelerationModifier,ForceMode.VelocityChange);                    
        }  
        */
    }
    public void GravityManipulation()
    {
        if (playerRigidbody.velocity.y < 0)            
            playerRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (playerRigidbody.velocity.y > 0 && !kb.spaceKey.isPressed)
           playerRigidbody.velocity += Vector3.up * Physics.gravity.y * (jumpHeightMultiplier - 1) * Time.deltaTime;
    }
}

    /*public void Jump()
    {
        if (kb.spaceKey.wasPressedThisFrame)
        {
            if (GroundCheck())
            {
                Vector3 jumpHeightVector = new Vector3(0, jumpHeight, 0);

                rigidbody.AddForce(jumpHeightVector, ForceMode.VelocityChange);
            }

        }
    }
    */
    //Code implement Sprint, implement dodgeroll
/*     Gizmo für Boxcollider checks
 *     void OnDrawGizmos()
    {
        float maxDistance = 10f;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(transform.position, transform.lossyScale / 2, Vector3.down, out hit,
            Quaternion.identity, 2f, layerMask);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector3.down * hit.distance);
            Gizmos.DrawWireCube(transform.position + Vector3.down * hit.distance, transform.lossyScale);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, Vector3.down * maxDistance);
        }
    }*/
   
