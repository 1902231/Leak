using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAi : MonoBehaviour
{
    public PlayerPara para;
    public Transform handTrans;
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
    public void PickObj()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && PlayerFSM.Instance.playerPara.handTrigger.IsTouchingLayers(LayerMask.GetMask("InteractObj")))
        {
            // 获取所有碰撞到的物体
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("InteractObj"));
        List<Collider2D> results = new List<Collider2D>();
        
        // 获取碰撞到的物体数量
        int count = PlayerFSM.Instance.playerPara.handTrigger.GetContacts(filter, results);
        
        if(count > 0)
        {
            // 获取第一个碰撞到的物体
            GameObject obj = results[0].gameObject;
            Debug.Log("Collided with: " + obj.name);

            // 调用物品的PickUp方法
            BaseInteractObject interactObj = obj.GetComponent<BaseInteractObject>();
                if (interactObj != null)
                {
                    interactObj.PickUp(handTrans);
                }
            }
        }
        
    }
}
