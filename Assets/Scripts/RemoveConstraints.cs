using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveConstraints : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("What");
        if(col.gameObject.tag=="Mob")
        {
            gameObject.GetComponent<ResetObject>().enabled=true;
            rb.constraints=RigidbodyConstraints2D.None;
            rb.constraints=RigidbodyConstraints2D.FreezePositionX;
            rb.constraints=RigidbodyConstraints2D.FreezeRotation;
            
            
        }
    }
}
