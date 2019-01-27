using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionsOnClick : MonoBehaviour
{
    
    public void PlayGame()
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "SampleScene1"));
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In,"MainMenu"));
    }

}
