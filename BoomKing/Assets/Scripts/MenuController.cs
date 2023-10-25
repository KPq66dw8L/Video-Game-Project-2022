using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{ public void QuitApplication()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
