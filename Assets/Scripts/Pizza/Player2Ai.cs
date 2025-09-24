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
        Flip();

    }
    public void Flip()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        
    }
    public void isOnGround()
    {
        //如果玩家的跳跃计数器为0
        if (Player2FSM.Instance.playerPara.playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //设置跳跃计数器为1
            Player2FSM.Instance.playerPara.jumpCount = 1;
            Player2FSM.Instance.playerPara.anim.SetBool("isGrounded", true);
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
    public void FixWindow()
    {
        // 检查手中是否有物品且物品的tag为Board
        if (PlayerFSM.Instance.playerPara.interactObj != null && 
            PlayerFSM.Instance.playerPara.interactObj.gameObject.CompareTag("Board"))
        {
            if(PlayerFSM.Instance.playerPara.playerCollider.IsTouchingLayers(LayerMask.GetMask("Windows")))
            {
                // 获取与玩家碰撞的所有窗口对象
                List<Collider2D> results = new List<Collider2D>();
                ContactFilter2D filter = new ContactFilter2D();
                filter.layerMask = LayerMask.GetMask("Windows");
                filter.useLayerMask = true;
                
                int count = PlayerFSM.Instance.playerPara.playerCollider.GetContacts(filter, results);
                
                // 遍历所有碰撞的窗口对象，调用其Fix方法
                for (int i = 0; i < count; i++)
                {
                    WinAi winAi = results[i].GetComponent<WinAi>();
                    if (winAi != null)
                    {
                        winAi.Fix();
                        Debug.Log("使用木板修复了窗口: " + results[i].gameObject.name);
                        // 修复后消耗木板（将interactObj设为null并重置pickNum）
                        PlayerFSM.Instance.playerPara.interactObj = null;
                        pickNum = 0;
                        // 只修复第一个碰撞到的窗口
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("没有碰撞到可修复的窗口");
            }
        }
        else
        {
            Debug.Log("手中没有木板，无法修复窗口");
        }
    }
}
