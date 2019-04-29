using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class PlaceTimeForLevelMarker : MonoBehaviour
    {
        public GameObject marker;
        public Image timeBarFill;

        private void Start()
        {
            var fillWidth = Mathf.Abs(timeBarFill.rectTransform.rect.x);
            //var fillWidth = timeBarFill.rectTransform.anchoredPosition.x;

            Vector3 newPos = timeBarFill.rectTransform.position - (Vector3.right * (fillWidth / 2))
                                        + Vector3.right * fillWidth * 
                                        Locator.Instance.ProjectConstants.FailState;
            newPos.y = marker.transform.position.y;
            marker.transform.position = newPos;
        }
    }
}