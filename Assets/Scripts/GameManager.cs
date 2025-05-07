using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum GameStatus
{
    OVER,
    ONGOING,
    PAUSED,
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private List<GameObject> objectsToPause;
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameStatus gameStatus;
    
    public static GameManager Instance  { get; private set; }
    
    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
        } 
    }

    public void AddNewObjectToPause(GameObject newObject)
    {
        objectsToPause.Add(newObject);
    }
    
    public void PauseGame()
    {
        gameStatus = GameStatus.PAUSED;
        if (objectsToPause != null && objectsToPause.Count > 0)
        {
            Debug.Log("Pausing Game");
            foreach (var obj in objectsToPause)
            {
                if (obj != null)
                    obj.SetActive(false);
            }
        }
    }

    public void ResumeGame()
    {
        gameStatus = GameStatus.ONGOING;
        if (objectsToPause != null && objectsToPause.Count > 0)
        {
            foreach (var obj in objectsToPause)
            {
                if (obj != null)
                    obj.SetActive(true);
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    private void showVictoryScreen()
    {
        if (victoryScreen == null)
            return;
        victoryScreen.SetActive(true);
        gameStatus = GameStatus.OVER;
    }


}
