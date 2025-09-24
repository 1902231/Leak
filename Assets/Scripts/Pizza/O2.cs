using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2 : MonoBehaviour
{
    public Collider2D water_12f;
    public Collider2D water_3f;
    private Collider2D head;
    // 添加氧气消耗速率（每秒消耗的氧气量）
    public float o2ConsumptionRate = 10f;
    // 添加氧气恢复速率（每秒恢复的氧气量）
    public float o2RecoveryRate = 5f;
    private float o2Timer = 0f;
    
    // 氧气最大值（可以根据需要调整）
    public float maxO2 = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        head = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (head.IsTouchingLayers(LayerMask.GetMask("Flood")))
        {
            // 累加计时器
            o2Timer += Time.deltaTime;

            // 计算应该扣除的氧气值
            float o2ToDeduct = o2ConsumptionRate * Time.deltaTime;

            // 在扣除前添加判断是否名称为"Player1"
            if (gameObject.transform.parent.name == "Player1")
            {
                // 扣除氧气
                PlayerFSM.Instance.playerPara.O2 -= o2ToDeduct;

                // 确保氧气值不会低于0
                if (PlayerFSM.Instance.playerPara.O2 < 0)
                {
                    PlayerFSM.Instance.playerPara.O2 = 0;
                }
            }
            else if (gameObject.transform.parent.name == "Player2")
            {
                // 扣除氧气
                Player2FSM.Instance.playerPara.O2 -= o2ToDeduct;

                // 确保氧气值不会低于0
                if (Player2FSM.Instance.playerPara.O2 < 0)
                {
                    Player2FSM.Instance.playerPara.O2 = 0;
                }
            }
        }
        else
        {
            // 不在水中时重置计时器
            o2Timer = 0f;
            
            // 自动恢复氧气
            RecoverO2(o2RecoveryRate * Time.deltaTime);
        }
    }
    
    /// <summary>
    /// 恢复指定数量的氧气
    /// </summary>
    /// <param name="amount">要恢复的氧气量</param>
    public void RecoverO2(float amount)
    {
        if (gameObject.transform.parent.name == "Player1")
        {
            // 恢复氧气
            PlayerFSM.Instance.playerPara.O2 += amount;
            
            // 确保氧气值不会超过最大值
            if (PlayerFSM.Instance.playerPara.O2 > maxO2)
            {
                PlayerFSM.Instance.playerPara.O2 = maxO2;
            }
        }
        else if (gameObject.transform.parent.name == "Player2")
        {
            // 恢复氧气
            Player2FSM.Instance.playerPara.O2 += amount;
            
            // 确保氧气值不会超过最大值
            if (Player2FSM.Instance.playerPara.O2 > maxO2)
            {
                Player2FSM.Instance.playerPara.O2 = maxO2;
            }
        }
    }
    
    /// <summary>
    /// 立即充满氧气
    /// </summary>
    public void FillO2()
    {
        if (gameObject.transform.parent.name == "Player1")
        {
            PlayerFSM.Instance.playerPara.O2 = maxO2;
        }
        else if (gameObject.transform.parent.name == "Player2")
        {
            Player2FSM.Instance.playerPara.O2 = maxO2;
        }
    }
}