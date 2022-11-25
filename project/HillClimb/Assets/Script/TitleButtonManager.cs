using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    public string sceneName = "Lobby";
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
