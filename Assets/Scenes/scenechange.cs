using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mission1()
    {
        /*Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Debug.Log(sceneName);*/
        //SceneManager.UnloadSceneAsync(sceneName);
        SceneManager.LoadScene("Mission 1");
        
    }
    public void mission2()
    {
        /*Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Debug.Log(sceneName);*/
        //SceneManager.UnloadSceneAsync(sceneName);
        SceneManager.LoadScene("Mission 2");
    }

    public void mainmenu()
    {
        /*Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Debug.Log(sceneName);*/
        //SceneManager.UnloadSceneAsync(sceneName);
        SceneManager.LoadScene("Menu");
    }
}
