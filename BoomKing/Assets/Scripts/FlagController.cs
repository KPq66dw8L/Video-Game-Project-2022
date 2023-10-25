using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagController : MonoBehaviour
{
    private bool touchedFlag = false;
    private bool lastLevel = false;
    private string currentSceneName;
    private bool tutorial = false;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
        if (currentSceneName == "Level2")
        {
            lastLevel = true;
        }
        else
        {
            lastLevel = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (touchedFlag && currentSceneName == "Tutorial")
        {
            SceneManager.LoadScene("Menu");
            tutorial = true;
        }
        if (touchedFlag && !lastLevel && !tutorial)
        {
            char numOfLevel = currentSceneName[currentSceneName.Length - 1];
            string nextScene = "Level" + ((numOfLevel - '0') + 1);
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            if (touchedFlag && lastLevel)
            {
                Application.Quit();
                //UnityEditor.EditorApplication.isPlaying = false;
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            touchedFlag = true;
        }
    }

}
