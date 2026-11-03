using UnityEngine;

[System.Serializable]
public class SoundEffect
{
    [SerializeField]
    private string name;

    public string Name { get { return name; } set { name = value; } }

    [SerializeField]
    private AudioClip clip;

    public AudioClip Clip { get { return clip; } set { clip = value; } }

    [SerializeField]
    [Range(0f, 1f)]
    private float volume;

    public float Volume { get { return volume; } set { volume = value; } }

    [SerializeField]
    [Range(0f, 1f)]
    private float pitch;

    public float Pitch { get { return pitch; } set { pitch = value; } }

    [SerializeField]
    private bool loop;

    public bool Loop { get { return loop; } set { loop = value; } }

    private AudioSource source;

    public AudioSource Source { get { return source; } set { source = value; } }

    public SoundEffect(string name, AudioClip clip, float volume, float pitch, bool loop)
    {
        Name = name;
        Clip = clip;
        Volume = volume;
        Pitch = pitch;
        Loop = loop;
    }

    public void Play()
    {
        if(source!=null)
        {
            source.clip = Clip;
            source.volume = Volume;
            source.pitch = Pitch;
            source.loop = Loop;
            source.Play();
        }
    }

    public void Stop()
    {
        if(Source!=null)
            Source.Stop();

    }

    public void Pause()
    {
        if(Source)
            Source.Pause();
    }

    public void UnPause()
    {
        if(Source)
            Source.UnPause();
    }
}