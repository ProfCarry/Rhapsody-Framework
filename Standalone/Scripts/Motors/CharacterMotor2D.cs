
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMotor2D : Motor
{
    private Rigidbody2D rigidBody;

    protected override void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        base.Start();
    }

    private void FixedUpdate()
    {
        if (commands.Count == 0)
            return;
        List<IMotorCommand> commandList = commands.Values.ToList();
        foreach(IMotorCommand command in commandList)
        {
            command.Apply(this);
            if (command.Empty())
                commands.Remove(command.GetType());
        }
    }

    public override Vector3 GetVelocity()
    {
        return rigidBody.linearVelocity;
    }

    public override void FreezeVertical(bool value)
    {
        rigidBody.constraints = value ? RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY : RigidbodyConstraints2D.FreezeRotation;
    }

    public override void Freeze(bool value)
    {
        rigidBody.constraints = value ? RigidbodyConstraints2D.FreezeAll  : RigidbodyConstraints2D.FreezeRotation;
    }

    public override void Move(Vector3 vector)
    {
        Vector3 current = rigidBody.linearVelocity;
        current.x = vector.x;
        if (isTopDown)
            current.y = vector.y;
        rigidBody.linearVelocity = current;
    }

    public override void Jump(float jumpForce)
    {
        Vector3 force = Vector3.up * jumpForce;
        Vector3 current = rigidBody.linearVelocity;
        if (jumpForce != 0)
            current.y = force.y;
        rigidBody.linearVelocity = current;
    }

    public override void Knockback(Vector3 direction)
    {
        rigidBody.AddForce(direction, ForceMode2D.Impulse);
    }
}
