using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2O2 : MonoBehaviour
{
    public Animator playerAnim;
    public Player2Ai player2Ai;
    public static bool isDie2 = false;

    [Tooltip("��ҵ�������ɫ")]
    public Color normalColor = Color.white;

    [Tooltip("�����ľ�ʱ����ɫ")]
    public Color purpleColor = new Color(0.5f, 0f, 0.5f);

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // ��ȡ�ⲿ����ֵ�����Ʒ�Χ
        float o2Value = Mathf.Clamp(Player2FSM.Instance.playerPara.O2, 0f, 100f);

        // �����ֵ������O2=100ʱΪ0��O2=0ʱΪ1��
        float t = 1 - o2Value / 100f;

        // Ӧ����ɫ����
        spriteRenderer.color = Color.Lerp(normalColor, purpleColor, t);

        if (Player2FSM.Instance.playerPara.O2 == 0)
        {
            playerAnim.SetBool("isDie", true);
            player2Ai.enabled = false;
            isDie2 = true;
        }
    }
}