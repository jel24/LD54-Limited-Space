using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResourcePanel : MonoBehaviour
{

    [SerializeField] string victoryLevel;
    [SerializeField] string restartLevel;
    [SerializeField] TriggeredEvent restartEvent;
    public void Victory()
    {
        Invoke("VictoryOnDelay", 2f);

    }

    public void Restart()
    {
        restartEvent.Trigger();
        Invoke("RestartOnDelay", 1f);
    }

    void RestartOnDelay()
    {
        SceneManager.LoadSceneAsync(restartLevel);
    }

    void VictoryOnDelay()
    {
        SceneManager.LoadSceneAsync(victoryLevel);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
