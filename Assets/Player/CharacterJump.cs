using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterMovement))]
public class CharacterJump : MonoBehaviour
{
    [Header("Jump stats")]
    [SerializeField] private float maxJumpTime = 2f;
    [SerializeField] private float maxJumpHeight = 2f;
    private float _startJumpVelocity;

    [Header("Character components")] 
    private CharacterMovement _characterMovement;
    private CharacterController _characterController;

    private void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _characterController = GetComponent<CharacterController>();
        
        float maxHeightTime = maxJumpTime / 2;
        _characterMovement.GravityForce = (2 * maxJumpHeight) / Mathf.Pow(maxHeightTime, 2);
        _startJumpVelocity = (2 * maxJumpHeight) / maxJumpTime;
    }

    public void Jump()
    {
        if (_characterController.isGrounded)
        {
            _characterMovement.velocityDirection.y = _startJumpVelocity;
        }
    }
}