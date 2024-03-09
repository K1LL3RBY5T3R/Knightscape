using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text timeSurvived;
    private float startTime;
    private string timerString;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;
        UpdateTimerText(elapsedTime);
        SetTotalTimeSurvived();
    }

    /*
     * Updates the timer in minutes and seconds
     */
    void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "Time: " + timerString;
    }
    
    /*
     * Sets the total time survived
     */
    public void SetTotalTimeSurvived()
    {
        timeSurvived.text = "Total time Survived: " + timerString;
    }
}
