using UnityEngine;

public class AudioClipsPlay : MonoBehaviour
{
    public AudioClip[] audioClips;
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayAudioClip(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
}
