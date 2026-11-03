using UnityEngine;

public interface IMotorCommand
{
    public int Priority { get; set; }

    public void Apply(Motor motor);

    public bool Empty();
}
