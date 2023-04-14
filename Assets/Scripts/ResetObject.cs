using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    public  Vector3 initVelocity;
    public bool isRewinding=false;
    public bool isRewindable=true;
    int count=1;
    Vector3 initPos;
    List<Vector3> positions;
    List<Quaternion> Rotations;
     public float initAngularSpeed;
    Rigidbody2D rb;
    public float delay;
    void Start()
    {
        positions= new List<Vector3>();
        Rotations=new List<Quaternion>();
        
        rb=GetComponent<Rigidbody2D>();
        rb.velocity=initVelocity;
        initPos=transform.position;
        rb.angularVelocity=initAngularSpeed;
        initVelocity=rb.velocity;
        initAngularSpeed=rb.angularVelocity;
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
            StartRewind();
        
    }


    void FixedUpdate()
    {
        if(isRewinding)
            Rewind();
        else
            Record();
    }


    void Record()
    {
        count++;
        if(count>3)
        {
            if(positions.Count>0 && transform.position!=positions[0])
            {
                positions.Insert(0,transform.position);
            Rotations.Insert(0,transform.rotation);
            }
            else if(positions.Count==0)
            {
                positions.Insert(0,transform.position);
            Rotations.Insert(0,transform.rotation);
            }
            
            count=1;
            Debug.Log(gameObject.name+positions.Count);
        }
        
          
        

    }


    void Rewind()
    {
        if(positions.Count>0)
        {
            transform.position=positions[0];
            transform.rotation=Rotations[0];
            positions.RemoveAt(0);
            Rotations.RemoveAt(0);
        }
        else
        StopRewind();
        
    }

    public void StartRewind()
    {
        isRewinding=true;
        isRewindable=false;
        rb.isKinematic=true;
    }
   

   void StopRewind()
   {
        isRewinding=false;
        rb.velocity=Vector3.zero;
        rb.angularVelocity=0;
        transform.position=initPos;
        StartCoroutine(ResetKinematic());
   }


   IEnumerator ResetKinematic()
   {
       yield return new WaitForSeconds(delay);
       isRewindable=true;
       rb.isKinematic=false;
       rb.velocity=initVelocity;
        rb.angularVelocity=initAngularSpeed;
       
   }
}
