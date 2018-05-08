
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu (menuName = "StageConfig")]
[System.Serializable]
public class StageConfig : ScriptableObject {
    
    [SerializeField] private List<string> _levelEmailID;
    public List<string> _LevelEmailID
    {
        get { return _levelEmailID; }
    }
    
    [SerializeField] private List<string> _levelScene;
    public List<string> _LevelScene
    {
        get { return _levelScene; }
    }
    /*
    [SerializeField] private List<StageContent> _levels;
    public List<StageContent> Levels
    {
        get { return _levels; }
    }*/
}

