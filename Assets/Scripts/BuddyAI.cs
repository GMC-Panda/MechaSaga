using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class BuddyAI : MonoBehaviour
{
    [Header("PlayerObject required")]
    [SerializeField] Transform player;

    [Header("Movement")]
    [SerializeField] float sprintSpeed= 14f;
    [SerializeField] float standardSpeed = 6f;
    float turnSpeed = 5f;       
    NavMeshAgent navMeshAgent;

    [Header ("Controls")]
    PlayerControl playerControl;
    Keyboard keyboard;
    Gamepad gamepad;      
  

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerControl = new PlayerControl();
        keyboard = InputSystem.GetDevice<Keyboard>();
        gamepad = InputSystem.GetDevice<Gamepad>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        Movement();        
        Debug.Log(navMeshAgent.speed);        
    }

    private void Movement()
    {
        CheckSprinting();        
        navMeshAgent.SetDestination(player.position);
        SetFacing();
    }

    private void CheckSprinting()
    {
        if (keyboard.shiftKey.IsPressed(0) || gamepad.rightTrigger.IsPressed(0))
        {
            navMeshAgent.speed = sprintSpeed;
        }
        else
            navMeshAgent.speed = standardSpeed;
    }



    private void SetFacing()
    {    
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);       
    }
}
