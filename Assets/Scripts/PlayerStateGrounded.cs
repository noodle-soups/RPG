using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateGrounded : PlayerState
{
    public PlayerStateGrounded(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // maintain air state after air dash
        if (!player.IsGroundDetected())
            stateMachine.ChangeState(player.airState);

        // jump state
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected())
            stateMachine.ChangeState(player.jumpState);
    }
}
