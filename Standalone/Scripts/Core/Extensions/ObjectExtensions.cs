using System;

using UnityEngine;

public static class ObjectExtensions
{
    public static bool HasComponent(this UnityEngine.Object obj, Type type)
    {
        return false;
    }

    public static bool HasComponent<TObject>(this UnityEngine.Object obj)
    {
        return HasComponent(obj, typeof(TObject));
    }
}
