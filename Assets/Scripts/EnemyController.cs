using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;  // Speed at which the enemy moves towards the player
    public float stopDistance = 1.5f; // Distance at which the enemy stops

    public Animator animator;

    public float attackDistance = 1f; // Distance within which the enemy will attack
    public float attackRate = 1f;     // Time between attacks in seconds

    private float nextAttackTime = 0f;
    [SerializeField]
    private GameObject player; // Reference to the player GameObject

    void Start()
    {
        // Find the player GameObject by tag
        player = GameObject.FindGameObjectWithTag("Player");

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction and distance to the player
            Vector3 direction = (player.transform.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, player.transform.position);

            // If the enemy is farther than stopDistance, move towards the player
            if (distance > stopDistance)
            {
                // Move enemy towards the player
                transform.position += direction * speed * Time.deltaTime;

                // Rotate the enemy to face the direction of movement
                RotateTowards(direction);
            }

            // If the enemy is within attackDistance, initiate an attack
            if (distance <= attackDistance)
            {
                Attack();
            }
        }
    }

    void RotateTowards(Vector3 direction)
    {
        // Calculate the new rotation based on the movement direction
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        
        // Smoothly rotate towards the target direction
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
    }

    void Attack()
    {
        // Ensure the enemy only attacks once per interval
        if (Time.time >= nextAttackTime)
        {
            // Trigger the attack animation
            animator.SetTrigger("Attack");

            // Implement the logic for the attack here (e.g., reducing player's health)

            // Set the time for the next attack
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
}
