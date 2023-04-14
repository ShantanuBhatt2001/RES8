using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public void onPlayClick()
    {
        Debug.Log("PlayClick");
        SceneManager.LoadScene(1);
    }
    public void onExit()
    {
        Debug.Log("AppicationQuti");
        Application.Quit();
    }
}
