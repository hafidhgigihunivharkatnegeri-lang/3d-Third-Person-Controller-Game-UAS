using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator; // Reference to the Animator
    public float walkSpeed = 6f; // Walking speed
    public float runSpeed = 12f; // Running speed
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;
    public Camera cam;
    public float turnSmoothTime = 0.1f;
    public float rotationSpeed = 100f; // Rotation speed
    public AudioSource footstepAudioSource; // AudioSource for footsteps
    public AudioClip footstepClip; // Footstep sound clip
    public float footstepInterval = 0.5f; // Interval between footsteps
    
    private float turnSmoothVelocity;
    private Vector3 velocity;
    private bool isGrounded;
    private float footstepTimer = 0f; // Timer for footstep sounds

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (footstepAudioSource == null)
        {
            footstepAudioSource = gameObject.AddComponent<AudioSource>();
        }
        footstepAudioSource.clip = footstepClip;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small negative value to keep the player grounded
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        animator.SetFloat("Speed", direction.magnitude * currentSpeed);
        animator.SetBool("IsGrounded", isGrounded);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * currentSpeed * Time.deltaTime);
        }

        if (direction.magnitude > 0 && isGrounded)
        {
            footstepTimer += Time.deltaTime;
            if (footstepTimer >= footstepInterval)
            {
                footstepAudioSource.Play();
                footstepTimer = 0f;
            }
        }
        else
        {
            footstepTimer = 0f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("Jump");
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
