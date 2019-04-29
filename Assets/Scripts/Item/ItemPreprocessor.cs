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

        public List<AudioClip> focusAbsorbedClips;
        public List<AudioClip> distractionAbsorbedClips;

        private List<Item> _items = new List<Item>();

        private List<StreamMover> _streamMovers;

        private List<AudioSource> _audioSources;

        private void Awake()
        {
            _streamMovers = new List<StreamMover>(FindObjectsOfType<StreamMover>());
            _audioSources = new List<AudioSource>(GetComponentsInChildren<AudioSource>());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.GetComponent<Item>();
            if (item == null)
                return;
                
            var itemObject = item.ItemObject;
            
            _items.Add(item);
            other.enabled = false;
            item.transform.DOMove(target.position, 1.0f).onComplete += () => PreprocessItem(item);
            PlayRandomItemAbsorbedSound(itemObject.ItemAsset.itemType);
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
                        _streamMovers.ForEach(sm=>sm.RemoveItem(item.transform));
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
                        _streamMovers.ForEach(sm=>sm.RemoveItem(item.transform));
                    };
            }
        }

        private void PlayRandomItemAbsorbedSound(ItemAsset.ItemType itemType)
        {
            for (int i = 0; i < _audioSources.Count; i++)
            {
                var audioS = _audioSources[i];
                if (audioS.isPlaying)
                    continue;

                var clip = itemType == ItemAsset.ItemType.Focus
                    ? focusAbsorbedClips[Random.Range(0, focusAbsorbedClips.Count)]
                    : distractionAbsorbedClips[Random.Range(0, distractionAbsorbedClips.Count)];

                audioS.clip = clip;
                audioS.Play();
                break;
            }
        }
    }
}