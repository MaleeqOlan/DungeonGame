using UnityEngine;

public class NotepadProjectile : MonoBehaviour
{
    public Transform playerTransform;
    public float fallSpeed = 5f;

    void Start()
    {
        // Make sure notepads destroy themselves after a certain time if they don't collide with anything
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        // Move the notepad downwards
        transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player is hit, handle respawning
            RespawnPlayer();
        }
        else
        {
            // Destroy the notepad upon colliding with anything other than the player
            Destroy(gameObject);
        }
    }

    void RespawnPlayer()
    {
        // Add your respawn logic here
        // For example:
        playerTransform.position = Vector3.zero; // Move player to a respawn point
    }
}
