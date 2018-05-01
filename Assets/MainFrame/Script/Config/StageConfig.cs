
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
    

    [SerializeField] private List<GameObject> _levelMessage;
    public List<GameObject> _LevelMessage
    {
        get { return _levelMessage; }
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

