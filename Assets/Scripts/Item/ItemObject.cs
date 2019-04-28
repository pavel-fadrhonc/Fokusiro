using System;
using Gamekit2D;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class ItemObject : PoolObject<ItemPool, ItemObject, ItemAsset>
    {
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _boxCollider2D;

        private ItemAsset _itemAsset;
        public ItemAsset ItemAsset => _itemAsset;
        
        private Item _item;
        
        protected override void SetReferences()
        {
            _spriteRenderer = instance.GetComponent<SpriteRenderer>();
            _boxCollider2D = instance.GetComponent<BoxCollider2D>();
            _item = instance.GetComponent<Item>();
            _item.ItemObject = this;
        }

        public override void WakeUp(ItemAsset asset)
        {
            base.WakeUp();

            instance.transform.localScale = Vector3.one;
            instance.transform.rotation = Quaternion.identity;
            _spriteRenderer.sprite = asset.sprite;

            float scale = 0f;
            if (_spriteRenderer.bounds.size.x > _spriteRenderer.bounds.size.y)
            {
                scale = Locator.Instance.ProjectConstants.DefaultItemDimensions.x / _spriteRenderer.bounds.size.x;
            }
            else
            {
                scale = Locator.Instance.ProjectConstants.DefaultItemDimensions.y / _spriteRenderer.bounds.size.y;
            }
            instance.transform.localScale = new Vector3(scale, scale, 1);
            instance.gameObject.SetActive(true);
            _boxCollider2D.size = new Vector2(Locator.Instance.ProjectConstants.DefaultItemDimensions.x / scale,
                Locator.Instance.ProjectConstants.DefaultItemDimensions.y / scale);
            _boxCollider2D.enabled = true;
            _spriteRenderer.color = Color.white;
            
            _itemAsset = asset;
        }

        public override void Sleep()
        {
            instance.gameObject.SetActive(false);
        }
    }
}