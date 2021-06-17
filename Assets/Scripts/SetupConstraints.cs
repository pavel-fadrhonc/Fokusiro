using System;
using UnityEngine;
using UnityEngine.Animations;

namespace DefaultNamespace
{
    public class SetupConstraints : MonoBehaviour
    {
        private void Start()
        {
            var ninjaTransform = GameObject.FindGameObjectWithTag("Ninja").transform.GetChild(0).transform;
            
            foreach (var constraint in GetComponents<IConstraint>())
            {
                constraint.AddSource(new ConstraintSource()
                {
                    sourceTransform = ninjaTransform,
                    weight = 1.0f
                });
            }
        }
    }
}