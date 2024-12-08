using ScriptableObjects;
using UnityEngine;

namespace Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected ItemSettings itemSettings;
        public abstract void OnHit();
    }
}