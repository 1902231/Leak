using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_in_f12 : MonoBehaviour
{
    public GameObject waterObject_in_f12;
    public float upSpeed_in_f12;
    public float downSpeed_in_f12;
    public float minYPosition_in_f12;
    public float maxYPosition_in_f12;

    //判断房内是否被淹
    public static bool f0_in = false;
    public static bool f1_in = false;
    public static bool f2_in = false;
    public static bool f3_in = false;

    private static float targetY_in_f12; // 目标位置

    void Start()
    {
        targetY_in_f12 = waterObject_in_f12.transform.position.y;
    }

    void Update()
    {
        //Debug.Log("targetY_in_f12: " + targetY_in_f12);

        #region 判断房内是否被淹
        if(targetY_in_f12 >= 136)
        {
            f0_in = true;
        }
        else
        {
            f0_in = false;
        }

        if (targetY_in_f12 >= 162)
        {
            f1_in = true;
        }
        else
        {
            f1_in = false;
        }

        if (targetY_in_f12 >= maxYPosition_in_f12)
        {
            f2_in = true;
        }
        else
        {
            f2_in = false;
        }
        #endregion
            
        targetY_in_f12 += upSpeed_in_f12 * Time.deltaTime;

        // if (Input.GetKey(KeyCode.W) && water_in_f3.targetY_in_f3 <= 188)
        // {
        //     targetY_in_f12 -= downSpeed_in_f12 * Time.deltaTime;
        // }
        //水位范围
        targetY_in_f12 = Mathf.Clamp(targetY_in_f12, minYPosition_in_f12, maxYPosition_in_f12);

        //平滑移动
        Vector3 newPosition = waterObject_in_f12.transform.position; // 使用position代替anchoredPosition
        newPosition.y = Mathf.Lerp(waterObject_in_f12.transform.position.y, targetY_in_f12, Time.deltaTime * 10f);
        waterObject_in_f12.transform.position = newPosition;
    }
}