using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;

    [SerializeField] float startTime = 120f;

    float time;
    bool isTimeStopped = true;

    void Awake()
    {
        
        ResetTimeCount();
        StartTimeCount();
    }

    public void StartTimeCount()
    {
        time = startTime;
        isTimeStopped = false;
        UpdateTimeText();
    }

    public void StopTimeCount()
    {
        isTimeStopped = true;
    }

    public void ResumeTimeCount()
    {
        isTimeStopped = false;
    }

    public void ResetTimeCount()
    {
        time = startTime;
        isTimeStopped = true;
        UpdateTimeText();
    }

    void Update()
    {
      
        if (isTimeStopped)
            return;

        if (time <= 0f)
        {
            time = 0f;
            UpdateTimeText();
            StopTimeCount();
            GameOver();
            return;
        }

        time -= Time.deltaTime;
        UpdateTimeText();
    }

    void GameOver()
    {
      
        timeText.text = "Time's up!";
        Debug.Log("¡Se ha acabado el tiempo!");
    }

    void UpdateTimeText()
    {
        time = Mathf.Max(0f, time);

        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        timeText.text = $"{minutes:00}:{seconds:00}";
    }
}