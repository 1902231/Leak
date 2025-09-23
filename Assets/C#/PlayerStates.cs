using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家的Idle状态
/// </summary>
public class PlayerIdleState : BaseState
{
    public override void Enter()
    {
        Debug.Log("玩家进入Idle状态");
    }
    public override void Update()
    {
        //如果按下了移动键
        if (Input.GetAxis("Horizontal") != 0)
        {
            //切换到Move状态
            PlayerFSM.Instance.SwitchState(PlayerEState.Move);
        }
    }
    public override void Exit()
    {
        Debug.Log("玩家退出Idle状态");
    }
}

/// <summary>
/// 玩家的Move状态
/// </summary>
public class PlayerMoveState : BaseState
{
    public override void Enter()
    {
        Debug.Log("玩家进入Move状态");
    }
    public override void Update()
    {
        //调用移动方法
        Move();
        //调用跳跃方法
        Jump();
    }
    public override void Exit()
    {
        Debug.Log("玩家退出Move状态");
    }


    public void Move()
    {
        //获取玩家的移动方向
        float moveDir = Input.GetAxis("Horizontal");

        //根据移动方向和移动速度，设置玩家的速度
        PlayerFSM.Instance.playerPara.playerRig.velocity = new Vector2(moveDir * PlayerFSM.Instance.playerPara.moveSpeed, PlayerFSM.Instance.playerPara.playerRig.velocity.y);
        
    }
    public void Jump()
    {
        //如果按下了跳跃键
        if (Input.GetKey(KeyCode.K) && PlayerFSM.Instance.playerPara.jumpCount > 0)
        {
            //跳跃计数器减一
            PlayerFSM.Instance.playerPara.jumpCount--;
            PlayerFSM.Instance.playerPara.playerRig.velocity = new Vector2(PlayerFSM.Instance.playerPara.playerRig.velocity.x, PlayerFSM.Instance.playerPara.jumpSpeed);
        }
    }
    
}

/// <summary>
/// 玩家的Climb状态
/// </summary>
public class PlayerClimbState : BaseState
{
    public override void Enter()
    {
        Debug.Log("玩家进入Climb状态");
    }
    public override void Update()
    {
        Debug.Log("玩家在Climb状态下更新");
    }
    public override void Exit()
    {
        Debug.Log("玩家退出Climb状态");
    }
}
