
using UnityEngine;

[CreateAssetMenu (menuName = "EndingConfig")]
[System.Serializable]
public class EndingConfig : ScriptableObject
{
	public int LastProgressNum = 0;

	public string FailEndingSceneName,TRexEndingSceneName , StegosaursEndingSceneName , PterosaursEndingSceneName ;
}

