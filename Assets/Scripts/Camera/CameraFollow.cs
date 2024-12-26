using Character;
using UnityEngine;
using Zenject;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        private CharacterMain _player;

        private float _startZOffset;
        
        [Inject]
        private void Construct(CharacterMain player)
        {
            _player = player;
        }

        private void Start()
        {
            _startZOffset = transform.position.z;
        }

        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,  _startZOffset + _player.transform.position.z);
        }
    }
}
