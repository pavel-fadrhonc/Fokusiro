using System.Collections.Generic;
using DG.Tweening;
using Gamekit2D;
using UnityEngine;

namespace DefaultNamespace
{
    public class ItemRemoval : MonoBehaviour
    {
        public List<StreamMover> streamMovers;
        public bool removeOnlyDistractions;
        
        public bool triggerEffect;
        public HitParticlePool effectPool;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.gameObject.GetComponent<Item>();
            if (item == null ||
                (removeOnlyDistractions && item.ItemObject.ItemAsset.itemType == ItemAsset.ItemType.Focus))
                return;
            
            streamMovers.ForEach(sm => sm.RemoveItem(item.transform));
            if (triggerEffect)
            {
                var col = item.GetComponent<Collider2D>();
                col.enabled = false;
                item.transform.DOScale(item.transform.localScale * 4, 1f);
                item.GetComponent<SpriteRenderer>().DOColor(new Color(1f, 1f, 1f, 0f), 1f);
                var ps = effectPool.Pop();
                ps.instance.transform.position = item.transform.position;
            }
            else
            {
                item.ItemObject.ReturnToPool();    
            }
        }
    }
}