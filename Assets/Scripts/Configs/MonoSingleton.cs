using System;
using UnityEngine;

namespace Configs
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        Debug.LogError($"[MonoSingleton] Instance of {typeof(T)} is not found and was not created automatically.");
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = (T)this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}