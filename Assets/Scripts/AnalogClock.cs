using UnityEngine;
using System;

public class AnalogClock : ClockBase
{
    public GameObject pointerSeconds;
    public GameObject pointerMinutes;
    public GameObject pointerHours;
    public override void UpdateClock(DateTime currTime)
    {
        float hours = currTime.Hour;
        float minutes = currTime.Minute;
        float seconds = currTime.Second;

        float rotationSeconds = (360.0f / 60.0f) * seconds;
        float rotationMinutes = (360.0f / 60.0f) * minutes;
        float rotationHours = ((360.0f / 12.0f) * hours) + ((360.0f / (60.0f * 12.0f)) * minutes);

        pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);
    }
}
