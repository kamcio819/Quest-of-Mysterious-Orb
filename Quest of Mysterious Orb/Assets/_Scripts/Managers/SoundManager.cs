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

    [SerializeField]
    private Sound[] sounds;

    [SerializeField]
    private GameObject PlayerCharacter;
    [SerializeField]
    private GameObject PlayerCharacterSoundCollider;
    [SerializeField]
    private AudioSource PlayerCharacterSource;
    [SerializeField]
    private Sound combatMusic;
    [SerializeField]
    private Sound calmMusic;

    [SerializeField]
    private float speed;



    private void Start()
    {
        foreach(Sound s in sounds)
        {
            s.Adjust();
        }
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

    private void PlayCombatMusic()
    {
        StartCoroutine(SwitchMusic(0));
    }
    private void PlayCalmMusic()
    {
        StartCoroutine(SwitchMusic(1));
    }

    private IEnumerator SwitchMusic(int type)
    {
        if(type == 0)
        {
            if(PlayerCharacterSource.clip.name == "calm")
            {

            }
        }
        else
        {

        }
        yield return null;
    }
}