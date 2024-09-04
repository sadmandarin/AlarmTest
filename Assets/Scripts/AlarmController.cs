using System;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    private DateTime? _alarmTime;

    void Update()
    {
        if (_alarmTime.HasValue)
        {
            if (DateTime.Now.Hour == _alarmTime.Value.Hour && DateTime.Now.Minute == _alarmTime.Value.Minute)
            {
                TriggerAlarm();
                _alarmTime = null;
            }
        }
    }

    public void SetAlarm(DateTime alarm)
    {
        _alarmTime = new DateTime(alarm.Year, alarm.Month, alarm.Day, alarm.Hour, alarm.Minute, 0);

        Debug.Log("Будильник установлен на: " + _alarmTime.Value.ToString("HH:mm"));
    }
    void TriggerAlarm()
    {
        //добавить звук

        Debug.Log("Будильник сработал!");
    }
}
