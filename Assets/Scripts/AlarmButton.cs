using UnityEngine;

public class AlarmButton : ButtonBase
{
    [SerializeField] private GameObject _digitalAlarm;


    protected override void Awake()
    {
        base.Awake();
        _clocks = FindFirstObjectByType<ClockController>();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void Click()
    {
        _digitalAlarm.SetActive(!_digitalAlarm.activeSelf);
    }
}
