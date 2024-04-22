using UnityEngine;

public class DoorScript3 : MonoBehaviour
{
    private void Start()
    {
        // You can add any initialization code here
    }

    // Method to handle door3 destruction
    public void DestroyDoor()
    {
        // Add any visual/audio effects here (e.g., explosion, sound)
        
        // Destroy the door3 object
        Destroy(gameObject);
    }
}
