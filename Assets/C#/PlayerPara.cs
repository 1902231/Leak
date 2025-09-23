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
    public Rigidbody2D playerRig;
    public BaseInteract interact;

    public int jumpCount;    //跳跃计数器
}
