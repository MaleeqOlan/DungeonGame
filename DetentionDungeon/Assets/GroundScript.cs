using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private void Start()
    {
        // You can add any initialization code here
    }

    // Method to handle ground destruction
    public void DestroyGround()
    {
        // Add any visual/audio effects here (e.g., crumbling animation, sound)
        
        // Destroy the ground object
        Destroy(gameObject);
    }
}
