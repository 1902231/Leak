using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAi : MonoBehaviour
{
    public PlayerPara para;
    public Transform target;
    public CheckInteractive checkInteractive;
    public int pickNum;//手中道具的计数器

    void Start()
    {
        PlayerFSM.Instance.playerPara = para;

        //添加状态
        PlayerFSM.Instance.AddState(PlayerEState.Idle, new Player1IdleState());
        PlayerFSM.Instance.AddState(PlayerEState.Move, new Player1MoveState());
        PlayerFSM.Instance.AddState(PlayerEState.Climb, new Player1ClimbState());

        //切换状态
        
        PlayerFSM.Instance.SwitchState(PlayerEState.Idle);
        
    }
    void Update()
    {
        //更新当前状态
        if (PlayerFSM.Instance.currentState != null) 
        {
            PlayerFSM.Instance.currentState.Update();
            Debug.Log(PlayerFSM.Instance.currentEState);

        }
        isOnGround();
        Interactive();
        DropObj();

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
    public void Interactive()
    {
        if (this.name == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.J))
            {

                if (checkInteractive.interactiveObj && pickNum < 1)
                {
                    pickNum++;
                    checkInteractive.interactiveObj.GetComponent<BaseInteractObject>().PickUp(target);
                    PlayerFSM.Instance.playerPara.interactObj = checkInteractive.interactiveObj.GetComponent<BaseInteractObject>();
                }

            }
        }
        
        

    }
    public void DropObj()
    {
        if (this.name == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.U))
            {

                PlayerFSM.Instance.playerPara.interactObj?.Drop();
                pickNum = 0;
                PlayerFSM.Instance.playerPara.interactObj = null;

            }
        }
        
        
    }
    



    
}