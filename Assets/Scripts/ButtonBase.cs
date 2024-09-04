using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
    protected Button _button;

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Click);
    }

    protected virtual void OnDestroy()
    {
        _button.onClick.RemoveListener(Click);
    }

    protected abstract void Click();
}
