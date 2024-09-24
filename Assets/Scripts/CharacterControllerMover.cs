using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private float _fallSpeed = 10f;

    private CharacterController _characterController;
    private float _gravityMultiplier = 1f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void SetMoveDirection(Vector3 direction)
    {
        if (_characterController.isGrounded)
            Move(direction, _movementSpeed);
        else
            Move(direction, _fallSpeed);
    }

    private void Move(Vector3 direction, float speed)
    {
        direction.y -= _gravityMultiplier;

        _characterController.Move(speed * Time.deltaTime * direction.normalized);
    }
}