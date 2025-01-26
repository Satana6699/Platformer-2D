using System;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterJump))]
public class MoveHundler : MonoBehaviour
{
    private CharacterMovement _characterMovement;
    private CharacterJump _characterJump;

    private void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _characterJump = GetComponent<CharacterJump>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            _characterJump.Jump();
        }
        
        _characterMovement.MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
        _characterMovement.RotateCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
    }
}
