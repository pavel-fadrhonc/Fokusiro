using DG.Tweening;
using Gamekit2D;
using UnityEngine;

namespace DefaultNamespace
{
    public class HitParticle : PoolObject<HitParticlePool, HitParticle>
    {
        private ParticleSystem _ps; 
        
        protected override void SetReferences()
        {
            base.SetReferences();

            _ps = instance.GetComponent<ParticleSystem>();
        }

        public override void WakeUp()
        {
            base.WakeUp();
            
            _ps.Play();

            // just to time non-MB class
            instance.transform.DOScale(instance.transform.localScale, 1f).onComplete += this.ReturnToPool;
        }

        public override void Sleep()
        {
            base.Sleep();
            
            _ps.Stop();
        }
    }
}