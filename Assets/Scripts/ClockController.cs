using UnityEngine;

public class ClockController : MonoBehaviour
{
    private float msecs = 0;

    [SerializeField] private TimeContainer _timeContainer;

    private ClockBase _clock;
    
    public ClockBase Clock {  get { return _clock; } }

    void Awake()
    {
        _clock.UpdateClock(_timeContainer.SynchTime);
    }

    void Update()
    {
        msecs += Time.deltaTime;
        if (msecs >= 1.0f)
        {
            _timeContainer.SynchTime = _timeContainer.SynchTime.AddSeconds(msecs);

            msecs -= 1.0f;

            _clock.UpdateClock(_timeContainer.SynchTime);
        }
    }

    public void SetClock(ClockBase clock)
    {
        if (clock != _clock)
        {
            _clock = clock;

            _clock.UpdateClock(_timeContainer.SynchTime);
        }
    }
}
