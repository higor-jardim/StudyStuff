using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetBase : MonoBehaviour
{
    public void ResetKeys()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
