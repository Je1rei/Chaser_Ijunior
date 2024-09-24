using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.rigidbody != null)
        {
            hit.rigidbody.velocity = Vector3.zero;
        }
    }
}
