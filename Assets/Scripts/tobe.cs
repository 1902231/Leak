using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tobe : MonoBehaviour
{
    public Sprite tube0_;
    public Sprite tube1_;
    public float decreaseY;
    

    private SpriteRenderer spriteRenderer;
    private bool isFull = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider.IsTouchingLayers(LayerMask.GetMask("Flood")))
        {
            if (!isFull)
            {
                Debug.Log(water_in_f3.targetY);
                spriteRenderer.sprite = tube1_;
                isFull = true;


                water_in_f3.targetY_in_f3 -= decreaseY;

                if (water_in_f3.targetY_in_f3 <= 190.4)
                {
                    water_in_f3.targetY_in_f12 -= decreaseY;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.O) && isFull && this.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("OffPoint_Tube")))
        {
            spriteRenderer.sprite = tube0_;
            isFull = false;

        }
        if (Input.GetKeyDown(KeyCode.Keypad6) && isFull && this.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("OffPoint_Tube")))
        {
            spriteRenderer.sprite = tube0_;
            isFull = false;
            
        }
    }
}