using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInteractive : MonoBehaviour
{
    public GameObject interactiveObj = null;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("InteractObj"))
        {
            interactiveObj = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("InteractObj"))
        {
            interactiveObj = null;
        }
    }
    

}
