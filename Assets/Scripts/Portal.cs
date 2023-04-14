using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool Active=false;
    public LevelController levelController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Player" && Active)
        {
            StartCoroutine(levelController.EndLevel());
        }
        
    }
    void OnTriggerStay2D(Collider2D col)
    {
         if(col.gameObject.tag=="Player" && Active)
        {
            StartCoroutine(levelController.EndLevel());
        }
    }
}
