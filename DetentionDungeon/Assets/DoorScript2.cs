using UnityEngine;

public class DoorScript2 : MonoBehaviour
{
    private void Start()
    {
        // You can add any initialization code here
    }

    // Method to handle door2 destruction
    public void DestroyDoor()
    {
        // Add any visual/audio effects here (e.g., explosion, sound)
        
        // Destroy the door2 object
        Destroy(gameObject);
    }
}
