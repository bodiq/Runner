using System.Collections.Generic;
using Character;
using Managers;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private Road trackPrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private int trackPoolSize = 5; 

    private Queue<Road> trackPool = new();
    private float trackLength; // Довжина одного сегмента
    private int plateIndex = 1;
    
    private CharacterMain _player;

    private void Start()
    {
        trackLength = trackPrefab.gameObject.GetComponent<Renderer>().bounds.size.z; // Довжина сегмента
        _player = GameManager.Instance.Character;
        PrewarmTracks();
    }

    private void Update()
    {
        if (_player.transform.position.z >= trackLength * plateIndex)
        {
            SpawnTrack();
        }
    }

    private void PrewarmTracks()
    {
        for (int i = 0; i < trackPoolSize; i++)
        {
            var track = Instantiate(trackPrefab, new Vector3(0, 0, i * trackLength), Quaternion.identity, parent);
            trackPool.Enqueue(track);
        }
        
        plateIndex = 1;
    }

    private void SpawnTrack()
    {
        var track = trackPool.Dequeue();

        track.transform.position += new Vector3(0, 0, trackLength * trackPoolSize);
        track.ItemSpawner.SpawnItems();
        
        plateIndex++;
        trackPool.Enqueue(track);
    }
}