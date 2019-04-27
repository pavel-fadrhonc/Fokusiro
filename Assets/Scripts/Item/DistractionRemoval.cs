using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class DistractionRemoval : MonoBehaviour
    {
        public List<StreamMover> streamMovers;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.gameObject.GetComponent<Item>();
            if (item == null || item.ItemObject.ItemAsset.itemType == ItemAsset.ItemType.Focus)
                return;
            
            streamMovers.ForEach(sm => sm.RemoveItem(item.transform));
            item.ItemObject.ReturnToPool();
        }
    }
}