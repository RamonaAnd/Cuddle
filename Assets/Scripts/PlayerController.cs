using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector3(joystick.Horizontal * moveSpeed, rigidBody.velocity.y, joystick.Vertical * moveSpeed);
    }
}
