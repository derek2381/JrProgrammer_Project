using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody rb;
    public Animator animator;

    public float attackRate = 4f;    // Time between attacks in seconds
    private float nextAttackTime = 0f;

    public Collider weaponCollider; // Reference to the weapon's collider

    private Vector3 movement;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Disable weapon collider at start
        if (weaponCollider != null)
        {
            weaponCollider.enabled = false;
        }
    }

    void Update()
    {
        // Get input from the player
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Set the movement vector based on the input
        movement = new Vector3(moveX, 0, moveZ);

        // Set animation parameters
        SetAnimationParameters();
        

        // Detect attack input (space bar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            weaponCollider.enabled = true;
            Attack();
        }
    }

    void FixedUpdate()
    {
        // Move and rotate the player using Rigidbody physics
        MoveAndRotatePlayer();
        
    }

    void MoveAndRotatePlayer()
    {
        if (movement.magnitude > 0)
        {
            // Calculate the new position
            Vector3 newPosition = transform.position + movement * moveSpeed * Time.fixedDeltaTime;

            // Move the player to the new position
            rb.MovePosition(newPosition);

            // Calculate the rotation based on the movement direction
            Quaternion newRotation = Quaternion.LookRotation(movement);

            // Rotate the player to face the movement direction
            rb.MoveRotation(newRotation);
        }
    }

    void SetAnimationParameters()
    {
        // Calculate the speed based on the magnitude of the movement vector
        float speed = movement.magnitude;

        // Set the speed parameter in the Animator
        animator.SetFloat("Speed", speed);
    }

    void Attack()
    {
        // Set the attack trigger in the Animator
        if (Time.time >= nextAttackTime && weaponCollider.enabled == true)
        {
            // Trigger the attack animation
            
            animator.SetTrigger("Attack");


            
            nextAttackTime = Time.time + 1f / attackRate;

            weaponCollider.enabled = false;
        }
    }

//     IEnumerator EnableColliderTemporarily()
//     {
//         // Enable the collider
//         weaponCollider.enabled = true;

//         // Wait for the duration of the attack animation or a fixed short duration
//         yield return new WaitForSeconds(0f); // Adjust duration as needed

//         // Disable the collider
//         weaponCollider.enabled = false;
//     }
}
