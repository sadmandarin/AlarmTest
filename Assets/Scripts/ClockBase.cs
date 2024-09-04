using System;
using UnityEngine;

public abstract class ClockBase : MonoBehaviour
{
    [SerializeField] private TimeContainer _timeContainer;

    //protected virtual void OnEnable()
    //{
    //    UpdateClock(_timeContainer.SynchTime);
    //}

    public abstract void UpdateClock(DateTime currTime);
}
