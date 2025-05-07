using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject scoreIndicatorPrefab;

    public void AddScore(int points, Vector3 position)
    {
        score += points;
        scoreText.text = score.ToString();
        ScoreIndicator scoreIndicator = Instantiate(scoreIndicatorPrefab, position, Quaternion.identity).GetComponent<ScoreIndicator>();
        scoreIndicator.SetPointsText(points, position);
        Debug.Log("Tens " + score + " pontos.");
    }
}
