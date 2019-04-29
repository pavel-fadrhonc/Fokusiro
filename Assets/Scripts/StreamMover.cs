using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class StreamMover : MonoBehaviour
    {
        public Transform start;
        public Transform end;

        public float streamSpeed;

        public List<Transform> Items
        {
            get => _items;
        }

        private List<Transform> _items = new List<Transform>();
        private void Update()
        {
            foreach (var item in _items)
            {
                item.transform.position +=
                    streamSpeed * Time.deltaTime * (end.position - start.position).normalized;
            }
        }

        public void AddItem(Transform item)
        {
            if (_items.Contains(item))
                return;
            
            _items.Add(item);
        }

        public void RemoveItem(Transform item)
        {
            _items.Remove(item);
        }

    }
}