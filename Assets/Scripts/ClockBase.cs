using System;
using UnityEngine;

public abstract class ClockBase : MonoBehaviour
{
    [SerializeField] private TimeContainer _timeContainer;

    public abstract void UpdateClock(DateTime currTime);
}
