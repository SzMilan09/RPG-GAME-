using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public CustomInput input = null;

    CharacterController controller;
    public Vector3 moveVector;
    Vector3 wheremove;
    public float speed = 5;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = new CustomInput();
        
    }

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        input.Enable();
        input.Player.Movement.performed += OnMovmentPreformed;
        input.Player.Movement.canceled += OnMovmentCancelled;
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        input.Disable();
        input.Player.Movement.performed -= OnMovmentPreformed;
        input.Player.Movement.canceled -= OnMovmentCancelled;
    }

    void OnMovmentPreformed(InputAction.CallbackContext contex)
    {
        moveVector = contex.ReadValue<Vector2>();
        
    }

    void OnMovmentCancelled(InputAction.CallbackContext contex)
    {
        moveVector = Vector2.zero;
        
    }

    void FixedUpdate()
    {
        
        
        wheremove = transform.forward*moveVector.y+transform.right*moveVector.x;
        //Debug.Log(wheremove);
        controller.Move(wheremove*Time.deltaTime*speed);

    }
}
