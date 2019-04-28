using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class ItemPreprocessor : MonoBehaviour
    {
        public Transform target;
        public ParticleSystem focusPS;
        public ParticleSystem distractionPS;
        public ItemProcessor itemProcessor;

        private List<Item> _items = new List<Item>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.GetComponent<Item>();
            if (item == null)
                return;
                
            var itemObject = item.ItemObject;
            
            _items.Add(item);
            other.enabled = false;
            item.transform.DOMove(target.position, 1.0f).onComplete += () => PreprocessItem(item);
        }

        private void PreprocessItem(Item item)
        {
            item.transform.DOKill();
                    
            // initiate ps and animation based on type
            if (item.ItemObject.ItemAsset.itemType == ItemAsset.ItemType.Focus)
            {
                focusPS.Stop();
                focusPS.Play();
                item.transform.DOScale(Vector3.zero, 1f);
                
                item.transform.DOMove(item.transform.position + Vector3.down * 0.2f, 1f).onComplete += 
                    () =>
                    {
                        itemProcessor.ProcessItem(item.ItemObject);
                        item.ItemObject.ReturnToPool();
                    };
            }
            else
            {
                distractionPS.Stop();
                distractionPS.Play();
                item.transform.DOScale(item.transform.localScale * 4, 1f);
                item.GetComponent<SpriteRenderer>().DOColor(new Color(1f, 1f, 1f, 0f), 1f);
                item.transform.DOMove(item.transform.position + Vector3.down * 0.2f, 1f).onComplete +=
                    () =>
                    {
                        itemProcessor.ProcessItem(item.ItemObject); 
                        item.ItemObject.ReturnToPool();
                    };
            }
        }
    }
}