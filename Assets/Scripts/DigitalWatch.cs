using System;
using TMPro;
using UnityEngine;

public class DigitalWatch : ClockBase
{
    [SerializeField] private TextMeshPro _text;
    public override void UpdateClock(DateTime currTime)
    {
        int hours = currTime.Hour;
        int minutes = currTime.Minute;
        int seconds = currTime.Second;

        _text.text = $"{hours:D2} : {minutes:D2} : {seconds:D2}";
    }
}
