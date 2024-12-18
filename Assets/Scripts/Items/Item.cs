﻿using ScriptableObjects;
using UnityEngine;

namespace Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected ItemSettings itemSettings;

        protected void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnHit();
            }
        }

        protected abstract void OnHit();
    }
}