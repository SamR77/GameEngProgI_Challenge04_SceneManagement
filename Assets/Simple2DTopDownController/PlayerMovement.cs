using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public Vector2 moveVector;
    public float moveSpeed = 2.0f;

    void Awake()
    {
        Actions.MoveEvent += UpdateMoveVector;  // Event subscription
    }


    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void UpdateMoveVector(Vector2 inputVector)
    {
        moveVector = inputVector;
    }



    void FixedUpdate()
    {
        // Remove this since movement is now handled through the event        
        HandlePlayerMovement();
    }




    // Modified to accept Vector2 parameter to match Action<Vector2> delegate
    void HandlePlayerMovement()
    {   
       playerRigidbody.MovePosition(playerRigidbody.position + moveVector * moveSpeed * Time.fixedDeltaTime);
    }



    void OnDisable()
    {
        Actions.MoveEvent -= UpdateMoveVector;
    }
}