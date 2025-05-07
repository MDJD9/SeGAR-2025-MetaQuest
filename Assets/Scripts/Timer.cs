using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //start time value 
    [SerializeField] float startTime = 45f;

    [SerializeField] private GameObject restartObject;
    // current time
    float beginTime;
    private bool timerStarted = false;

    [SerializeField] TMP_Text timerText;

    void Start()
    {
        timerStarted = true;
        beginTime = 0;
    }

    void Awake()
    {
        beginTime = 0;
        timerStarted = true;
    }

    public void StartTimer(float time)
    {
        beginTime = Time.timeSinceLevelLoad;
        timerStarted = true;
    }

    public void StopTimer()
    {
        timerStarted = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(timerStarted)
        {
            beginTime += Time.deltaTime;
            var displayTime = startTime - beginTime; 
            if(displayTime <= 0)
            {
                displayTime = 0;
                restartObject.SetActive(true);
                timerStarted = false;
            }

            timerText.text = Mathf.Round(displayTime).ToString();
        }
        else
        {
            timerText.text = "";
        }
    }
}
