using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAi : MonoBehaviour
{
    public float health;
    public float fixHealth;
    public Collider2D window;
    public float healthDecayRate; // 每秒减少的生命值


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 随时间减少生命值
        if (health > 0)
        {
            health -= healthDecayRate * Time.deltaTime;
            // 确保生命值不会小于0
            if (health < 0)
            {
                health = 0;
                
            }
        }
    }

    public void Fix()
    {
        health += fixHealth;
    }
    public void Break()
    {   
        
    }
    



}
