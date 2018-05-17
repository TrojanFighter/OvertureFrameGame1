using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProgressConfig),true)]
/// <summary>
/// Custom inspector for the ProgressConfig scriptable object. 
/// </summary>
public class ProgressConfigInspector : Editor 
{
	/// <summary>
	/// When drawing the GUI, adds a "Reset Achievements" button, that does exactly what you think it does.
	/// </summary>
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		ProgressConfig progressConfig = (ProgressConfig)target;
		if(GUILayout.Button("Reset Progress"))
		{
			progressConfig.ResetProgress();
		}	
		EditorUtility.SetDirty (progressConfig);
	}
}