using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerScript playerScript;
    public bool isSprinting = false;
    public float moveX;
    public float moveZ;
    public bool isJumping;

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        if (playerScript.playerMovement.isGrounded)
            isSprinting = false || Input.GetButton("Sprint");
        
        isJumping = false || Input.GetButton("Jump");
           
    }
}
