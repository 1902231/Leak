using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class isWin : MonoBehaviour
{
    public GameObject win;
    public GameObject noWin;

    public bool iswin;

    public static float timer; // ���ü�ʱ��Ϊ60��

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // ��ֹ�����л�ʱ��������
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 120f;
        win.SetActive(false); // ��ʼ��ʱ����win����
        noWin.SetActive(false); // ��ʼ��ʱ����noWin����
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (player1O2.isDie1 && player2O2.isDie2 || water_in_f3.f3_in)
        {
            print("�����л�");  
            //noWin.SetActive(true);
            //win.SetActive(false); // ����������㣬ȷ��noWin��ʾ����win����ʾ
            //iswin = false;
            SceneManager.LoadScene("FailureScene");
        }

        
        if(timer < 0) 
        {
            //iswin = true;
            SceneManager.LoadScene("WinScene");

            //win.SetActive(true); // ��ʱ����������win����
            //noWin.SetActive(false); // ȷ��noWin����ʾ
        }
    }
}
