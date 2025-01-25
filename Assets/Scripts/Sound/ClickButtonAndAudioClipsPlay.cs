using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtonAndAudioClipsPlay : MonoBehaviour
{
    public Button[] buttons;
    public AudioClip clip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(PlayAudioClip);
        }
    }

    void PlayAudioClip()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
