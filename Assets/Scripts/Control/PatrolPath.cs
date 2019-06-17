using UnityEngine;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                const float waypointGizmoRadius = .2f;
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(transform.GetChild(i).position, waypointGizmoRadius);
            }
        }
    }
}
