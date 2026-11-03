using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using Band.Utils;
using UnityEngine.InputSystem.XR;

namespace Band.Core
{
    public class GameController : MonoBehaviour
    {
        private static GameController instance;

        public static GameController Instance { get; private set; }

        private Dictionary<string, object> data;

        private void Start()
        {
            data=new Dictionary<string, object>();
        }

        private void Awake()
        {
            if (instance != null && instance != this)
                Destroy(this.gameObject);
            else
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        public T GetValue<T>(string key)
        {
            if (data.TryGetValue(key, out object value) && value is T typedValue)
            {
                return typedValue;
            }
            return default(T);
        }

        public void SetValue(string key, object value)
        {
            data[key] = value;
        }

        public void Clear()
        {
            data.Clear();
            List<ISubsystem> subsystems= this.GetComponents<ISubsystem>().ToList();
            foreach(ISubsystem subsystem in subsystems)
                subsystem.Clear();
        }
    }
}