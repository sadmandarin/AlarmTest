using UnityEngine;
using UnityEngine.UI;

public class ClockSwitchButton : ButtonBase
{
    [SerializeField] private ClockController _clockController;
    [SerializeField] private AnalogClock _analogClock;
    [SerializeField] private DigitalWatch _digitalWatch;

    private bool _isAnalogClockActive = true;
    private Text _buttonText;

    protected override void Awake()
    {
        base.Awake();

        _buttonText = GetComponentInChildren<Text>();

        _clockController.SetClock(_analogClock);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void Click()
    {
        if (_isAnalogClockActive)
        {
            _isAnalogClockActive = !_isAnalogClockActive;

            _analogClock.gameObject.SetActive(false);

            _clockController.SetClock(_digitalWatch);

            _digitalWatch.gameObject.SetActive(true);

            _buttonText.text = "Switch to Digital";
        }

        else
        {
            _isAnalogClockActive = !_isAnalogClockActive;

            _analogClock.gameObject.SetActive(true);

            _clockController.SetClock(_analogClock);

            _digitalWatch.gameObject.SetActive(false);

            _buttonText.text = "Switch to Analog";
        }
    }
}
