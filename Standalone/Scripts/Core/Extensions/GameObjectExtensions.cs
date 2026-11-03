
using UnityEngine;

namespace Band.Extensions
{
    public static class GameObjectExtensions
    {
        public static bool IsContainedLayer(this GameObject gameobject, LayerMask mask)
        {
            return LayerMaskExtensions.ContainLayer(mask,gameobject.layer);
        }

    }
}
