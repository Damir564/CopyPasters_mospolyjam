using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScene : MonoBehaviour
{
    public void loadSceneTwo()
    {
        SceneManager.LoadScene(1);
    }

    public void loadSceneTree()
    {
        SceneManager.LoadScene(2);
    }
}
