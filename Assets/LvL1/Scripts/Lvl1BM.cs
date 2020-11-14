using System.Collections;
using UnityEngine;

public class Lvl1BM : MonoBehaviour
{
    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip loopClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(playEngineSound());
    }

    private IEnumerator playEngineSound()
    {
        audioSource.clip = clip1;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = loopClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
