using Managers;

namespace Items
{
    public class ObstacleItem : Item
    {
        protected override void OnHit()
        {
            GameManager.Instance.OnCharacterDead?.Invoke();
        }
    }
}
