using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenExtensionChanger : MonoBehaviour
{
    [SerializeField]
    private ScreenExtension _screenExtensionController;
    [SerializeField]
    private Dropdown _dropdown;

    private void ChangeExtension() =>
        _screenExtensionController.ChangeExtension(_screenExtensionController.GetAllExtensions()[_dropdown.value]);

    private void Start() =>
        _dropdown.onValueChanged.AddListener(delegate { ChangeExtension(); });

    private void Awake()
    {
        for (int i = 0; i < _screenExtensionController.GetAllExtensions().Length; i++)
            _dropdown.options.Add(new Dropdown.OptionData(_screenExtensionController.GetAllExtensions()[i].extension.x.ToString() + " X " 
                + _screenExtensionController.GetAllExtensions()[i].extension.y.ToString(), null));
    }
}
