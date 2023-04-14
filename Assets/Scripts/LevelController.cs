using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{


    public GameObject CountText;
    public GameObject HintText;
    private CanvasGroup canvasGroup,HintcanvasGroup;
    public GameObject OnPortal;
    public GameObject Ring;
    public GameObject Player;
    public CharacterController2D pcontroller;
    public AudioClip rewind;
    public AudioSource Source;
    
    int collected=0;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup=CountText.GetComponent<CanvasGroup>();
        HintcanvasGroup=HintText.GetComponent<CanvasGroup>();
        if(SceneManager.GetActiveScene().name=="Level 2")
        {
            Ring.GetComponent<RingPos>().isControllable=false;
            StartCoroutine(MakeInteractable());
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeInteractable()
    {
        
        Ring.GetComponent<RingPos>().isInteractable=true;
        float alpha1 = HintText.GetComponent<SpriteRenderer>().color.a;
     for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 2)
     {
         Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha1,1f,t));
         HintText.GetComponent<SpriteRenderer>().color = newColor;
         yield return null;
     }
            }
    
    public void LevelReset()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);

        if(col.gameObject.tag=="Player")
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Collected()
    {
        if(collected==0)
        {
            StartCoroutine(ShowCountAnim());
        }
        collected++;
        
        CountText.GetComponent<Text>().text="Shards Collected:"+collected;
        if(collected==10)
        {
            StartCoroutine(ShowCollected());
        }
    }

    IEnumerator ShowCountAnim()
    {
        
     for (float t = 0.0f; t < 1.0f; t += Time.deltaTime/2 )
     {
         canvasGroup.alpha=Mathf.Lerp(canvasGroup.alpha,1f,t);
         
         yield return null;
     }
    }


    IEnumerator ShowCollected()
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime )
     {
         canvasGroup.alpha=Mathf.Lerp(canvasGroup.alpha,0f,t);
         
         yield return null;
     }
      CountText.GetComponent<Text>().text="All Shards Collected";
      

      for (float t = 0.0f; t < 1.0f; t += Time.deltaTime )
     {
         canvasGroup.alpha=Mathf.Lerp(canvasGroup.alpha,1f,t);
         
         yield return null;
     }
        OnPortal.GetComponent<AudioSource>().Play();
     float alpha = OnPortal.GetComponent<SpriteRenderer>().color.a;
     for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 2)
     {
         Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,1f,t));
         OnPortal.GetComponent<SpriteRenderer>().color = newColor;
         yield return null;
     }
     OnPortal.GetComponent<Portal>().Active=true;
    }

    public IEnumerator EndLevel()
    {
        pcontroller.canMove=false;
        float alpha = Player.GetComponent<SpriteRenderer>().color.a;
     for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 2)
     {
         Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,0f,t));
         Player.GetComponent<SpriteRenderer>().color = newColor;
         yield return null;
     }

    if(SceneManager.GetActiveScene().buildIndex==3)
    {
        SceneManager.LoadScene(0);

    }
    else
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);


    }


    public void PlayRewind()
    {
        Source.clip=rewind;
        Source.Play();
    }


    public void BackClick()
    {
        SceneManager.LoadScene(0);
    }
    
}
