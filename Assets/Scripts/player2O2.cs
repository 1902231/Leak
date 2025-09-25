using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2O2 : MonoBehaviour
{
    public Animator playerAnim;
    public Player2Ai player2Ai;
    public static bool isDie2 = false;

    [Tooltip("玩家的正常颜色")]
    public Color normalColor = Color.white;

    [Tooltip("氧气耗尽时的紫色")]
    public Color purpleColor = new Color(0.5f, 0f, 0.5f);

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 获取外部氧气值并限制范围
        float o2Value = Mathf.Clamp(Player2FSM.Instance.playerPara.O2, 0f, 100f);

        // 计算插值比例（O2=100时为0，O2=0时为1）
        float t = 1 - o2Value / 100f;

        // 应用颜色渐变
        spriteRenderer.color = Color.Lerp(normalColor, purpleColor, t);

        if (Player2FSM.Instance.playerPara.O2 == 0)
        {
            playerAnim.SetBool("isDie", true);
            player2Ai.enabled = false;
            isDie2 = true;
        }
    }
}