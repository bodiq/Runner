
using Managers;
using Zenject;

namespace Items
{
    public class ObstacleItem : Item
    {
        protected override void OnHit()
        {
            _gameManager.OnCharacterDead?.Invoke();
        }
    }
}
