using UnityEngine;

[RequireComponent(typeof(RigidbodyMover), typeof(BoxCollider))]
public class Unit : MonoBehaviour
{
    [SerializeField] private Transform _target; 

    private RigidbodyMover _mover;

    private void Awake()
    {
        _mover = GetComponent<RigidbodyMover>();
    }

    private void Start()
    {
        _mover.SetTarget(_target);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 scale = transform.localScale;

        Gizmos.DrawCube(transform.position, new Vector3(scale.x, scale.y, scale.z));
    }
}
