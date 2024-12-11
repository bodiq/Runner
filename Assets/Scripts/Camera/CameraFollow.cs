using Character;
using Managers;
using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        private CharacterMain _player;

        private float _startZOffset;

        private void Start()
        {
            _startZOffset = transform.position.z;
            _player = GameManager.Instance.Character;
        }

        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,  _startZOffset + _player.transform.position.z);
        }
    }
}
