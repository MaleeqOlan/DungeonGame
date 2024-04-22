using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private void Start()
    {
        // You can add any initialization code here
    }

    // Method to handle door destruction
    public void DestroyDoor()
    {
        // Add any visual/audio effects here (e.g., explosion, sound)
        
        // Destroy the door object
        Destroy(gameObject);
    }
}
