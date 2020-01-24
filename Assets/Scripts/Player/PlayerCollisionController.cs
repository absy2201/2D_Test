using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D solidCollider;
    private CapsuleCollider2D triggerCollider;

    public LayerMask colliderLayerMask;

    private void Awake()
    {
        rigidBody = GetComponentInParent<Rigidbody2D>();
        solidCollider = GetComponent<BoxCollider2D>();
        triggerCollider = GetComponent<CapsuleCollider2D>();
    }

    public void SetVelocity(Vector2 _velocity)
    {
        rigidBody.velocity = _velocity;
    }
}
