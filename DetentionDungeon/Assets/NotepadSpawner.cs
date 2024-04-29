using UnityEngine;

public class NotepadSpawner : MonoBehaviour
{
    public GameObject notepadPrefab;
    public Transform playerTransform;
    public float spawnInterval = 1f;
    public float spawnRadius = 10f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnNotepad();
            timer = 0f;
        }
    }

    void SpawnNotepad()
    {
        Vector3 spawnPosition = playerTransform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 20f; // Height from which notepads will fall

        GameObject notepad = Instantiate(notepadPrefab, spawnPosition, Quaternion.identity);

        // Assuming the NotepadProjectile script handles the notepad behavior
        NotepadProjectile notepadProjectile = notepad.GetComponent<NotepadProjectile>();
        if (notepadProjectile != null)
        {
            notepadProjectile.playerTransform = playerTransform;
        }
    }
}
