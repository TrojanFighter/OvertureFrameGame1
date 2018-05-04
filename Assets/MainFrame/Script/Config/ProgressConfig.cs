
using UnityEngine;

[CreateAssetMenu (menuName = "ProgressConfig")]
[System.Serializable]
public class ProgressConfig : ScriptableObject
{
    public int m_CurrentProgress = 0;

    public int TRexScore = 0, StegosaursScore = 0, PterosaursScore = 0;

    public int FailureCount = 0;

    public int FailureTolerance=6;

    public bool bHasFailed
    {
        get
        {
            if (FailureCount >= FailureTolerance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

