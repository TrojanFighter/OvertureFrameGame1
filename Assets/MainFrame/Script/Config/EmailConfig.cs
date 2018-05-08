using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "EmailConfig")]
[System.Serializable]
public class EmailConfig : ScriptableObject
{

	public List<int> _specialEmailToLoad;

	[SerializeField] private List<string> _emailtitles;
	public List<string> _Titles
	{
		get { return _emailtitles; }
	}
	[SerializeField] private List<string> _senderName;
	public List<string> _SenderName
	{
		get { return _senderName; }
	}

	[SerializeField] private List<string> _emailBody;
	public List<string> _EmailBody
	{
		get { return _emailBody; }
	}
    
}
