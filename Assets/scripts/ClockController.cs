using UnityEngine;
using TMPro;

public class ClockController : MonoBehaviour
{
    public Routine routine;

    public TextMeshProUGUI timeText;

    private float elapsedTime = 0f;
    private float realTimeSecondsPerGameMinute = 2f; // Adjust this value to match your desired time compression

    void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        // Update elapsed time based on real-time seconds per game minute
        elapsedTime += Time.deltaTime * (1 / realTimeSecondsPerGameMinute);

        // Restart the clock at midnight (24:00)
        if (elapsedTime >= 24 * 60)
        {
            elapsedTime = 0f;
        }

        // Calculate hours and minutes
        int hours = Mathf.FloorToInt(elapsedTime / 60);
        int minutes = Mathf.FloorToInt(elapsedTime % 60);

        // Format the time in 24-hour format
        string timeString = string.Format("{0:00}:{1:00}", hours, minutes);

        // Update the TMPro text
        timeText.text = timeString;

        CheckAndTriggerActions(hours, minutes);
    }

    private void CheckAndTriggerActions(int hours, int minutes)
    {
        if (hours == 0 && minutes == 0)
        {
            routine.eleven2 = false;
            routine.twelve2 = true;
        }
        if (hours == 1 && minutes == 0)
        {
            routine.twelve2 = false;
            routine.one1 = true;
        }
        if (hours == 2 && minutes == 0)
        {
            routine.one1 = false;
            routine.two1 = true;
        }
        if (hours == 3 && minutes == 0)
        {
            routine.two1 = false;
            routine.three1 = true;
        }
        if (hours == 4 && minutes == 0)
        {
            routine.three1 = false;
            routine.four1 = true;
        }
        if (hours == 5 && minutes == 0)
        {
            routine.four1 = false;
            routine.five1 = true;
        }
        if (hours == 6 && minutes == 0)
        {
            routine.five1 = false;
            routine.six1 = true;
        }
        if (hours == 7 && minutes == 0)
        {
            routine.six1 = false;
            routine.seven1 = true;
        }
        if (hours == 8 && minutes == 0)
        {
            routine.seven1 = false;
            routine.eight1 = true;
        }
        if (hours == 9 && minutes == 0)
        {
            routine.eight1 = false;
            routine.nine1 = true;
        }
        if (hours == 10 && minutes == 0)
        {
            routine.nine1 = false;
            routine.ten1 = true;
        }
        if (hours == 11 && minutes == 0)
        {
            routine.ten1 = false;
            routine.eleven1 = true;
        }
        if (hours == 12 && minutes == 0)
        {
            routine.eleven1 = false;
            routine.twelve1 = true;
        }
        if (hours == 13 && minutes == 0)
        {
            routine.twelve1 = false;
            routine.one2 = true;
        }
        if (hours == 14 && minutes == 0)
        {
            routine.one2 = false;
            routine.two2 = true;
        }
        if (hours == 15 && minutes == 0)
        {
            routine.two2 = false;
            routine.three2 = true;
        }
        if (hours == 16 && minutes == 0)
        {
            routine.three2 = false;
            routine.four2 = true;
        }
        if (hours == 17 && minutes == 0)
        {
            routine.four2 = false;
            routine.five2 = true;
        }
        if (hours == 18 && minutes == 0)
        {
            routine.five2 = false;
            routine.six2 = true;
        }
        if (hours == 19 && minutes == 0)
        {
            routine.six2 = false;
            routine.seven2 = true;
        }
        if (hours == 20 && minutes == 0)
        {
            routine.seven2 = false;
            routine.eight2 = true;
        }
        if (hours == 21 && minutes == 0)
        {
            routine.eight2 = false;
            routine.nine2 = true;
        }
        if (hours == 22 && minutes == 0)
        {
            routine.nine2 = false;
            routine.ten2 = true;
        }
        if (hours == 23 && minutes == 0)
        {
            routine.ten2 = false;
            routine.eleven2 = true;
        }
    }
}
