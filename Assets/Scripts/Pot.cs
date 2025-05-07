using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] ScoreManager gameManager;
    [SerializeField] int vegetablePoints = 30;
    [SerializeField] int fruitPoints = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ingredient ingridient))
        {
            if (ingridient.ingredientType == 0)
            {
                gameManager.AddScore(vegetablePoints, transform.position);
            }
            else
            {
                gameManager.AddScore(fruitPoints, transform.position);
            }
        }
    }
}
