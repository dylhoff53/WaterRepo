using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DeathSounds : MonoBehaviour
{
    [HideInInspector]
    public AudioSource[] deathSounds;

    public float AudioTimer;


    private void Awake()
    {
        FindObjectOfType<AudioManager>().Play("Quiet_Death1");
        deathSounds = new AudioSource[4];
    }

    private void Start()
    {
        FillArray();
        AudioTimer = deathSounds[0].clip.length - 2.0f;
        Invoke("ChangeSongs", AudioTimer);
    }

    private void FillArray()
    {
        for (int i = 0; i < 5; i++)
        {
            deathSounds[i] = FindObjectOfType<AudioManager>().sounds[i+7].source;
            Debug.Log(deathSounds[i]);
        }
    }

    public void ChangeSongs()
    {
        FindObjectOfType<AudioManager>().Play("Quiet_Dealth2");
        FindObjectOfType<AudioManager>().Play("Loud_Dealth2");
        StartCoroutine(CrossFadeQuietAudio());
    }

    IEnumerator CrossFadeQuietAudio()
    {
        for (float i = 0f; i < 1f; i += 0.1f)
        {
            deathSounds[0].volume -= 0.075f;
            deathSounds[1].volume += 0.075f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
