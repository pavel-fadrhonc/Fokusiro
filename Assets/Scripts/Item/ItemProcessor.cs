using UnityEngine;

namespace DefaultNamespace
{
    public class ItemProcessor : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.GetComponent<Item>();

            if (item == null)
                return;

            var itemObject = item.ItemObject;
            ProcessItem(itemObject);
        }

        private void ProcessItem(ItemObject item)
        {
            var points = item.ItemAsset.value * 
                         (item.ItemAsset.itemType == ItemAsset.ItemType.Focus ? 1 : -1);

            if (item.ItemAsset.itemType == ItemAsset.ItemType.Distraction)
            {
                GameState.instance.Time += points;
            }

            GameState.instance.Focus += points;

            GameState.instance.Time = Mathf.Clamp(GameState.instance.Time, 0, GameStateContext.instance.MaxTime);
            GameState.instance.Focus = Mathf.Clamp(GameState.instance.Focus, 0, GameStateContext.instance.MaxFocus);            
        }
    }
}