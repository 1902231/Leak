using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Ai : MonoBehaviour
{
    public PlayerPara para;
    public Transform target;
    public CheckInteractive checkInteractive;
    public int pickNum;//手中道具的计数器



    void Start()
    {
        Player2FSM.Instance.playerPara = para;

        //添加玩家2的状态
        Player2FSM.Instance.AddState(PlayerEState.Idle2, new Player2IdleState());
        Player2FSM.Instance.AddState(PlayerEState.Move2, new Player2MoveState());
        Player2FSM.Instance.AddState(PlayerEState.Climb2, new Player2ClimbState());
        //切换状态
        Player2FSM.Instance.SwitchState(PlayerEState.Idle2);
        
    }
    void Update()
    {
        //更新当前状态
        if (Player2FSM.Instance.currentState != null) 
        {
            Player2FSM.Instance.currentState.Update();
            Debug.Log(Player2FSM.Instance.currentEState);

        }
        isOnGround();
        Interactive();
        DropObj();

    }
    public void isOnGround()
    {
        //如果玩家的跳跃计数器为0
        if (Player2FSM.Instance.playerPara.playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //设置跳跃计数器为1
            Player2FSM.Instance.playerPara.jumpCount = 1;
        }
    }
    public void Interactive()
    {
        
        if(this.name == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {

                if (checkInteractive.interactiveObj && pickNum < 1)
                {
                    pickNum++;
                    checkInteractive.interactiveObj.GetComponent<BaseInteractObject>().PickUp(target);
                    Player2FSM.Instance.playerPara.interactObj = checkInteractive.interactiveObj.GetComponent<BaseInteractObject>();
                }

            }
        }
        

    }
    public void DropObj()
    {
        if(this.name == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {

                Player2FSM.Instance.playerPara.interactObj?.Drop();
                pickNum = 0;
                Player2FSM.Instance.playerPara.interactObj = null;

            }
        }
        
    }
    
}
