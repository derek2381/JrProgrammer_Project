using System.Collections;
using UnityEngine;

public class BoxCastController : MonoBehaviour
{
    public Transform[] enemyTransforms; // Array of enemy transforms
    public float rayLength = 10f; // Maximum distance of the ray

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CastRaysTowardsEnemies();
        }
    }

    void CastRaysTowardsEnemies()
    {
        foreach (Transform enemyTransform in enemyTransforms)
        {
            if (enemyTransform != null)
            {
                // Start point of the ray (this could be the player's position)
                Vector3 rayStart = transform.position;

                // Calculate the direction towards the enemy
                Vector3 directionToEnemy = (enemyTransform.position - rayStart).normalized;

                // Perform the raycast
                RaycastHit hit;
                if (Physics.Raycast(rayStart, directionToEnemy, out hit, rayLength))
                {
                    // If the ray hits something
                    if (hit.transform == enemyTransform)
                    {
                        // The ray hit the specific enemy
                        Debug.Log("Hit the enemy of type: " + enemyTransform.tag);

                        // Visualize the hit with a green line
                        Debug.DrawLine(rayStart, hit.point, Color.green, 1.0f);
                    }
                    else
                    {
                        // The ray hit something else
                        Debug.Log("Ray towards " + enemyTransform.tag + " hit: " + hit.transform.name);

                        // Visualize the hit with a red line
                        Debug.DrawLine(rayStart, hit.point, Color.red, 1.0f);
                    }
                }
                else
                {
                    // If the ray doesn't hit anything, draw a line in the direction
                    Debug.DrawLine(rayStart, rayStart + directionToEnemy * rayLength, Color.red, 1.0f);
                }
            }
            else
            {
                Debug.LogWarning("One of the enemy Transforms is not assigned.");
            }
        }
    }
}