using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalTime : MonoBehaviour
{
    public Text tSecs;
    public Text tMinutes;
    public Text tHours;

    private float secs = 0f;
    private int minutes = 0;
    private int hours = 0;

    void Start()
    {
        tSecs.text = " " + secs;
    }

    void Update()
    {
        secs += Time.deltaTime;
        tSecs.text = " " + secs.ToString("00s");

        if (secs > 59)
        {
            minutes += 1;
            tMinutes.text = " " + minutes.ToString("00:");
            secs = 0f;
        }

        if (minutes > 59)
        {
            hours += 1;
            tHours.text = " " + hours.ToString("00:");
            minutes = 0;
        }
    }
}
