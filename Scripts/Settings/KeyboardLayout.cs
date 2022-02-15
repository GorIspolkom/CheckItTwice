using UnityEngine;

[CreateAssetMenu(fileName = "KeyboardLayout", menuName = "ScriptableObjects/KeyboardLayout", order = 4)]
public class KeyboardLayout : ScriptableObject
{
    public KeyCode sprint;
    public KeyCode moveForward;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode moveBack;
    public KeyCode dropItem;
}
