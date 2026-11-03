using Band.Core;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    protected virtual void Start()
    {
        
    }

    public void Clear()
    {
        GameController.Instance?.Clear();
    }

    public T GetValue<T>(string key)
    {
        return GameController.Instance.GetValue<T>(key);
    }

    public void SetValue(string key, object value)
    {
        GameController.Instance.SetValue(key, value);
    }
}
