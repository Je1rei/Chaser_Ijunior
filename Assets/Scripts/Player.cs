using UnityEngine;

[RequireComponent(typeof(CharacterControllerMover), typeof(CollisionDetector))]
public class Player : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    private CharacterControllerMover _mover;

    private void Awake()
    {
        _mover = GetComponent<CharacterControllerMover>();
    }

    private void Update()
    {
        Vector3 playerInput = new Vector3(Input.GetAxis(HorizontalInput), 0, Input.GetAxis(VerticalInput));
        _mover.SetMoveDirection(playerInput);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 scale = transform.localScale;

        Gizmos.DrawCube(transform.position, new Vector3(scale.x, scale.y, scale.z));
    }
}
