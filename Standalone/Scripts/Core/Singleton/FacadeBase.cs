using UnityEngine;

public abstract class FacadeBase<TSubsystem> : MonoBehaviour where TSubsystem : MonoBehaviour,ISubsystem
{
    protected TSubsystem subsystem;

    protected virtual void Start()
    {
        subsystem=GameObject.FindAnyObjectByType<TSubsystem>();
    }

    public void Clear()
    {
        subsystem?.Clear();
    }
}
