using UnityEngine;
using System.Collections.Generic;

public class BattleCameraController : MonoBehaviour
{
    public List<Transform> targets;//获取玩家列表
    public float paddingRatio = 0.5f;
    public float minZoom = 2f;//相机最小范围
    public float maxZoom = 10f;//相机最大范围
    public float positionSmoothSpeed = 5f;
    public float zoomSmoothSpeed = 5f;

    private Camera mainCamera;
    private Vector3 centerPosition;//期望的摄像机中心
    private float centerSize;//期望的摄像机缩放

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        //计算覆盖所有玩家的最小和最大范围
        CalculateMinMaxPositions(out Vector3 minPos, out Vector3 maxPos);

        //计算期望的摄像机位置
        centerPosition = (minPos + maxPos) * 0.5f;

        //计算加上边缘的摄像机范围大小
        Vector3 boundsSize = maxPos - minPos;
        Vector3 paddedBoundsSize = boundsSize * (1.0f + paddingRatio * 2.0f);

        //根计算期望的缩放
        CalculateDesiredZoom(paddedBoundsSize);

        //平滑过渡到目标位置和缩放
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
    void CalculateMinMaxPositions(out Vector3 minPos, out Vector3 maxPos)//计算摄像机最大最小位置
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
        //计算视口
        float viewportHeight = mainCamera.orthographicSize * 2;
        float viewportWidth = viewportHeight * mainCamera.aspect;

        //计算需要的缩放比例
        float zoomRatioX = paddedBoundsSize.x / viewportWidth;
        float zoomRatioY = paddedBoundsSize.y / viewportHeight;
        float maxZoomRatio = Mathf.Max(zoomRatioX, zoomRatioY);

        //限制缩放范围
        centerSize = Mathf.Clamp(
            mainCamera.orthographicSize * maxZoomRatio,
            minZoom,
            maxZoom
        );
    }
}