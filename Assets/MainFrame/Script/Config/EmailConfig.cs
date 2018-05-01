using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "EmailConfig")]
[System.Serializable]
public class EmailConfig : ScriptableObject {

	[SerializeField] private List<string> _emailtitles;
	public List<string> _Titles
	{
		get { return _emailtitles; }
	}

	[SerializeField] private List<string> _emailBody;
	public List<string> _EmailBody
	{
		get { return _emailBody; }
	}
    
	[SerializeField] private List<string> _levelName;
	public List<string> _LevelName
	{
		get { return _levelName; }
	}
}
