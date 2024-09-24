using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SurfaceSlider))]
public class RigidbodyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private float _overlapDistance = 2.5f;

    private Rigidbody _rigidbody;
    private Transform _currentTarget;
    private Coroutine _currentCoroutine;
    private SurfaceSlider _surfaceSlider;

    public bool IsWalk { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _surfaceSlider = GetComponent<SurfaceSlider>();
        IsWalk = false;
    }

    public void SetTarget(Transform target)
    {
        _currentTarget = target;

        if (_currentTarget != null)
        {
            SetupMove();
        }
    }

    private void SetupMove()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (_currentTarget != null)
        {
            MoveTo(_currentTarget);

            yield return new WaitForFixedUpdate();
        }
    }

    public void MoveTo(Transform target)
    {
        if (IsTargetReached(target) == false)
        {
            IsWalk = true;

            Vector3 direction = (target.position - transform.position).normalized;
            Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);

            transform.LookAt(target);
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
        else if (IsTargetReached(target))
        {
            IsWalk = false; 
        }
    }

    private bool IsTargetReached(Transform target)
    {
        return transform.position.IsEnoughClose(new Vector3(target.position.x, target.position.y, target.position.z), _overlapDistance);
    }
}
