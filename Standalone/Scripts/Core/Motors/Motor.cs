using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class Motor : MonoBehaviour
{
    protected Dictionary<Type,IMotorCommand> commands;

    [SerializeField]
    protected bool isTopDown;

    public abstract Vector3 GetVelocity();

    protected virtual void Start()
    {
        commands = new Dictionary<Type, IMotorCommand>();
    }

    public void AddCommand(IMotorCommand command)
    {
        if(!commands.ContainsKey(command.GetType()))
        {
            commands.Add(command.GetType(), command);
            return;
        }
        Type key = command.GetType();
        IMotorCommand old = commands[key];
        if (old.Priority <= command.Priority)
            commands[key] = command;
    }

    public abstract void FreezeVertical(bool value);

    public abstract void Freeze(bool value);

    public abstract void Move(Vector3 vector);

    public abstract void Jump(float jumpForce);

    public abstract void Knockback(Vector3 direction);

}
