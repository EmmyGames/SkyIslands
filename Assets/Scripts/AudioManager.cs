using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip interact;
    public AudioClip jump;
    public AudioClip land;
    public AudioClip pickup;
    public AudioClip teleport;
    public AudioClip noKey;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "interact":
                audioSource.PlayOneShot(interact);
                break;
            case "jump":
                audioSource.PlayOneShot(jump);
                break;
            case "land":
                audioSource.PlayOneShot(land);
                break;
            case "pickup":
                audioSource.PlayOneShot(pickup);
                break;
            case "teleport":
                audioSource.PlayOneShot(teleport);
                break;
            case "noKey":
                audioSource.PlayOneShot(noKey);
                break;
        }
    }
}
