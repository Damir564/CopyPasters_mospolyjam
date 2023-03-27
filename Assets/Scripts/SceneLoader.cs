using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int number)
    {
        if (number == -1)
            Application.Quit();
        else
            SceneManager.LoadScene(number);
    }
}
