using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresIngredients : MonoBehaviour
{
    private float whiskTimer;
    public float whiskTotalTime = 10f;
    public GameObject progressBar;
    public float progressBarMultiplier;
    public GameObject enablesBatter;
    public GameObject enablePancake;
    private bool whisking = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (whisking)
        {
            whiskTimer += Time.deltaTime;
            Vector3 scale = progressBar.transform.localScale;
            
            scale.x += progressBarMultiplier * Time.deltaTime;
            progressBar.transform.localScale = scale;

            if (whiskTimer >= whiskTotalTime)
            {
                whisking = false;
                progressBar.SetActive(false);
                PrototypeGame.Instance.playScoringEffect();
                PrototypeGame.Instance.goToNextIngredient();
                if (!CompareTag("Pan"))
                    enablesBatter.SetActive(true);
                else
                {
                    Destroy(enablesBatter);
                    enablePancake.SetActive(true);
                    whiskTimer = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Batter") && !CompareTag("Pan"))
            return;
        
        GameObject nextIngredient = PrototypeGame.Instance.GetNextIngredient();
        if (other.gameObject.CompareTag(nextIngredient.tag))
        {
            if (!nextIngredient.CompareTag("Whisker") && !nextIngredient.CompareTag("Batter") && !nextIngredient.CompareTag("Pancake"))
            {
                Debug.Log(nextIngredient.name);
                PrototypeGame.Instance.playScoringEffect();
                Destroy(nextIngredient);
                PrototypeGame.Instance.goToNextIngredient();
                return;
            }

            whisking = true;
            progressBar.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject nextIngredient = PrototypeGame.Instance.GetNextIngredient();
        if (whisking && other.gameObject.CompareTag("Whisker"))
        {
            whisking = false;
            progressBar.SetActive(false);
        }
    }
}
