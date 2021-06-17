using UnityEngine;

namespace DefaultNamespace
{
    public class Locator : SceneSingleton<Locator>
    {
        [SerializeField]
        private ProjectConstants _projectConstants;
        public ProjectConstants ProjectConstants { get => _projectConstants; }
        
        public HitParticlePool HitEffectPool { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            HitEffectPool = GameObject.FindGameObjectWithTag("HitEffectPool").GetComponent<HitParticlePool>();
        }
    }
}