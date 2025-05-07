using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameManager : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        Debug.Log("Reiniciar o jogo!");
        CouroutineManager.Instance.StartCoroutine(ResetGameCoroutine());
    }

    private IEnumerator ResetGameCoroutine()
    {
        Debug.Log("Starting ResetGameCoroutine...");

        // Load an empty scene as a temporary active scene
        yield return SceneManager.LoadSceneAsync("TemporaryScene", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TemporaryScene"));

        // Unload the game scene
        yield return StartCoroutine(UnloadScene("JogoCorte2"));

        // Wait for a moment
    }

    private IEnumerator UnloadScene(String name)
    {
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(name);
        if (asyncOperation != null)
        {
            while (!asyncOperation.isDone)
            {
                yield return null; // Wait for the next frame
            }
        }
    }
    
}
