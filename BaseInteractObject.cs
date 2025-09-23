using UnityEngine;

public class BaseInteractObject : MonoBehaviour
{
    public bool IsHold { get; private set; } = false;//�����Ʒ״̬

    private Transform originalTransform;

    public System.Action OnPickUp;//������Ʒ�¼�
    public System.Action OnDrop;//������Ʒ�¼�

    public void PickUp(Transform holdTransform)//ʰȡ��Ʒ����
    {
        originalTransform = holdTransform;

        transform.SetParent(holdTransform);
        transform.localPosition = Vector2.zero;

        var obj_Collider = GetComponent<Collider2D>();
        if (obj_Collider != null)
            obj_Collider.enabled = false;

        var obj_Rigidbody = GetComponent<Rigidbody2D>();
        if (obj_Rigidbody != null)
            obj_Rigidbody.isKinematic = true;

        IsHold = true;
        OnPickUp?.Invoke();
    }

    public void Drop()//������Ʒ����
    {
        if(originalTransform!=null)
        {
            transform.position = originalTransform.position;
        }
        transform.SetParent(null);//���ó�ԭʼ״̬

        var obj_Collider = GetComponent<Collider2D>();
        if (obj_Collider != null)
            obj_Collider.enabled = true;

        var obj_Rigidbody = GetComponent<Rigidbody2D>();
        if (obj_Rigidbody != null)
            obj_Rigidbody.isKinematic = false;

        IsHold = false;
        OnDrop?.Invoke();
    }
}