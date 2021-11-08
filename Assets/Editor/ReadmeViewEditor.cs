using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ReadmeView))]
public class ReadmeViewEditor : UnityEditor.Editor
{
    GUIStyle HeadingStyle { get { return m_HeadingStyle; } }
    GUIStyle BodyStyle { get { return m_BodyStyle; } }
	
    [SerializeField]
    GUIStyle m_HeadingStyle;
	
    [SerializeField]
    GUIStyle m_BodyStyle;
	
    private bool m_editButton;
    private string m_readmeEditButtonText;
    private bool m_initialized;

    public override void OnInspectorGUI() {

        if (m_editButton) {
            base.OnInspectorGUI();
        }
        else {
            VisualGUI();
        }

        m_readmeEditButtonText = m_editButton ? " View README " : " Edit README ";
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        m_editButton = GUILayout.Toggle(m_editButton, m_readmeEditButtonText, EditorStyles.toolbarButton);
        GUILayout.EndHorizontal();
    }

    private void VisualGUI() {
        var readme = (ReadmeView)target;
        Init();

        foreach (var section in readme.Sections) {
            if (!string.IsNullOrEmpty(section.heading)) {
                GUILayout.Label(section.heading, HeadingStyle);
            }
            if (!string.IsNullOrEmpty(section.text)) {
                GUILayout.Label(section.text, BodyStyle);
            }
            GUILayout.Space(16f);
        }
    }

    void Init() {
        if (m_initialized)
            return;
        m_BodyStyle = new GUIStyle(EditorStyles.label);
        m_BodyStyle.wordWrap = true;
        m_BodyStyle.fontSize = 14;

        m_HeadingStyle = new GUIStyle(m_BodyStyle);
        m_HeadingStyle.fontSize = 18;
        m_HeadingStyle.fontStyle = FontStyle.Bold;

        m_initialized = true;
    }
}