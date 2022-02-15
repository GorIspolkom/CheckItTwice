using UnityEngine;

[CreateAssetMenu(fileName = "ScreenExtension", menuName = "ScriptableObjects/ScreenExtension", order = 5)]
public class Extension : ScriptableObject
{
    public bool fullscreen;
    public Vector2Int extension;
}
