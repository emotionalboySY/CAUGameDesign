using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadButtonManager : MonoBehaviour
{
    public string sceneName = "Lobby";
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
