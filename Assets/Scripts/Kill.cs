using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
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
        if(col.gameObject.tag=="Player")
        {
            levelController.LevelReset();
        }
        if(col.gameObject.tag=="Obstacle")
        {
            Destroy(col.gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            levelController.LevelReset();
        }
        
    }
}
