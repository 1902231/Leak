using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }
    // 在Awake方法中实现单例逻辑
    void Awake()
    {
        if (_instance == null)
        {
            // 如果实例不存在，设置为当前实例
            _instance = this;
            // 可选：防止场景切换时销毁此对象
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 如果实例已存在，销毁当前重复对象
            Destroy(gameObject);
        }
    }





    public int brokeWinNum;
    public float upSpeed;
    public float upRate_Win;//每一个打破的窗口增加水位上涨的速率
    public water_in_f3 water_in_f3;
    public Transform BoardProducer;//木板生成点
    public float boardProduceTime;//木板生成间隔
    private float boardProduceTimer = 0;//木板生成计时器
    public GameObject boardPrefab;//木板预制体



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetUpSpeed();
        ProduceBoard();
    }


    public void SetUpSpeed()
    {
        upSpeed = brokeWinNum * upRate_Win;
        water_in_f3.upSpeed_in_f12 = upSpeed;
        water_in_f3.upSpeed_in_f3 = upSpeed;
    }
    public void ProduceBoard()
    {
        boardProduceTimer += Time.deltaTime;
        if (boardProduceTimer >= boardProduceTime)
        {
            boardProduceTimer = 0;
            GameObject board = Instantiate(boardPrefab, BoardProducer.position, Quaternion.identity);
        }
    }
}
