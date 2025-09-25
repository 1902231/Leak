using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class isWin : MonoBehaviour
{
    public GameObject win;
    public GameObject noWin;

    public bool iswin;

    private float timer; // 设置计时器为60秒

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 防止场景切换时对象销毁
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
        win.SetActive(false); // 初始化时禁用win对象
        noWin.SetActive(false); // 初始化时禁用noWin对象
    }

    // Update is called once per frame
    void Update()
    {
        if (player1O2.isDie1 && player2O2.isDie2 || water_in_f3.f3_in)
        {
            print("场景切换");  
            //noWin.SetActive(true);
            //win.SetActive(false); // 如果条件满足，确保noWin显示并且win不显示
            iswin = false;
            SceneManager.LoadScene("EndScene");
        }
        else
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime; // 每帧减少时间
            }
            else
            {
                iswin = true;
                SceneManager.LoadScene("EndScene");

                //win.SetActive(true); // 计时结束，激活win对象
                //noWin.SetActive(false); // 确保noWin不显示
            }
        }
    }
}
