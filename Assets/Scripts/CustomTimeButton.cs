using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTimeButton : ButtonBase
{
    [SerializeField] private CustomTime _inputField;

    protected override void Click()
    {
        if (!_inputField.gameObject.activeSelf) 
            _inputField.gameObject.SetActive(true);
        
    }
}
