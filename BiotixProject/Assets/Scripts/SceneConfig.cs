using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneConfig : MonoBehaviour
{
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
    public void ActiveMenu()
    {
        Time.timeScale = 0;
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




}
