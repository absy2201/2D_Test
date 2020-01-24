using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    private void SetPlayerState(State _state)
    {
        currState = _state;
    }

    #region Player Components
    private InputData inputData;
    private PlayerCollisionController playerCollisionController;
    private PlayerAnimationController playerAnimationController;
    private Inventory playerInvetory;
    private InventoryManager playerInventoryManager;
    #endregion

    private Vector2 moveInput;
    private Vector2 facingDirection;

    private void Awake()
    {
        inputData = new InputData();
        playerCollisionController = GetComponentInChildren<PlayerCollisionController>();
        playerAnimationController = GetComponentInChildren<PlayerAnimationController>();
        playerInventoryManager = FindObjectOfType<InventoryManager>();

        inputData.PlayerInput.Movement.performed += _ => moveInput = _.ReadValue<Vector2>();
    }

    private void Start()
    {
        currState = State.idle;
        facingDirection = Vector2.down;

        currentHealth = maxHealth;

        playerInvetory = new Inventory(playerInventoryManager);
        playerInventoryManager.SetInventory(playerInvetory);
    }

    private void OnEnable()
    {
        inputData.Enable();
    }

    private void OnDisable()
    {
        inputData.Disable();
    }

    private void FixedUpdate()
    {
        if(currState == State.idle)
        {
            Idle();
        }
        else if(currState == State.walking)
        {
            Walk();
        }
    }

    public Inventory GetPlayerInventory()
    {
        return playerInvetory;
    }

    #region State Functions
    private void Idle()
    {
        if (moveInput.x != 0 || moveInput.y != 0)
        {
            SetPlayerState(State.walking);
            return;
        }

        playerCollisionController.SetVelocity(Vector2.zero);

        playerAnimationController.SetAnimatorState(currState, facingDirection);
    }

    private void Walk()
    {
        if (moveInput.x == 0 && moveInput.y == 0)
        {
            SetPlayerState(State.idle);
            return;
        }

        playerCollisionController.SetVelocity(moveInput * moveSpeed);
        facingDirection = moveInput;

        playerAnimationController.SetAnimatorState(currState, facingDirection);  
    } 
    #endregion
}