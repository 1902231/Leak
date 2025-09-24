using UnityEngine;
using System.Collections.Generic;

public class BattleCameraController : MonoBehaviour
{
    public List<Transform> targets;//��ȡ����б�
    public float paddingRatio = 0.5f;
    public float minZoom = 2f;//�����С��Χ
    public float maxZoom = 10f;//������Χ
    public float positionSmoothSpeed = 5f;
    public float zoomSmoothSpeed = 5f;

    private Camera mainCamera;
    private Vector3 centerPosition;//���������������
    private float centerSize;//���������������

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        //���㸲��������ҵ���С�����Χ
        CalculateMinMaxPositions(out Vector3 minPos, out Vector3 maxPos);

        //���������������λ��
        centerPosition = (minPos + maxPos) * 0.5f;
        centerPosition.z=transform.position.z;

        //������ϱ�Ե���������Χ��С
        Vector3 boundsSize = maxPos - minPos;
        Vector3 paddedBoundsSize = boundsSize * (1.0f + paddingRatio * 2.0f);

        //����������������
        CalculateDesiredZoom(paddedBoundsSize);

        //ƽ�����ɵ�Ŀ��λ�ú�����
        transform.position = Vector3.Lerp(
            transform.position,
            centerPosition,
            positionSmoothSpeed * Time.deltaTime
        );
        mainCamera.orthographicSize = Mathf.Lerp(
            mainCamera.orthographicSize,
            centerSize,
            zoomSmoothSpeed * Time.deltaTime
        );
    }
    void CalculateMinMaxPositions(out Vector3 minPos, out Vector3 maxPos)//��������������Сλ��
    {
        minPos = new Vector3(float.MaxValue, float.MaxValue, 0);
        maxPos = new Vector3(float.MinValue, float.MinValue, 0);

        foreach (Transform target in targets)
        {
            Vector3 pos = target.position;
            minPos = Vector3.Min(minPos, pos);
            maxPos = Vector3.Max(maxPos, pos);
        }
    }

    void CalculateDesiredZoom(Vector3 paddedBoundsSize)
    {
        //�����ӿ�
        float viewportHeight = mainCamera.orthographicSize * 2;
        float viewportWidth = viewportHeight * mainCamera.aspect;

        //������Ҫ�����ű���
        float zoomRatioX = paddedBoundsSize.x / viewportWidth;
        float zoomRatioY = paddedBoundsSize.y / viewportHeight;
        float maxZoomRatio = Mathf.Max(zoomRatioX, zoomRatioY);

        //�������ŷ�Χ
        centerSize = Mathf.Clamp(
            mainCamera.orthographicSize * maxZoomRatio,
            minZoom,
            maxZoom
        );
    }
}