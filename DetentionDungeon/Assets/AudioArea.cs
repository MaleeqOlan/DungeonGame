using UnityEngine;

public class AudioArea : MonoBehaviour
{
    public AudioClip audioClip;
    public float areaRadius = 5f;
    public Transform player;

    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) <= areaRadius)
        {
            if (!isPlaying)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
                isPlaying = true;
            }
        }
        else
        {
            if (isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}
