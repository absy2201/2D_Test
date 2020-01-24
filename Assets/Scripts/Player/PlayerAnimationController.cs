using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimatorState(PlayerController.State _state, Vector2 _facingDirection)
    {
        switch(_state)
        {
            case PlayerController.State.idle:
                break;
            case PlayerController.State.walking:
                break;
            case PlayerController.State.attacking:
                break;
            case PlayerController.State.hurt:
                break;
            case PlayerController.State.dead:
                break;
        }
    }
}
