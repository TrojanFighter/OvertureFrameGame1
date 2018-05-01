
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu (menuName = "StageConfig")]
[System.Serializable]
public class StageConfig : ScriptableObject {
    

    [SerializeField] private List<int> _levelProgressCondition;
    public List<int> _LevelProgressCondition
    {
        get { return _levelProgressCondition; }
    }
    

    [SerializeField] private List<string> _levelEmail;
    public List<string> _LevelEmail
    {
        get { return _levelEmail; }
    }
    
    [SerializeField] private List<string> _levelName;
    public List<string> _LevelName
    {
        get { return _levelName; }
    }
    /*
    [SerializeField] private List<StageContent> _levels;
    public List<StageContent> Levels
    {
        get { return _levels; }
    }*/
}

