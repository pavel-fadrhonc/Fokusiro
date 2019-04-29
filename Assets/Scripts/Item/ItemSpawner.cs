using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    [Serializable]
    public class WieghtedItemAsset
    {
        public ItemAsset asset;
        public float weight = 1.0f;
        public Vector2 Range { get; set; }
    }
    
    public class ItemSpawner : MonoBehaviour
    {
        public List<WieghtedItemAsset> assetPool;
        
        public ItemPool itemPool;

        [Tooltip("Next spawn time will get chosen randomly in this span.")]
        public Vector2 randomSpan;

        public Transform spawnPosition;
        public StreamMover streamMover;

        private float _nextSpawnTime;
        private float _assetWeightTotal;

        private void Awake()
        {
            GenerateNextSpawnTime();
            RecalculateRanges();
            
            GameEvents.instance.TimesUp += OnTimesUpHandler;
            GameEvents.instance.TimeEatenByDistractions += OnTimeEatenByDistractionsHandler;
        }

        private void OnTimeEatenByDistractionsHandler()
        {
            streamMover.Items.ForEach(it => it.GetComponent<Item>().ItemObject.ReturnToPool());
            enabled = false;            
        }

        private void OnTimesUpHandler()
        {
            streamMover.Items.ForEach(it => it.GetComponent<Item>().ItemObject.ReturnToPool());
            enabled = false;
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

        private void RecalculateRanges()
        {
            _assetWeightTotal = assetPool.Sum(wa => wa.weight);
            
            float rangeStart = 0;
            for (int i = 0; i < assetPool.Count; i++)
            {
                var item = assetPool[i];
                item.Range = new Vector2(rangeStart, rangeStart + item.weight);

                rangeStart = item.Range.y;
            }
        }
        
        private ItemAsset GetNextAsset()
        {
            var rand = Random.Range(0, _assetWeightTotal);
            var asset = assetPool.Find(wa => rand > wa.Range.x && rand < wa.Range.y);
            
            return asset.asset;
        }

        private void GenerateNextSpawnTime()
        {
            _nextSpawnTime = _nextSpawnTime + Random.Range(randomSpan.x, randomSpan.y);
        }
    }
}