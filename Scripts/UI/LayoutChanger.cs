using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutChanger : MonoBehaviour
{
    [SerializeField]
    private LayoutController _layoutController;
    [SerializeField]
    private InputField[] _inputFields;
    [SerializeField]
    private Button _saveButton;
    [SerializeField]
    private Button _defaultLayoutButton;

    private void Start()
    {
        InitFields();
        _saveButton.onClick.AddListener(ChangeLayout);
        _defaultLayoutButton.onClick.AddListener(() =>
        {
            _layoutController.SetDefaultKeyboardLayoyut();
            InitFields();
        });
    }

    private void ChangeLayout()
    {
        _layoutController.ChangeLayout(
                _inputFields[0].text,
                _inputFields[1].text,
                _inputFields[2].text,
                _inputFields[3].text,
                _inputFields[4].text,
                _inputFields[5].text
                );
    }

    private void InitFields()
    {
        _inputFields[0].text = _layoutController.GetKeyboardLayout().sprint.ToString();
        _inputFields[1].text = _layoutController.GetKeyboardLayout().moveForward.ToString();
        _inputFields[2].text = _layoutController.GetKeyboardLayout().moveLeft.ToString();
        _inputFields[3].text = _layoutController.GetKeyboardLayout().moveRight.ToString();
        _inputFields[4].text = _layoutController.GetKeyboardLayout().moveBack.ToString();
        _inputFields[5].text = _layoutController.GetKeyboardLayout().dropItem.ToString();
    }

}
