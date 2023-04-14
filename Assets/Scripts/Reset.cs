using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Vector3 initVelocity;
    public Vector3 initPosition;
    Rigidbody2D rb;
    public float delay;
    public bool canReset=true;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        initVelocity=rb.velocity;
        initPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
            ResetPos();
    }

    public void ResetPos()
    {
       StartCoroutine(BufferReset());
    }



    IEnumerator BufferReset()
    {
        transform.Translate(initPosition-transform.position, Space.World);
        rb.velocity=initVelocity;
        rb.isKinematic=true;
        canReset=false;
        yield return new WaitForSeconds(delay);
        rb.isKinematic=false;
        canReset=true;
    }
}
