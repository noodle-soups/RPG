using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float jumpForce;


    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerStateIdle idleState { get; private set; }
    public PlayerStateMove moveState { get; private set; }
    public PlayerStateJump jumpState { get; private set; }
    public PlayerStateAir airState { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerStateIdle(this, stateMachine, "Idle");
        moveState = new PlayerStateMove(this, stateMachine, "Move");
        jumpState = new PlayerStateJump(this, stateMachine, "Jump");
        airState  = new PlayerStateAir(this, stateMachine, "Jump");
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }

}
