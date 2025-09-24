using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class StartSceneCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mosPos;
    Vector3 worldPos;

    void Start()
    {
        mosPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(mosPos);
    }

    // Update is called once per frame
    void Update()
    {
        mosPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mosPos.x, mosPos.y, -1));
        this.transform.Translate(new Vector3(worldPos.x,worldPos.y,0)*-1.5f*Time.deltaTime);

        if (this.transform.position.x>=0.3) 
        {
            this.transform.position = new Vector3(0.3f, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x <= -0.3)
        {
            this.transform.position = new Vector3(-0.3f, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.y >= 0.3)
        {
            this.transform.position = new Vector3(this.transform.position.x, 0.3f, this.transform.position.z);
        }
        if (this.transform.position.y <= -0.3)
        {
            this.transform.position = new Vector3(this.transform.position.x, -0.3f, this.transform.position.z);
        }
    }
}
