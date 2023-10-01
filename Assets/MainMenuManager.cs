using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string firstLevel;

    public void Embark()
    {
        SceneManager.LoadSceneAsync(firstLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
