using UnityEngine;

namespace Track
{
    public class Road : MonoBehaviour
    {
        [SerializeField] private ItemSpawner itemSpawner;

        public ItemSpawner ItemSpawner => itemSpawner;
    }
}
