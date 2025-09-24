using UnityEngine;

public class Water_out : MonoBehaviour
{
    public GameObject waterObject_out;
    public float upSpeed_out;
    public float downSpeed_out;
    public float minYPosition_out;
    public float maxYPosition_out;

    //�ж�ˮ�͵��ڼ���
    public static bool f0_out = true;
    public static bool f1_out = false;
    public static bool f2_out = false;
    public static bool f3_out = false;

    public float waveChance_out; //���������ĸ���
    public float waveStrength_out; //��������
    public float minWaveInterval_out; //��С�������

    private static float targetY_out; // Ŀ��λ��
    private float lastWaveTime_out; // �ϴβ���ʱ��

    void Start()
    {
        targetY_out = waterObject_out.transform.position.y;
        lastWaveTime_out = Time.time;
    }

    void Update()
    {
        //Debug.Log("targetY_out: " + targetY_out);

        targetY_out += upSpeed_out * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
        {
            targetY_out -= downSpeed_out * Time.deltaTime;
        }

        #region �жϺ�ˮ�͵���
        if (targetY_out  >= 145)
        {
            f1_out = true;
        }
        else
        {
            f1_out = false;
        }

        if(targetY_out  >= 175)
        {
            f2_out = true;
        }
        else
        {
            f2_out = false;
        }

        if(targetY_out >= 200)
        {
            f3_out = true;
        }
        else
        {
            f3_out = false;
        }
        #endregion

        //����С�����,�����������
        if (Time.time - lastWaveTime_out > minWaveInterval_out && Random.value < waveChance_out)
        {
            targetY_out -= Random.Range(waveStrength_out * 0.5f, waveStrength_out);
            lastWaveTime_out = Time.time;
        }

        //ˮλ��Χ
        targetY_out = Mathf.Clamp(targetY_out, minYPosition_out, maxYPosition_out);

        //ƽ���ƶ�
        Vector3 newPosition = waterObject_out.transform.position; // ʹ��position����anchoredPosition
        newPosition.y = Mathf.Lerp(waterObject_out.transform.position.y, targetY_out, Time.deltaTime * 10f);
        waterObject_out.transform.position = newPosition;
    }
}
