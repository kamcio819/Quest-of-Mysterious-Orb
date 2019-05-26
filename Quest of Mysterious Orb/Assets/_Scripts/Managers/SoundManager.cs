using System;
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

    public bool playCombat;

   
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

    protected override void Awake()
    {
        base.Awake();
        notOnBoss = true;
        foreach (Sound s in sounds)
        {
            s.Adjust();
        }
        PlayerCharacterSourceCombat.Pause();
    }

    public void Play()
    {
        PlayBossMusic();
    }

    public void SetSound(string v, AudioSource audioSource)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == v)
            {
                SetSoundSource(sounds[i], audioSource);
                return;
            }
        }
    }

    private void SetSoundSource(Sound sound, AudioSource audioSource)
    {
        audioSource.clip = sound.clip;
        audioSource.pitch = sound.pitch;
        audioSource.volume = sound.volume;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void Pause()
    {
        
    }


    private void Update()
    {
        if(playCombat && notOnBoss)
        {
            PlayCombatMusic();
        }
        if (playCalm && notOnBoss)
        {
            PlayCalmMusic();
        }
        if(PlayerCharacter.currentPlayerChunk != null) {
            if (PlayerCharacter.currentPlayerChunk.name == "Arena(Clone)") {
                PlayBossMusic();
            }
        }
    }

    private void Play(Sound sound, AudioSource source)
    {
        source.clip = sound.clip;
        source.pitch = sound.pitch;
        source.volume = sound.volume;
        source.time = 0f;
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

    public void PlayCombatMusic()
    {
           SwitchMusic(0);
    }
    public void PlayCalmMusic()
    {
           SwitchMusic(1);
    }

    private void SwitchMusic(int type)
    {
        if(type == 0)
        {
            if(PlayerCharacterSourceCalm.isPlaying)
            {
                StartCoroutine(FadeOut(PlayerCharacterSourceCalm, PlayerCharacterSourceCombat, speed));
            }
        }
        else if(type == 1)
        {
            if (PlayerCharacterSourceCombat.isPlaying)
            {
                StartCoroutine(FadeOut(PlayerCharacterSourceCombat, PlayerCharacterSourceCalm, speed));
            }
        }
    }
    private static IEnumerator FadeOut(AudioSource audioSourceIn, AudioSource audioSourceOut, float FadeTime)
    {
        float startVolume = 0.15f;

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
        float startVolume = 0.15f;
        audioSourceOut.clip = bossClip;
        audioSourceOut.volume = 0.15f;
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