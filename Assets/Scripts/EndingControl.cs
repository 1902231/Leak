using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingControl : MonoBehaviour
{
    public bool isWin;
    public GameObject vectory;
    public GameObject failure;

    // Start is called before the first frame update
    void Start()
    {
        if (isWin)
        { 
            vectory.SetActive(true);
            failure.SetActive(false);
        }
        if (!isWin)
        {
            vectory.SetActive(false);
            failure.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
