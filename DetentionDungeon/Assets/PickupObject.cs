using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public AudioClip pickupSound; // The sound to play when the object is picked up
    public float pickupVolume = 1.0f; // The volume of the pickup sound

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
        // Check if the player has entered the trigger zone of the object
        if (other.CompareTag("Player"))
        {
            // Play the pickup sound
            if (pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound, pickupVolume);
            }

            // Optionally, you can add other effects like hiding the object or adding it to the player's inventory
            gameObject.SetActive(false); // Hide the object when picked up
            // Add the object to the player's inventory or perform other actions here
        }
    }
}
