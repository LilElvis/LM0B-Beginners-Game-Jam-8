using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunctions : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel(int levelNumber)
    {
        GameData.CurrentLevelSelection = levelNumber;
        SceneManager.LoadScene("MainGame");
    }

    public void EnableGameObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void DisableGameObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
