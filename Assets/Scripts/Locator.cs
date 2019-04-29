using UnityEngine;

namespace DefaultNamespace
{
    public class Locator : SceneSingleton<Locator>
    {
        [SerializeField]
        private ProjectConstants _projectConstants;
        public ProjectConstants ProjectConstants { get => _projectConstants; }
    }
}