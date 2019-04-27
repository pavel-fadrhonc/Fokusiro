using UnityEngine;

namespace DefaultNamespace
{
    public class Locator : GameSingleton<Locator>
    {
        [SerializeField]
        private ProjectConstants _projectConstants;
        public ProjectConstants ProjectConstants { get => _projectConstants; }
    }
}