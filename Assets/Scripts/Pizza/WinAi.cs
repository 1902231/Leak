using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAi : MonoBehaviour
{

    public float health;
    public float fixHealth;
    public Collider2D window;
    

    public float healthDecayRate; // 每秒减少的生命值
    public PlayerAi playerAi;
    public Player2Ai player2Ai;
    public float floodLevel;//窗户开始扣血的水位
    private int breakTimes = 1;
    public Animator anim;
    
    
    

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("WinAi health: " + health);
        //Debug.Log("WinAi health: " + health);

        // 确保生命值不会小于0,大于10
        if (health > 10)
        {
            health = 10;
        }
        if (health < 0)
        {
            health = 0;

        }
        if(breakTimes < 0)
        {
            breakTimes = 0;
        }
        if (breakTimes > 1)
        {
            breakTimes = 1;
        }



        if (health <= 0)
            {
                
                Break();
            }


        if (health > 0)
        {
            
            if (Water_out.targetY_out >= floodLevel)
            {
                health -= healthDecayRate * Time.deltaTime;//随时间减少生命值
            }
        }

        
        
        

        
        
        
    }

    public void Fix()
    {
        health += fixHealth;

    }
    public void Break()
    {
        if(breakTimes > 0)
        {
            anim.SetBool("isBreak", true);
            GameManager.Instance.brokeWinNum++;
            breakTimes--;
        }

    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            if (PlayerFSM.Instance.playerPara.interactObj == null)
            {
                return;
            }
            if (PlayerFSM.Instance.playerPara.interactObj.CompareTag("Board"))
            {

                if (Input.GetKeyDown(KeyCode.I))
                {
                    if (health > 0)
                    {
                        Fix();
                    }
                    else if (health <= 0)
                    {
                        Fix();
                        GameManager.Instance.brokeWinNum--;
                        breakTimes++;
                        anim.SetBool("isBreak", false);
                    }
                    
                    Destroy(playerAi.para.interactObj.gameObject);
                    playerAi.pickNum = 0;
                }

            }
        }
        else if (other.CompareTag("Player2"))
        {
            if (Player2FSM.Instance.playerPara.interactObj == null)
            {
                return;
            }
            if (Player2FSM.Instance.playerPara.interactObj.CompareTag("Board"))
            {
                if (Input.GetKeyDown(KeyCode.Keypad5))
                {
                    if (health > 0)
                    {
                        Fix();
                    }
                    else if (health <= 0)
                    {
                        Fix();
                        GameManager.Instance.brokeWinNum--;
                        breakTimes++;
                        anim.SetBool("isBreak", false);
                    }
                    Destroy(player2Ai.para.interactObj.gameObject);
                    player2Ai.pickNum = 0;
                }

            }
        }



    }

    



}
