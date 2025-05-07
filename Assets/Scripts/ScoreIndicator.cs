using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreIndicator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float lifetime = 0.6f;
    [SerializeField] float minDist = 2f;
    [SerializeField] float maxDist = 3f;
    [SerializeField] Vector3 offset;

    Vector3 iniPos;
    Vector3 targetPos;
    float currentTimer;
    Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        currentTimer += Time.deltaTime;

        float fraction = lifetime / 2f;

        if (currentTimer > lifetime) Destroy(gameObject);
        else if (currentTimer > fraction) text.color = Color.Lerp(text.color, Color.clear, (currentTimer - fraction) / (lifetime - fraction));

        transform.position = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(currentTimer / lifetime));
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Sin(currentTimer / lifetime));


        //transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }

    public void SetPointsText(int points, Vector3 initialPosition)
    {
        text.text = points.ToString();
        iniPos = initialPosition + offset;

        float direction = Random.rotation.eulerAngles.z;
        float dist = Random.Range(minDist, maxDist);
        targetPos = iniPos + (Quaternion.Euler(0, 0, 90) * new Vector3(dist, dist, 0));
        transform.localScale = Vector3.zero;
        currentTimer = 0;
    }
}
