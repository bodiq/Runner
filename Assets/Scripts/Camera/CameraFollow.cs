using Character;
using UnityEngine;
using Zenject;

namespace Camera
{
    public sealed class CameraFollow : ILateTickable, IInitializable
    {
        private CharacterMain _player;
        private UnityEngine.Camera _camera;

        private float _startZOffset;
        
        private CameraFollow(CharacterMain player, UnityEngine.Camera camera)
        {
            _player = player;
            _camera = camera;
        }

        public void Initialize()
        {
            _startZOffset = _camera.transform.position.z;
        }

        public void LateTick()
        {
            _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y,  _startZOffset + _player.transform.position.z);
        }
    }
}
