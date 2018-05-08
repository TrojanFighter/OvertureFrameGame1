using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalDefine  {

    
}

public class EmailContent
{
    public string TITLE,SENDER, DATE, BODY_TEXT;
    public Sprite BODY_IMG;
}

public enum EndingState
{
    TRex,
    STEGOSARUS,
    PTEROSAUR,
    FAILURE
}


public class StageContent
{
    public int stageNum;
    public string EmailNameToLoad;
    public string LevelNameToLoad;
}