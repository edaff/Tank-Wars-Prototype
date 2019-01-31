using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] int loadTime = 2;  //change this if you want a longer load time, time is in seconds for exp 2 = 2 seconds
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;   //this will get the current scene using build index

        //load time for next scene from start screen
        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }

    }

    //coroutine for to wait for x ammount of seconds and than load next scene
    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(loadTime);
        LoadNextScene();

    }

    //this function will load the next scene according to the current scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    //this function will be used for quiting out of the game
    public void QuitGame()
    {
        Application.Quit();
    }
    
    //this function will be used for going back to the main menu
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
