using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeGame : MonoBehaviour
{
    public static PrototypeGame Instance { get; private set; }

    public List<GameObject> ingredients = new List<GameObject>();
    public GameObject nextIngredient;
    
    public AudioClip pointsScored;
    public AudioSource audioSource;
    public GameObject scoreEffect;
    public GameObject secondScoreEffect;
    public float scoreTime;
    
    private float timer;
    private bool scoring = false;
    private void Awake()
    {
        // Singleton enforcement
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Kill duplicate
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: persist across scenes
    }

    // Start is called before the first frame update
    void Start()
    {
        goToNextIngredient();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoring)
        {
            timer += Time.deltaTime;
            if (timer >= scoreTime)
            {
                scoring = false;
                scoreEffect.SetActive(false);
                return;
            }
            
        }
        
    }

    public GameObject GetNextIngredient() { return nextIngredient; }
    
    public bool hasIngredients() { return ingredients.Count > 0; }
    
    public void goToNextIngredient()
    {
        if (ingredients.Count <= 0)
            return;
        
        nextIngredient = ingredients[0];
        ingredients.RemoveAt(0);
        if (nextIngredient.CompareTag("Batter"))
        {
            scoreEffect.SetActive(false);
            scoreEffect = secondScoreEffect;
        }
    }
    
    public void playScoringSound()
    {
        audioSource.clip = pointsScored;
        audioSource.Play();
    }

    public void playScoringEffect()
    {
        scoring = true;
        timer = 0;
        playScoringSound();
        scoreEffect.SetActive(true);
    }
}