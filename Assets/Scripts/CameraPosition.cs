using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset = new Vector3(-2.6f, 8.5f, -4.6f);
   

    private void Awake()
    {
    
    }
    void Start()
    {
        
       

    }
    
    void Update()
    {       
        transform.position = player.transform.position + offset;
    }
}
