using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string firstLevel;
    [SerializeField] TriggeredEvent transitionEvent;

    public void Embark()
    {
        Invoke("LoadAfterDelay", 2f);
        transitionEvent.Trigger();
    }

    void LoadAfterDelay()
    {
        SceneManager.LoadSceneAsync(firstLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
