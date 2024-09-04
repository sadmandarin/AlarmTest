using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeContainer", menuName = "SO/TimeContainer", order = 0)]
public class TimeContainer : ScriptableObject
{
    public DateTime SynchTime;
}
