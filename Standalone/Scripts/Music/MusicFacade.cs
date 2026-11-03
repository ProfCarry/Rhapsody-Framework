
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicFacade : FacadeBase<MusicController>
{
    [SerializeField]
    private string soundName;

    protected override void Start()
    {
        base.Start();
        
    }

    public void Play()
    {
        if(!string.IsNullOrEmpty(soundName))
            subsystem.Play(soundName);
    }

    public void Pause()
    {
        if (!string.IsNullOrEmpty(soundName))
            subsystem.Pause(soundName);
    }

    public void Stop()
    {
        if (!string.IsNullOrEmpty(soundName))
            subsystem.Stop(soundName);
    }

    public void Unpause()
    {
        if (!string.IsNullOrEmpty(soundName))
            subsystem.Unpause(soundName);
    }
}
