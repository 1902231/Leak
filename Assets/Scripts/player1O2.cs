using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class player1O2 : MonoBehaviour
{
    public Animator playerAnim;
    public PlayerAi playerAi;
    public static bool isDie1 = false;

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
        float o2Value = Mathf.Clamp(PlayerFSM.Instance.playerPara.O2, 0f, 100f);

        // �����ֵ������O2=100ʱΪ0��O2=0ʱΪ1��
        float t = 1 - o2Value / 100f;

        // Ӧ����ɫ����
        spriteRenderer.color = Color.Lerp(normalColor, purpleColor, t);

        if(PlayerFSM.Instance.playerPara.O2 == 0)
        {
            playerAnim.SetBool("isDie", true);
            playerAi.enabled = false;
            isDie1 = true;
        }
    }
}