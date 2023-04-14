using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathField : MonoBehaviour
{
    public LevelController levelController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Player")
        {
                levelController.LevelReset();
        }
        else if(col.gameObject.tag=="Mob")
        {
            Destroy(col.gameObject);
        }
    }
}
