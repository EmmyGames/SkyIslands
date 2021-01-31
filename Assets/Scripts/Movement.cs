using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Movement : MonoBehaviour
{
    //Components
    private CharacterController _character;
    private AudioManager _audioManager;
    private const float Gravity = -20f;

    //Movement
    private Vector3 _direction;
    private Vector3 _lastDirection;

    public float jumpHeight = 1.7f;
    public float walkSpeed = 3.5f;
    public float walkBackMultiplier = 0.8f;
    public float sprintSpeed = 6f;
    public float speed;

    private Vector3 _moveDir;

    private float _targetAngle;
    private float _lookAngle;
    private float _angle;
    private const float JumpControlModifier = 1f;
    private const float TurnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;

    //Used for gravity calculation
    private Vector3 _velocity = Vector3.zero;
    private bool isLanding = false;

    private void Start()
    {
        _character = GetComponent<CharacterController>();
        _audioManager = GetComponent<AudioManager>();
    }

    public void EntityMovement(bool isGrounded, bool isSprinting, bool isJumping, Transform lookDirTransform, float startRotation, Vector3 direction)
    {
        speed = isSprinting && direction.z > 0f ? sprintSpeed : walkSpeed;
        
        
        direction = GetAxis(_lastDirection, direction);
        _lastDirection = direction;

        _direction = direction;

        if (isGrounded && _velocity.y < 0f)
        {
            if (isLanding)
            {
                _audioManager.PlaySound("land");
                isLanding = false;
            }
            //Reset the velocity that it had accumulated while on the ground
            _velocity.y = -2f;
        }

        //if not grounded (or most likely jumping), change movement
        if (!isGrounded)
        {
            isLanding = true;
            _character.stepOffset = 0f;
            
            _targetAngle = lookDirTransform.eulerAngles.y - startRotation;
            _moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * direction;
            lookDirTransform.localEulerAngles = new Vector3(lookDirTransform.eulerAngles.x, 0, 0);
            //put if(direction.magnitude > 0.1f) to make the player not rotate while standing still.
            transform.rotation = Quaternion.Euler(0f, _targetAngle, 0f);
            
            //Allows the player to have a slight amount of control while in the air determined by jumpControlModifier
            _moveDir += Quaternion.Euler(0f, _targetAngle, 0f) * direction * (JumpControlModifier * Time.deltaTime);
            _character.Move(speed * Time.deltaTime * _moveDir);
        }
        //Changes to walking 3rd person mode
        else if (isGrounded)
        {
            _character.stepOffset = 1.0f;
            if (direction.z < 0.01f)
            {
                speed *= walkBackMultiplier;
            }

            //point player at camera
            _targetAngle = lookDirTransform.eulerAngles.y - startRotation;
            _moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * direction;
            lookDirTransform.localEulerAngles = new Vector3(lookDirTransform.eulerAngles.x, 0, 0);
            //put if(direction.magnitude > 0.1f) to make the player not rotate while standing still.
            transform.rotation = Quaternion.Euler(0f, _targetAngle, 0f);
            _character.Move(speed * Time.deltaTime * _moveDir);
        }

        //Jump Calculations
        //Player can jump smaller amounts by letting go of space
        if (isJumping && isGrounded)
        {
            if (!isLanding)
            {
                _audioManager.PlaySound("jump");
                isLanding = true;
            }

            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);
        }

        _velocity.y += Gravity * Time.deltaTime;
        _character.Move(_velocity * Time.deltaTime);
    }

    public Vector3 GetDirection()
    {
        return _direction;
    }

    Vector3 a = Vector3.zero;
    Vector3 b = Vector3.zero;
    float t = 0f;

    private Vector3 GetAxis(Vector3 lastFrame, Vector3 thisFrame)
    {
        //How fast the acceleration and deceleration is
        const float acceleration = 7f;
        if (lastFrame != thisFrame)
        {
            a = lastFrame;
            b = thisFrame;
            t = 0f;
        }

        t += acceleration * Time.deltaTime;
        return Vector3.Lerp(a, b, t);
    }
}
