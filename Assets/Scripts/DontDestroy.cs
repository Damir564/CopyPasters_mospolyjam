using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] private string whereToBeDestroyed;
    [SerializeField] private float timeToBeAlive = 2f;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

     private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = next.name;

        if (currentName == whereToBeDestroyed)
        {
            Destroy(this.gameObject, timeToBeAlive);
        } 
    }

}
