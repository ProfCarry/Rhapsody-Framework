using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    protected Dictionary<Type,CharacterAction> actions;

    protected CharacterMotor2D motor;


    protected virtual void Start()
    {
        actions=new Dictionary<Type,CharacterAction>();
        List<CharacterAction> actionList = this.GetComponentsInChildren<CharacterAction>().ToList();
        motor = this.GetComponent<CharacterMotor2D>();
        foreach(CharacterAction action in actionList)
        {
            action.motor = motor;
            actions.Add(action.GetType(), action);
            Type baseType = action.GetType().BaseType;
            if (!baseType.Equals(typeof(CharacterAction)) && !baseType.Equals(typeof(MonoBehaviour)))
                actions.TryAdd(baseType, action);
        }
    }

    public void DoAction<TAction>(object input) where TAction : CharacterAction
    {
        if (actions == null)
            return;
        if (actions.ContainsKey(typeof(TAction)))
            actions[typeof(TAction)].Execute(input);
        else Debug.LogWarning($"Warning: {typeof(TAction).ToString()} is not assigned!");
    }
}
