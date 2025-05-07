using System;
using System.Collections;
using UnityEngine;

public class CouroutineManager : MonoBehaviour
{
    public static CouroutineManager Instance  { get; private set; }
    
    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
            DontDestroyOnLoad(Instance);
        } 
    }
    
    public void DelayedAction(Action action, float delay)
    {
        StartCoroutine(ExecuteAfterTime(delay, action));
    }

    private IEnumerator ExecuteAfterTime(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        if (action != null)
            action();
    }
}
