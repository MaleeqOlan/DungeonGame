using UnityEngine;

public class AnswerObject : MonoBehaviour
{
    public enum AnswerType
    {
        Correct,
        Incorrect
    }

    public AnswerType answerType;
    public AudioClip correctSound;
    public AudioClip incorrectSound;

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
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Play sound based on the type of answer object
            switch (answerType)
            {
                case AnswerType.Correct:
                    if (correctSound != null)
                    {
                        audioSource.PlayOneShot(correctSound);
                    }
                    break;
                case AnswerType.Incorrect:
                    if (incorrectSound != null)
                    {
                        audioSource.PlayOneShot(incorrectSound);
                    }
                    break;
            }
        }
    }
}
