using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetChange : MonoBehaviour
{
    // Start is called before the first frame update
    Color originalColor;
    void Start()
    {
        Material mat = GetComponent<Renderer>().material;
        originalColor = mat.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor()
    {
        Debug.Log("change color");
        Material mat = GetComponent<Renderer>().material;
        mat.SetColor("_Color", Color.red);
    }

    public void resetColor()
    {
        Material mat = GetComponent<Renderer>().material;
        mat.SetColor("_Color", originalColor);
    }
}
