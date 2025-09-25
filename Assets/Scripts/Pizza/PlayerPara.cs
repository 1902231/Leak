using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerPara
{
    public float moveSpeed;
    public float jumpSpeed;
    public float O2;
    public Collider2D playerCollider;
    public Collider2D handTrigger;
    public Rigidbody2D playerRig;


    public BaseInteractObject interactObj = null;

    public int jumpCount;    //跳跃计数器
    public Animator anim;
}
