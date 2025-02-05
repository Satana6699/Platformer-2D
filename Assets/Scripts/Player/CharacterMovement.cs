using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Character movement stats")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    
    [Header("Gravity handling")]
    [SerializeField] private float gravityForce = 9.8f;
    
    public float GravityForce
    {
        set
        {
            if (value >= 0)
            {
                gravityForce = value;
            }
        }
    }
        
    [Header("HeadersComponents")]
    private CharacterController _characterController;
    [HideInInspector] public Vector3 velocityDirection;
        
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        GravityHandling();
    }
    
    public void MoveCharacter(Vector3 moveDirection)
    {
        velocityDirection.x = moveDirection.x * moveSpeed;
        velocityDirection.z = moveDirection.z * moveSpeed;
        _characterController.Move(velocityDirection * Time.deltaTime);
    }
    
    public void RotateCharacter(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection,
                rotateSpeed, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
        
    private void GravityHandling()
    {
        if (!_characterController.isGrounded)
        {
            velocityDirection.y -= gravityForce * Time.deltaTime;
        }
        else
        {
            velocityDirection.y = -0.5f;
        }
    }
}
