using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private ItemSpawner itemSpawner;

    public ItemSpawner ItemSpawner => itemSpawner;
}
