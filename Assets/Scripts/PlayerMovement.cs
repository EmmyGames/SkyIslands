using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerScript playerScript;
    public Movement movement;
    public Transform lookDirTransform;
    
    //Movement
    private Vector3 _direction;
    private Vector3 _lastDirection;
    private float _startCamRotation;
    
    public float groundDistance;
    public Transform groundCheck;
    public LayerMask groundMask;
    public bool isGrounded;

    /*
    AudioSource walkingAudio;
    walkingAudio.Play(); -//NOTE: This audio is on loop (IDK how long it'll last) so make sure it actually stops when the player stops
    */
    private void Start()
    {
        //walkingAudio = GetComponent<AudioSource>();
        _startCamRotation = lookDirTransform.eulerAngles.y;
    }
    
    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        _direction = new Vector3(playerScript.playerInput.moveX, 0f, playerScript.playerInput.moveZ).normalized;
        
        /*if(!playerScript.playerAnimation.anim.GetBool(playerScript.playerAnimation.shouldMove))
            _direction = Vector3.zero;*/
        movement.EntityMovement(isGrounded, playerScript.playerInput.isSprinting, playerScript.playerInput.isJumping, lookDirTransform, _startCamRotation, _direction);
    }
}
