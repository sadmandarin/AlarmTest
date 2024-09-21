using UnityEngine;

public class ClockController : MonoBehaviour
{
    private float msecs = 0;

    [SerializeField] private TimeContainer _timeContainer;

    private AnalogClock _analogClock;
    private DigitalWatch _digitalClock;

    void Awake()
    {
        _analogClock = FindFirstObjectByType<AnalogClock>();
        _digitalClock = FindFirstObjectByType<DigitalWatch>();

        _analogClock.UpdateClock(_timeContainer.SynchTime);
        _digitalClock.UpdateClock(_timeContainer.SynchTime);
    }

    void Update()
    {
        msecs += Time.deltaTime;
        if (msecs >= 1.0f)
        {
            _timeContainer.SynchTime = _timeContainer.SynchTime.AddSeconds(msecs);

            msecs -= 1.0f;

            _analogClock?.UpdateClock(_timeContainer.SynchTime);
            _digitalClock?.UpdateClock(_timeContainer.SynchTime);
        }
    }
}
