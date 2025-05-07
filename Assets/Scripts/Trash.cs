using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] ScoreManager gameManager;
    [SerializeField] int vegetablePoints = 30;
    [SerializeField] int fruitPoints = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ingredient ingridient))
        {

            if ((int)ingridient.ingredientType == 1)
            {
                gameManager.AddScore(fruitPoints, transform.position);
            }
            else
            {
                gameManager.AddScore(vegetablePoints, transform.position);
            }
        }
    }
}
