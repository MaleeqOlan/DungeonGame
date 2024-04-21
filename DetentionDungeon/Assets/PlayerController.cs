using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 startingPosition;

    void Start()
    {
        // Store the starting position of the player
        startingPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with a key
        if (other.CompareTag("Key"))
        {
            // Move the player back to the starting position
            transform.position = startingPosition;
        }
    }
}