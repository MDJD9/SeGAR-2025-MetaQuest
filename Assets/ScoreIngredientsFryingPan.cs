using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresIngredientsFryingPan : MonoBehaviour
{
    private float whiskTimer;
    public float whiskTotalTime = 10f;
    public GameObject progressBarBatter;
    public GameObject progressBarPancake;
    public float progressBarMultiplier;
    public GameObject enablesBatter;
    public GameObject enablePancake;
    public GameObject disablePancakeText;
    private bool whisking = false;

    private GameObject ingredient;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ingredient = PrototypeGame.Instance.GetNextIngredient();
        GameObject progressBar = ingredient.CompareTag("Batter") ? progressBarBatter : progressBarPancake;
        
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
                if (ingredient.CompareTag("Batter"))
                {
                    Destroy(enablesBatter);
                    enablePancake.SetActive(true);
                    whiskTimer = 0;
                } else if (ingredient.CompareTag("Pancake"))
                {
                    disablePancakeText.SetActive(false);
                    whisking=false;
                    whiskTimer = 0;
                }
                PrototypeGame.Instance.goToNextIngredient();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject nextIngredient = PrototypeGame.Instance.GetNextIngredient();
        if (other.gameObject.CompareTag(nextIngredient.tag))
        {
            if (nextIngredient.CompareTag("Batter") || nextIngredient.CompareTag("Pancake"))
            {
                whisking = true;
                GameObject progressBar = null;
                if (nextIngredient.CompareTag("Batter"))
                {
                    progressBar = progressBarBatter;
                } else if (nextIngredient.CompareTag("Pancake"))
                {
                    progressBarBatter.SetActive(false);
                    progressBar = progressBarPancake;
                };
                if (progressBar != null)
                    progressBar.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject nextIngredient = PrototypeGame.Instance.GetNextIngredient();
        if (whisking)
        {
            whisking = false;
            GameObject progressBar = null;
            if (nextIngredient.CompareTag("Batter"))
            {
                progressBar = progressBarBatter;
            } else if (nextIngredient.CompareTag("Pancake"))
            {
                progressBarBatter.SetActive(false);
                progressBar = progressBarPancake;
            };
            if (progressBar != null)
                progressBar.SetActive(false);
        }
    }
}
