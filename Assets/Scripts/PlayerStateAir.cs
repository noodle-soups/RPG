using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAir : PlayerState
{
    public PlayerStateAir(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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
        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
