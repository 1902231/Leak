using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public List<GameObject> p;
    public GameObject btn;
    private int i=0;
    // Start is called before the first frame update
    void Start()
    {
        p.Add(p1);
        p.Add(p2);
        p.Add(p3);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            p[i].gameObject.SetActive(false);
            i++;
            
        }
        if(i>2)
        {
            btn.gameObject.SetActive(true);
            p[0].gameObject.SetActive(true);
            p[1].gameObject.SetActive(true);
            p[2].gameObject.SetActive(true);
            i = 0;
        }
    }
}
