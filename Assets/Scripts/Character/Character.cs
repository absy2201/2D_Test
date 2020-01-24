using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum State
    {
        idle,
        walking,
        attacking,
        hurt,
        dead
    }
    public State currState;

    [Header("Health")]
    [SerializeField]
    protected float maxHealth;
    [SerializeField]
    protected float currentHealth;

    [Header("Movement")]
    [SerializeField]
    protected float moveSpeed;
}
