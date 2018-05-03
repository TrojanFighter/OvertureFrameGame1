
using UnityEngine;

[CreateAssetMenu (menuName = "ProgressConfig")]
[System.Serializable]
public class ProgressConfig : ScriptableObject
{
    public int m_CurrentProgress = 0;

    public int Score1 = 0, Score2 = 0, Score3 = 0;
}

