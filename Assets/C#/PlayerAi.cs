using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAi : MonoBehaviour
{
    public PlayerPara para;
    void Start()
    {
        PlayerFSM.Instance.playerPara = para;

        //添加状态
        PlayerFSM.Instance.AddState(PlayerEState.Idle, new PlayerIdleState());
        PlayerFSM.Instance.AddState(PlayerEState.Move, new PlayerMoveState());
        PlayerFSM.Instance.AddState(PlayerEState.Climb, new PlayerClimbState());
        //切换状态
        PlayerFSM.Instance.SwitchState(PlayerEState.Idle);
    }
    void Update()
    {
        //更新当前状态
        if (PlayerFSM.Instance.currentState != null)
        {
            PlayerFSM.Instance.currentState.Update();

        }
        isOnGround();
    }
    public void isOnGround()
    {
        //如果玩家的跳跃计数器为0
        if (PlayerFSM.Instance.playerPara.playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //设置跳跃计数器为1
            PlayerFSM.Instance.playerPara.jumpCount = 1;
        }
    }
}
