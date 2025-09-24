using UnityEngine;

public class Water_out : MonoBehaviour
{
    [Header("屋外水面")]
    public GameObject waterObject_out;
    public float upSpeed_out;
    public float downSpeed_out;
    public float minYPosition_out;
    public float maxYPosition_out;

    [Header("屋外水面上升速度系数")]
    public float upSpeed_out_f0false;
    public float upSpeed_out_f0true;

    //判断水淹到第几层
    public static bool f0_out = true;
    public static bool f1_out = false;
    public static bool f2_out = false;
    public static bool f3_out = false;

    // 波动
    public float waveInterval_out;   // 波动间隔时间（秒）
    public float waveStrength_out;   // 每次波动下降的幅度

    public static float targetY_out;     // 目标位置
    private float waveTimer_out;          // 波动计时器

    void Start()
    {
        targetY_out = waterObject_out.transform.position.y;
        waveTimer_out = 0;
    }

    void Update()
    {
        // 上升趋势
        if(!water_in_f3.f0_in)
        {
            targetY_out += upSpeed_out * upSpeed_out_f0false * Time.deltaTime;
        }
        else
        {
            targetY_out += upSpeed_out * -upSpeed_out_f0true * Time.deltaTime;
        }

        // Q键控制下降
        if (Input.GetKey(KeyCode.Q))
        {
            targetY_out -= downSpeed_out * Time.deltaTime;
        }

        #region 判断洪水淹到哪
        if (targetY_out >= 145)
        {
            f1_out = true;
        }
        else
        {
            f1_out = false;
        }

        if (targetY_out >= 175)
        {
            f2_out = true;
        }
        else
        {
            f2_out = false;
        }

        if (targetY_out >= 200)
        {
            f3_out = true;
        }
        else
        {
            f3_out = false;
        }
        #endregion

        waveTimer_out += Time.deltaTime;// 定时触发波动
        if (waveTimer_out >= waveInterval_out)
        {
            targetY_out -= waveStrength_out;// 到了间隔时间，让水面微微下降
            waveTimer_out = 0;
        }

        // 限制水位范围
        targetY_out = Mathf.Clamp(targetY_out, minYPosition_out, maxYPosition_out);

        // 平滑移动
        Vector3 newPosition = waterObject_out.transform.position;
        newPosition.y = Mathf.Lerp(waterObject_out.transform.position.y, targetY_out, Time.deltaTime * 10f);
        waterObject_out.transform.position = newPosition;
    }
}