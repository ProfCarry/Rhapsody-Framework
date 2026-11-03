using System.Collections.Generic; // Necessario per usare le List
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class VisualController : MonoBehaviour
{

    protected Animator animator;

    private Vector3 lastDirection;

    public Vector3 Direction { get; set; }

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

}