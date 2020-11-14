using UnityEngine;

/// <summary>
/// Audio source for the entire game
/// </summary>
public class GameAudioSource : MonoBehaviour
{
    /// <summary>
    /// Initializes the audio source (singleton)
    /// </summary>
    private void Awake()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        AudioManager.Initialize(audioSource);
    }
}
