using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ItemSpawner : MonoBehaviour
    {
        public List<ItemAsset> assetPool;
        
        public ItemPool itemPool;

        [Tooltip("Next spawn time will get chosen randomly in this span.")]
        public Vector2 randomSpan;

        public Transform spawnPosition;
        public StreamMover streamMover;

        private float _nextSpawnTime;

        private void Awake()
        {
            GenerateNextSpawnTime();   
        }

        private void Update()
        {
            if (Time.time > _nextSpawnTime)
            {
                var item = itemPool.Pop(GetNextAsset());
                item.instance.transform.position = spawnPosition.position;
                streamMover.AddItem(item.instance.transform);
                
                GenerateNextSpawnTime();
            }
        }

        private ItemAsset GetNextAsset()
        {
            return assetPool[Random.Range(0, assetPool.Count)];
        }

        private void GenerateNextSpawnTime()
        {
            _nextSpawnTime = Time.time + Random.Range(randomSpan.x, randomSpan.y);
        }
    }
}