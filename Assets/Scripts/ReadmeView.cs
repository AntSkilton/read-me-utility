using System;
using UnityEngine;

public class ReadmeView : MonoBehaviour
{
    public Section[] Sections = new Section[] { };

    [Serializable]
    public class Section 
    {
        [SerializeField] public string heading;
        [TextArea(3, 5), SerializeField] public string text;
    }

    [ContextMenu("Dont Save In Build Check")]
    private void Reset() {
            hideFlags = HideFlags.DontSaveInBuild;
    }
}