using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with lava
        if (other.CompareTag("Question1"))
        {
            // Respawn the player at the checkpoint
            Respawn();
        }
    }

    void Respawn()
    {
        // Move the player to the respawn point
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
    }
}
