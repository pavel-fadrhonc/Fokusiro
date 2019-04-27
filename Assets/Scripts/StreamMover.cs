using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class StreamMover : MonoBehaviour
    {
        public Transform start;
        public Transform end;

        public float streamSpeed;

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
            _items.Add(item);
        }

        public void RemoveItem(Transform item)
        {
            _items.Remove(item);
        }
    }
}