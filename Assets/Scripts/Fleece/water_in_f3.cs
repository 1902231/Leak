using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_in_f3 : MonoBehaviour
{
    public GameObject waterObject_in_f3;
    public float upSpeed_in_f3;
    public float downSpeed_in_f3;
    public float minYPosition_in_f3;
    public float maxYPosition_in_f3;

    public static float targetY_in_f3; // 目标位置

    void Start()
    {
        targetY_in_f3 = waterObject_in_f3.transform.position.y;
    }

    void Update()
    {
        //Debug.Log("targetY_in_f3: " + targetY_in_f3);

        targetY_in_f3 += upSpeed_in_f3 * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            targetY_in_f3 -= downSpeed_in_f3 * Time.deltaTime;
        }

        //水位范围
        targetY_in_f3 = Mathf.Clamp(targetY_in_f3, minYPosition_in_f3, maxYPosition_in_f3);

        //平滑移动
        Vector3 newPosition = waterObject_in_f3.transform.position; // 使用position代替anchoredPosition
        newPosition.y = Mathf.Lerp(waterObject_in_f3.transform.position.y, targetY_in_f3, Time.deltaTime * 10f);
        waterObject_in_f3.transform.position = newPosition;
    }
}
