using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingControl : MonoBehaviour
{
    
    public bool isWinning;
    public GameObject vectory;
    public GameObject failure;

    // Start is called before the first frame update
    void Start()
    {
        if (isWinning)
        { 
            vectory.SetActive(true);
            failure.SetActive(false);
        }
        if (!isWinning)
        {
            vectory.SetActive(false);
            failure.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("isWin")!= null)
        { 
            print("’“µΩ¡ÀisWin");   
        }
        isWinning = GameObject.Find("isWin").GetComponent<isWin>().iswin;
    }
}
