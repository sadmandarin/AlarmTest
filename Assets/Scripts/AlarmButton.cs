using UnityEngine;

public class AlarmButton : ButtonBase
{
    [SerializeField] private GameObject _digitalAlarm;


    protected override void Awake()
    {
        base.Awake();
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
