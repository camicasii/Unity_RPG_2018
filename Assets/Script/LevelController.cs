using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController: MonoBehaviour
{
    public void NextLevel(GameObject player)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex; 
        int nextScene = ++currentScene;                
        SceneManager.LoadScene(nextScene);               
        
    }
}
