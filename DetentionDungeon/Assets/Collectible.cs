using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip pickupSound; // Sound to play when the collectible is picked up
    public float pickupVolume = 1.0f; // Volume of the pickup sound

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

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Play the pickup sound
            if (pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound, pickupVolume);
            }

            // Perform collectible pickup logic here
            Collect();
        }
    }

    void Collect()
    {
        // Optionally, you can add logic here to handle what happens when the collectible is picked up
        // For example, you might want to increase a score or hide the collectible object
        gameObject.SetActive(false); // Hide the collectible object when picked up
        // Add other logic here as needed
    }
}
