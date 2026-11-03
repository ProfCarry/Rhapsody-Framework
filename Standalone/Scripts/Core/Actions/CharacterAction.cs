using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterAction : MonoBehaviour
{
    public UnityEvent<Vector3> OnActionStart;

    public UnityEvent<Vector3> OnActionFinish;

    [SerializeField]
    protected int Priority;

    public Motor motor { get; set; }

    protected virtual void Start()
    {

    }

    public abstract void Execute(object value);
}
