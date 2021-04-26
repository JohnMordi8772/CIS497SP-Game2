/* (John Mordi) 
 * (GameManager) 
 * (Project 6) 
 * (This is the menu system and loading in and out of scenes) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    int currentScene;
    public GameObject mainMenu, pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && currentScene != 0)
        {
            if (!pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void LoadLevel(int sceneIndex)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level ");
            return;
        }
        currentScene = sceneIndex;
        mainMenu.SetActive(false);
    }

    public void UnLoadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currentScene);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level ");
            return;
        }

        currentScene = 0;
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);

    }

    public void RestartLevel()
    {
        int tempLevel = currentScene;
        UnLoadCurrentLevel();
        LoadLevel(tempLevel);
    }
}
