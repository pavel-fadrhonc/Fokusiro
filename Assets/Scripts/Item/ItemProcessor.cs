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

        public void ProcessItem(ItemObject item)
        {
            var points = item.ItemAsset.value;

            if (item.ItemAsset.itemType == ItemAsset.ItemType.Distraction)
            {
                GameStats.instance.Time -= points;
                GameStats.instance.Focus -= points * Locator.Instance.ProjectConstants.DistractionFocusPointMultiplicator;
            }
            else
            {
                GameStats.instance.Focus += points;                
            }
        }
    }
}