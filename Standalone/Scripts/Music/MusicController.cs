using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MusicController : MonoBehaviour, ISubsystem
{

    [SerializeField]
    private List<SoundEffect> soundClips;

    private void Start()
    {
        foreach (SoundEffect sound in soundClips)
            sound.Source = this.AddComponent<AudioSource>();
    }

    public void Play(int index)
    {
        if(soundClips.Count > index && index>=0)
            soundClips[index].Play();
    }

    public void Play(string name)
    {
        SoundEffect sound=soundClips.FirstOrDefault((sound)=>sound.Name==name);
        sound?.Play();
    }

    public void Pause(int index)
    {
        if (soundClips.Count > index && index >= 0)
            soundClips[index].Pause();
    }

    public void Pause(string name)
    {
        SoundEffect sound = soundClips.FirstOrDefault((sound) => sound.Name == name);
        sound?.Pause();
    }

    public void Stop(int index)
    {
        if (soundClips.Count > index && index >= 0)
            soundClips[index].Stop();
    }

    public void Stop(string name)
    {
        SoundEffect sound = soundClips.FirstOrDefault((sound) => sound.Name == name);
        sound?.Stop();
    }

    public void Unpause(int index)
    {
        if (soundClips.Count > index && index >= 0)
            soundClips[index].UnPause();
    }

    public void Unpause(string name)
    {
        SoundEffect sound = soundClips.FirstOrDefault((sound) => sound.Name == name);
        sound?.UnPause();
    }

    public void Clear()
    {
        foreach(SoundEffect sound in soundClips)
            sound.Stop();
    }

  
}
