using UnityEngine;

public class GunSound : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform barrel; // Transform representing the barrel of the gun
    public AudioClip shootSound; // Sound to play when shooting
    public float shootVolume = 1.0f; // Volume of the shoot sound

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

    // Function to shoot the bullet
    public void Shoot()
    {
        // Instantiate the bullet at the barrel's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);

        // Play the shoot sound
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound, shootVolume);
        }
        
        // Optionally, you can add code here to set the velocity or force of the bullet
    }
}
