using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SurfaceSlider : MonoBehaviour
{
    [SerializeField] private float _stepUpSpeed = 0.5f;

    private Vector3 _normal;
    private Vector3 _climbOffset;

    private void OnCollisionEnter(Collision collision)
    {
        _normal = collision.contacts[0].normal;

        if(collision.collider.TryGetComponent(out Stairs _))
        {
            _climbOffset = Vector3.up * _stepUpSpeed;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Stairs _))
        {
            _climbOffset = Vector3.zero;
        }
    }

    public Vector3 Project(Vector3 forward)
    {
        Vector3 projected = forward - Vector3.Dot(forward, _normal) * _normal;

        projected += _climbOffset;

        return projected;
    }
}