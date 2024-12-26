using Managers;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected ItemSettings itemSettings;
        
        [Inject]
        protected GameManager _gameManager;
        
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