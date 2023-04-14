using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPos : MonoBehaviour
{
    
    public float speed;
    float distanceTravelled=0;
    public bool isControllable=true;
    public bool isInteractable=false;
    public LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
           
            if(isInteractable)
            {
                gameObject.layer=1;
            }
            else{
                gameObject.layer=10;
            }
    }
    void FixedUpdate()
    {
        if(isControllable)
        transform.position= new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<ResetObject>())
        {
            Debug.Log("Name"+col.gameObject.name);
            if(col.gameObject.GetComponent<ResetObject>().isRewindable && col.gameObject.GetComponent<ResetObject>().enabled)
            {
                levelController.PlayRewind();
                col.gameObject.GetComponent<ResetObject>().StartRewind();
            }
        }
        if(col.gameObject.tag=="Player")
        {
            if(!isControllable && isInteractable)
            {
                Debug.Log("Sendhelp");
                isControllable=true;
                gameObject.GetComponent<Animator>().enabled=false;
                isInteractable=false;
                transform.localScale=new Vector3(1f,1f,1f);
            }
        }
    }
}
