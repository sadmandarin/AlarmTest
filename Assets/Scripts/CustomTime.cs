using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomTime : MonoBehaviour
{
    private InputField _inputField;

    [SerializeField] private TimeContainer _timeContainer;

    private void OnEnable()
    {
        _inputField = GetComponent<InputField>();
        _inputField.text = null;

        _inputField.onEndEdit.AddListener(OnTimeInputEndEdit);
        _inputField.onValueChanged.AddListener(OnTimeInputValueChanged);
    }

    private void OnDisable()
    {
        _inputField.onEndEdit.RemoveListener(OnTimeInputEndEdit);
        _inputField.onValueChanged.RemoveListener(OnTimeInputValueChanged);
    }

    void OnTimeInputValueChanged(string input)
    {
        input = input.Replace(":", "");
        if (input.Length > 4) 
        {
            input = input.Substring(0, 4);
        }

        if (input.Length >= 2)
        {
            input = input.Insert(2, ":");
        }

        _inputField.text = input;

        _inputField.caretPosition = _inputField.text.Length;
    }

    private void OnTimeInputEndEdit(string input)
    {
        if (IsValidTime(input, out DateTime parsedTime))
        {
            _timeContainer.SynchTime = parsedTime;

            gameObject.SetActive(false);
        }

        else
        {
            Debug.LogError("Неверный формат времени. Пожалуйста, введите время в формате HH:MM");
            _inputField.text = ""; 
        }
    }

    bool IsValidTime(string input, out DateTime parsedTime)
    {
        string[] parts = input.Split(':');

        string formattedHour = FormatTimeUnit(parts[0]);
        string formattedMinute = FormatTimeUnit(parts[1]);

        input = formattedHour + ":" + formattedMinute; 
 
        return DateTime.TryParseExact(input, "HH:mm", null, System.Globalization.DateTimeStyles.None, out parsedTime);
    }

    private string FormatTimeUnit(string input)
    {
        if (int.TryParse(input, out int number))
        {
            return number.ToString("D2");
        }

        return "00";
    }
}
