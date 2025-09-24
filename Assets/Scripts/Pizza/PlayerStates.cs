using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家1的Idle状态
/// </summary>
public class Player1IdleState : BaseState
{
    public override void Enter()
    {
        Debug.Log("玩家进入Idle状态");
    }
    public override void Update()
    {
        //如果按下了移动键
        if (Input.GetAxis("Horizontal") != 0 || Input.GetKey(KeyCode.K))
        {
            //切换到Move状态
            PlayerFSM.Instance.SwitchState(PlayerEState.Move);
        }
        //调用爬梯子方法
        Climb();
    }
    public override void Exit()
    {
        Debug.Log("玩家退出Idle状态");
    }


    public void Climb()
    {
        //如果玩家正在爬梯子
        if (PlayerFSM.Instance.playerPara.playerCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {

            if (Input.GetKeyDown(KeyCode.W))
                {
                    //切换到Climb状态
                    PlayerFSM.Instance.SwitchState(PlayerEState.Climb);

                }
                else if (Input.GetKey(KeyCode.S))
                {
                    //切换到Climb状态
                    PlayerFSM.Instance.SwitchState(PlayerEState.Climb);
                }
        }
    }
}

/// <summary>
/// 玩家1的Move状态
/// </summary>
public class Player1MoveState : BaseState
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
        //调用爬梯子方法
        Climb();
    }
    public override void Exit()
    {
        Debug.Log("玩家退出Move状态");
    }


    public void Move()
    {
    
        //获取玩家的移动方向
        float moveDir = Input.GetAxis("Horizontal");
        if (moveDir == 0)
        {
            //如果玩家没有移动方向，将玩家的速度设置为0
            PlayerFSM.Instance.SwitchState(PlayerEState.Idle);
        }
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
    public void Climb()
    {
        //如果玩家正在爬梯子
        if (PlayerFSM.Instance.playerPara.playerCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                //切换到Climb状态
                PlayerFSM.Instance.SwitchState(PlayerEState.Climb);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                //切换到Climb状态
                PlayerFSM.Instance.SwitchState(PlayerEState.Climb);
            }
        }
    }
    
}

/// <summary>
/// 玩家1的Climb状态
/// </summary>
public class Player1ClimbState : BaseState
{
    public override void Enter()
    {
        PlayerFSM.Instance.playerPara.playerRig.gravityScale = 0;
        Debug.Log("玩家进入Climb状态");
    }
    public override void Update()
    {
        Move();
        if (!PlayerFSM.Instance.playerPara.playerCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            //切换到Move状态
            PlayerFSM.Instance.SwitchState(PlayerEState.Move);
        }
        if (Input.GetKey(KeyCode.W))
        {
            PlayerFSM.Instance.playerPara.playerRig.velocity = new Vector2(PlayerFSM.Instance.playerPara.playerRig.velocity.x, PlayerFSM.Instance.playerPara.jumpSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlayerFSM.Instance.playerPara.playerRig.velocity = new Vector2(PlayerFSM.Instance.playerPara.playerRig.velocity.x, -PlayerFSM.Instance.playerPara.jumpSpeed);
        }
        
    }
    public override void Exit()
    {
        PlayerFSM.Instance.playerPara.playerRig.gravityScale = 10;
        Debug.Log("玩家退出Climb状态");
    }


    public void Move()
    {
        //获取玩家的移动方向
        float moveDir = Input.GetAxis("Horizontal");

        //根据移动方向和移动速度，设置玩家的速度
        PlayerFSM.Instance.playerPara.playerRig.velocity = new Vector2(moveDir * PlayerFSM.Instance.playerPara.moveSpeed, PlayerFSM.Instance.playerPara.playerRig.velocity.y);

    }
}

/// <summary>
/// 玩家1的Die状态
/// </summary>
public class Player1DieState : BaseState
{
    public override void Enter()
    {
        Debug.Log("玩家1进入Die状态");
    }
    public override void Update()
    {
        
    }
    public override void Exit()
    {
        Debug.Log("玩家1退出Die状态");
    }
}









/// <summary>
/// 玩家2的Idle状态
/// </summary>
public class Player2IdleState : BaseState
{
    public override void Enter()
    {
        Debug.Log("玩家2进入Idle状态");
    }
    public override void Update()
    {
        //如果按下了移动键
        if (Input.GetAxis("Horizontal2") != 0 || Input.GetKey(KeyCode.Keypad2))
        {
            //切换到Move状态
            Player2FSM.Instance.SwitchState(PlayerEState.Move2);
        }
        //调用爬梯子方法
        Climb();
    }
    public override void Exit()
    {
        Debug.Log("玩家2退出Idle状态");
    }


    public void Climb()
    {
        //如果玩家正在爬梯子
        if (Player2FSM.Instance.playerPara.playerCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))

            {
                //切换到Climb状态
                Player2FSM.Instance.SwitchState(PlayerEState.Climb2);

            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //切换到Climb状态
                Player2FSM.Instance.SwitchState(PlayerEState.Climb2);
            }
        }
    }
}

/// <summary>
/// 玩家2的Move状态
/// </summary>
public class Player2MoveState : BaseState
{
    public override void Enter()
    {
        Debug.Log("玩家2进入Move状态");
    }
    public override void Update()
    {
        //调用移动方法
        Move();
        //调用跳跃方法
        Jump();
        //调用爬梯子方法
        Climb();
    }
    public override void Exit()
    {
        Debug.Log("玩家2退出Move状态");
    }


    public void Move()
    {
    
        //获取玩家的移动方向
        float moveDir = Input.GetAxis("Horizontal2");
        if (moveDir == 0)
        {
            //如果玩家没有移动方向，将玩家的速度设置为0
            Player2FSM.Instance.SwitchState(PlayerEState.Idle2);
        }
        //根据移动方向和移动速度，设置玩家的速度
            Player2FSM.Instance.playerPara.playerRig.velocity = new Vector2(moveDir * Player2FSM.Instance.playerPara.moveSpeed, Player2FSM.Instance.playerPara.playerRig.velocity.y);

    }
    public void Jump()
    {
        //如果按下了跳跃键
        if (Input.GetKey(KeyCode.Keypad2) && Player2FSM.Instance.playerPara.jumpCount > 0)
        {
            //跳跃计数器减一
            Player2FSM.Instance.playerPara.jumpCount--;
            Player2FSM.Instance.playerPara.playerRig.velocity = new Vector2(Player2FSM.Instance.playerPara.playerRig.velocity.x, Player2FSM.Instance.playerPara.jumpSpeed);
        }
    }
    public void Climb()
    {
        //如果玩家正在爬梯子
        if (Player2FSM.Instance.playerPara.playerCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //切换到Climb状态
                Player2FSM.Instance.SwitchState(PlayerEState.Climb2);

            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //切换到Climb状态
                Player2FSM.Instance.SwitchState(PlayerEState.Climb2);
            }
        }
    }
    
}

/// <summary>
/// 玩家2的Climb状态
/// </summary>
public class Player2ClimbState : BaseState
{
    public override void Enter()
    {
        Player2FSM.Instance.playerPara.playerRig.gravityScale = 0;
        Debug.Log("玩家2进入Climb状态");
    }
    public override void Update()
    {
        Move();
        if (!Player2FSM.Instance.playerPara.playerCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            //切换到Move状态
            Player2FSM.Instance.SwitchState(PlayerEState.Move2);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Player2FSM.Instance.playerPara.playerRig.velocity = new Vector2(Player2FSM.Instance.playerPara.playerRig.velocity.x, Player2FSM.Instance.playerPara.jumpSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Player2FSM.Instance.playerPara.playerRig.velocity = new Vector2(Player2FSM.Instance.playerPara.playerRig.velocity.x, -Player2FSM.Instance.playerPara.jumpSpeed);
        }
        
    }
    public override void Exit()
    {
        Player2FSM.Instance.playerPara.playerRig.gravityScale = 10;
        Debug.Log("玩家2退出Climb状态");
    }


    public void Move()
    {
        //获取玩家的移动方向
        float moveDir = Input.GetAxis("Horizontal2");

        //根据移动方向和移动速度，设置玩家的速度
        Player2FSM.Instance.playerPara.playerRig.velocity = new Vector2(moveDir * Player2FSM.Instance.playerPara.moveSpeed, Player2FSM.Instance.playerPara.playerRig.velocity.y);

    }
}

/// <summary>
/// 玩家2的Die状态
/// </summary>
public class Player2DieState : BaseState
{
    public override void Enter()
    {
        Debug.Log("玩家2进入Die状态");
    }
    public override void Update()
    {
        
    }
    public override void Exit()
    {
        Debug.Log("玩家2退出Die状态");
    }
}
