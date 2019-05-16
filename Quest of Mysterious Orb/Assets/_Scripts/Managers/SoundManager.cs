using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool loop;

    [Range(0f, 1f)]
    public float volume = 0.5f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

    public AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
    }

    public void Play()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
}



public class SoundManager : Singleton<SoundManager>
    {

    public static SoundManager instance;

    void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
        }
    }

    private void Start()
    {
        
    }

    [SerializeField]
    public Sound[] sounds;

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
        Debug.LogWarning("SoundManager: Sound not found in list, " + _name);
    }

    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();
                return;
            }
        }
        Debug.LogWarning("SoundManager: Sound not found in list, " + _name);
    }


}