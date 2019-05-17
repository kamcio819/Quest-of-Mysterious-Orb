using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound
{
    [HideInInspector]
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.5f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

    public void Adjust()
    {
        name = clip.name;
    }

}



public class SoundManager : Singleton<SoundManager>
{

    public bool play;
    public bool playCalm;

    [SerializeField]
    private Sound[] sounds;

    [SerializeField]
    private SpawnManager PlayerCharacter;
    [SerializeField]
    private AudioSource PlayerCharacterSourceCombat;
    [SerializeField]
    private AudioSource PlayerCharacterSourceCalm;

    [SerializeField]
    private AudioClip bossClip;

    [SerializeField]
    private float speed;

    private bool notOnBoss;

    private void Awake()
    {
        notOnBoss = true;


        foreach (Sound s in sounds)
        {
            s.Adjust();
        }
        PlayerCharacterSourceCombat.Pause();
    }

    private void Update()
    {
        if(play)
        {
            PlayCombatMusic();
            play = false;
        }
        if (playCalm)
        {
            PlayCalmMusic();
            playCalm = false;
        }
        if(PlayerCharacter.currentPlayerChunk != null)
        if (PlayerCharacter.currentPlayerChunk.name == "Arena(Clone)")
        if (notOnBoss)
            PlayBossMusic();

    }

    private void Play(Sound sound, AudioSource source)
    {
        source.clip = sound.clip;
        source.pitch = sound.pitch;
        source.volume = sound.volume;
        source.Play(0);
    }

    private void Stop(AudioSource source)
    {
        source.Stop();
    }

    public void PlaySound(string _name, AudioSource source)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                Play(sounds[i], source);
                return;
            }
        }
        Debug.LogWarning("SoundManager: Sound not found in list, " + _name);
    }

    public void StopSound(AudioSource source)
    {
        Stop(source);
    }


    //Muzyka

    public void PlayCombatMusic()
    {
           if(notOnBoss) SwitchMusic(0);
    }
    public void PlayCalmMusic()
    {
           if (notOnBoss) SwitchMusic(1);
    }

    private void SwitchMusic(int type)
    {
        if(type == 0)
        {
            if(PlayerCharacterSourceCalm.isPlaying)
            {
                StartCoroutine(FadeOut(PlayerCharacterSourceCalm, PlayerCharacterSourceCombat, speed));
               // StartCoroutine(FadeIn(PlayerCharacterSourceCombat, speed));

            }
        }
        else if(type == 1)
        {
            if (PlayerCharacterSourceCombat.isPlaying)
            {
                StartCoroutine(FadeOut(PlayerCharacterSourceCombat, PlayerCharacterSourceCalm, speed));
               // StartCoroutine(FadeIn(PlayerCharacterSourceCalm, speed));

            }
        }
    }
    private static IEnumerator FadeOut(AudioSource audioSourceIn, AudioSource audioSourceOut, float FadeTime)
    {
        float startVolume = 1;

        audioSourceOut.Play();

        while (audioSourceIn.volume > 0)
        {
            audioSourceIn.volume -= startVolume * Time.deltaTime / FadeTime;
            audioSourceOut.volume += startVolume * Time.deltaTime / FadeTime;


            yield return null;
        }

        audioSourceIn.Pause();
    }
    private static IEnumerator FadeOutOut(AudioSource audioSourceIn, AudioSource audioSourceOut, float FadeTime, AudioClip bossClip)
    {
        float startVolume = 1;
        audioSourceOut.clip = bossClip;
        audioSourceOut.volume = 1;
        audioSourceOut.Play();
        while (audioSourceIn.volume > 0)
        {
            audioSourceIn.volume -= startVolume * Time.deltaTime / FadeTime;


            yield return null;
        }

        audioSourceIn.Pause();

    }

    private void PlayBossMusic()
    {
        notOnBoss = false;
        StartCoroutine(FadeOutOut(PlayerCharacterSourceCombat, PlayerCharacterSourceCalm, speed, bossClip));
    }

}