using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        new WaitForSecondsRealtime(2.0f);
     SceneManager.LoadScene("JogoCorte2", LoadSceneMode.Single);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
