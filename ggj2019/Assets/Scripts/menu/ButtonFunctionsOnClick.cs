using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionsOnClick : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene1");
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
