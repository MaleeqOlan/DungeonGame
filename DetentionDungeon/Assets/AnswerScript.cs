using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrectAnswer; // Set this in the Unity Editor for each answer
    public GameObject groundPrefab; // Assign the ground prefab in the Unity Editor
    public Transform checkpoint1; // Assign the Checkpoint1 transform in the Unity Editor
    public GameObject player; // Assign the player GameObject in the Unity Editor

    private GameObject groundInstance; // Keep track of the spawned ground object
    private Vector3 originalGroundPosition; // Store the original position of the ground

    private bool isGroundDestroyed = false; // Flag to track if ground is destroyed

    private void Start()
    {
        if (groundPrefab != null)
        {
            originalGroundPosition = groundPrefab.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (isCorrectAnswer)
            {
                // Destroy the door
                GameObject door = GameObject.FindWithTag("Door");
                if (door != null)
                {
                    DoorScript doorScript = door.GetComponent<DoorScript>();
                    if (doorScript != null)
                    {
                        doorScript.DestroyDoor();
                    }
                }
            }
            else
            {
                // Destroy the ground if it's not already destroyed
                if (!isGroundDestroyed)
                {
                    GameObject ground = GameObject.FindWithTag("Ground");
                    if (ground != null)
                    {
                        Destroy(ground);
                    }
                    isGroundDestroyed = true;

                    // Respawn the ground after a delay
                    Invoke("RespawnGround", 1f);

                    // Respawn the player on the ground
                    RespawnPlayer();
                }
            }
            // Destroy the bullet
            Destroy(collision.gameObject);
        }
    }

    // Method to respawn the ground at its original position
    private void RespawnGround()
    {
        if (groundPrefab != null)
        {
            groundInstance = Instantiate(groundPrefab, originalGroundPosition, Quaternion.identity);
            isGroundDestroyed = false; // Reset the flag
        }
    }

    // Method to respawn the player on the ground
    private void RespawnPlayer()
    {
        if (groundInstance != null && player != null)
        {
            player.transform.position = groundInstance.transform.position + Vector3.up; // Respawn just above the ground
        }
    }
}
