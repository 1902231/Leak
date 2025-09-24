using UnityEngine;

public class BaseInteractObject : MonoBehaviour
{
    public string interactName;
    public Rigidbody2D rigid;
    public Transform target;
    public float followSpeed = 5f;

    // public bool IsHold { get; private set; } = false;//标记物品状态

    // private Transform originalTransform;

    // public System.Action OnPickUp;//拿起物品事件
    // public System.Action OnDrop;//放下物品事件

    public void PickUp(Transform target)//拾取物品函数
    {
        this.target = target;
        rigid.gravityScale = 0;


        // originalTransform = holdTransform;

        // transform.SetParent(holdTransform);
        // transform.localPosition = Vector2.zero;

        // var obj_Collider = GetComponent<Collider2D>();
        // if (obj_Collider != null)
        //     obj_Collider.enabled = false;

        // var obj_Rigidbody = GetComponent<Rigidbody2D>();
        // if (obj_Rigidbody != null)
        //     obj_Rigidbody.isKinematic = true;

        // IsHold = true;
        // OnPickUp?.Invoke();


    }

    public void Drop()//放下物品函数
    {
        
        if (target != null)
        {
            target = null;
            rigid.gravityScale = 1;
        }


        // if(originalTransform!=null)
        // {
        //     transform.position = originalTransform.position;
        // }
        // transform.SetParent(null);//设置成原始状态

        // var obj_Collider = GetComponent<Collider2D>();
        // if (obj_Collider != null)
        //     obj_Collider.enabled = true;

        // var obj_Rigidbody = GetComponent<Rigidbody2D>();
        // if (obj_Rigidbody != null)
        //     obj_Rigidbody.isKinematic = false;

        // IsHold = false;
        // OnDrop?.Invoke();
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
        }
        
    }
}