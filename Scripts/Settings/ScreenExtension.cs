using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Data;

public class ScreenExtension : MonoBehaviour
{
    private Extension[] _extensions;

    public void ChangeExtension(Extension extension) =>
        Screen.SetResolution(extension.extension.x, extension.extension.y, extension.fullscreen);

    public Extension[] GetAllExtensions() => _extensions;

    private void Awake() =>
        _extensions = Resources.LoadAll<Extension>(Paths.ScreenExtensions);
    
}
