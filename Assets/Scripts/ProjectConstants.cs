using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "LD/Project Constants", fileName = "ProjectConstants")]
    public class ProjectConstants : ScriptableObject
    {
        [Tooltip("In world space units")]
        public Vector2 DefaultItemDimensions;
    }
}