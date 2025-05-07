using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum IngredientType
    {
        Vegetable,
        Fruit,
        Doll
    }

    public IngredientType ingredientType;
}