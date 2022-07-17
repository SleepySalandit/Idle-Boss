using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionNumber : MonoBehaviour
{
    public Text versionNumberText;

    public void Update()
    {
        versionNumberText.text = "Version " + Application.version.ToString();
    }
}
