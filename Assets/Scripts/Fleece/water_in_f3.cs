using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_in_f3 : MonoBehaviour
{
    [Header("3楼")]
    public GameObject waterObject_in_f3;
    public float upSpeed_in_f3;
    public float downSpeed_in_f3;
    public float minYPosition_in_f3;
    public float maxYPosition_in_f3;
    public static float targetY_in_f3; // 目标位置

    [Header("2楼")]
    public GameObject waterObject_in_f12;
    public float upSpeed_in_f12;
    public float downSpeed_in_f12;
    public float minYPosition_in_f12;
    public float maxYPosition_in_f12;
    public static float targetY_in_f12; // 目标位置


    public static float targetY;

    public float test;

    //判断房内是否被淹
    public static bool f0_in = false;
    public static bool f1_in = false;
    public static bool f2_in = false;
    public static bool f3_in = false;

    void Start()
    {
        targetY = waterObject_in_f3.transform.position.y;
    }

    void Update()
    {
        //Debug.Log("targetY_in_f3: " + targetY_in_f3);

        #region 判断房内是否被淹
        if (targetY_in_f12 >= 136)
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

        targetY_in_f3 += upSpeed_in_f3 * Time.deltaTime;
        targetY_in_f12 += upSpeed_in_f12 * Time.deltaTime;




        // if (Input.GetKey(KeyCode.W))
        // {
        //     targetY_in_f3 -= downSpeed_in_f3 * Time.deltaTime;
        // }
        // if (Input.GetKey(KeyCode.E))
        // {
        //     targetY_in_f3 += downSpeed_in_f3 * Time.deltaTime;
        //     targetY_in_f12 += downSpeed_in_f12 * Time.deltaTime;

        // }



        // if (Input.GetKey(KeyCode.W) && targetY_in_f3 <= test)
        // {
        //     targetY_in_f12 -= downSpeed_in_f12 * Time.deltaTime;
        // }

        //水位范围
        targetY_in_f3 = Mathf.Clamp(targetY_in_f3, minYPosition_in_f3, maxYPosition_in_f3);

        targetY_in_f12 = Mathf.Clamp(targetY_in_f12, minYPosition_in_f12, maxYPosition_in_f12);

        //平滑移动
        Vector3 newPosition_f3 = waterObject_in_f3.transform.position;
        newPosition_f3.y = Mathf.Lerp(waterObject_in_f3.transform.position.y, targetY_in_f3, Time.deltaTime * 10f);
        waterObject_in_f3.transform.position = newPosition_f3;

        Vector3 newPosition_f12 = waterObject_in_f12.transform.position;
        newPosition_f12.y = Mathf.Lerp(waterObject_in_f12.transform.position.y, targetY_in_f12, Time.deltaTime * 10f);
        waterObject_in_f12.transform.position = newPosition_f12;
    }
}