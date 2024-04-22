using UnityEngine;

public class AnswerScript3 : MonoBehaviour
{
    public bool isCorrectAnswer; // Set this in the Unity Editor for each answer
    public GameObject groundPrefab; // Assign the ground prefab in the Unity Editor
    public Transform checkpoint1; // Assign the Checkpoint1 transform in the Unity Editor

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
                // Destroy the door3
                GameObject door3 = GameObject.FindWithTag("Door3");
                if (door3 != null)
                {
                    DoorScript3 doorScript = door3.GetComponent<DoorScript3>();
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
}
