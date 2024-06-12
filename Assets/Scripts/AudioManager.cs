using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private bool muted;

    public AudioSource MusicSource;
    public AudioSource sfxSource;

    private bool isPlaying;


    private static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        muted = PlayerPrefs.GetInt("MUTED") == 1;

        if (muted)
            AudioListener.pause = true;
        
    }

    public void ToggleMute()
    {
        muted = !muted;

        if (muted)
            PlayerPrefs.SetInt("MUTED", 1);
        else
            PlayerPrefs.SetInt("MUTED", 0);

        if (muted)
            AudioListener.pause = true;

    }


    public static void PlaySoundEffect(AudioClip clip)
    {
        if (!instance.muted)
            instance.sfxSource.PlayOneShot(clip);
    }



  

}
