using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public AudioClip destructionSound; // The sound to play when the object is destroyed
    public float destructionVolume = 1.0f; // The volume of the destruction sound

    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If there's no AudioSource component attached, add one dynamically
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision object has a tag indicating it's the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play the destruction sound
            if (destructionSound != null)
            {
                audioSource.PlayOneShot(destructionSound, destructionVolume);
            }

            // Destroy the object
            Destroy(gameObject);
        }
    }
}
