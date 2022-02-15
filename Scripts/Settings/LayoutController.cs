using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutController : MonoBehaviour
{

    [SerializeField]
    private KeyboardLayout _defaultKeyboardLayout;
    [SerializeField]
    private KeyboardLayout _customKeyboardLayout;

    public KeyboardLayout GetKeyboardLayout() => _customKeyboardLayout;

    public void SetDefaultKeyboardLayoyut()
    {
        _customKeyboardLayout.sprint = _defaultKeyboardLayout.sprint;
        _customKeyboardLayout.moveForward = _defaultKeyboardLayout.moveForward;
        _customKeyboardLayout.moveLeft = _defaultKeyboardLayout.moveLeft;
        _customKeyboardLayout.moveRight = _defaultKeyboardLayout.moveRight;
        _customKeyboardLayout.moveBack = _defaultKeyboardLayout.moveBack;
        _customKeyboardLayout.dropItem = _defaultKeyboardLayout.dropItem;
    }

    public void ChangeLayout(string sprint, string moveForward, string moveLeft, string moveRigth, string moveBack, string dropItem)
    {
        _customKeyboardLayout.sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), sprint);
        _customKeyboardLayout.moveForward = (KeyCode)System.Enum.Parse(typeof(KeyCode), moveForward);
        _customKeyboardLayout.moveLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), moveLeft);
        _customKeyboardLayout.moveRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), moveRigth);
        _customKeyboardLayout.moveBack = (KeyCode)System.Enum.Parse(typeof(KeyCode), moveBack);
        _customKeyboardLayout.dropItem = (KeyCode)System.Enum.Parse(typeof(KeyCode), dropItem);
    }

}
