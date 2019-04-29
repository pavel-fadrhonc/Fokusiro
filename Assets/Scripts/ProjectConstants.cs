using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "LD/Project Constants", fileName = "ProjectConstants")]
    public class ProjectConstants : ScriptableObject
    {
        [Tooltip("In world space units")]
        public Vector2 DefaultItemDimensions;

        public float MaxTime;
        public float MaxFocus;
        [Tooltip("[0,1] of maximum focus")] 
        public float StartFocus = 0.5f;
        [Tooltip("[0,1] of maximum focus")] 
        public float FocusAfterFlow = 0.6f;
        [Tooltip("[0,1] of maximum focus")] 
        public float FocusAfterDeplete = 0.4f;

        public float DistractedDuration = 8.0f;
        public float FlowDuration = 8.0f;
        [Tooltip("[0,1] of maximum time has to remain to pass the level.")]
        public float FailState = 0.5f;

        [Tooltip("How long does day last in game in seconds")]
        public float DayDuration = 120f;

        public AudioClip distractionPunchedClip;
        public AudioClip focusPunchedClip;

        [Tooltip("the progress of difficulty in terms of percent during the course of day.")]
        public AnimationCurve progressCurve;
    }
}