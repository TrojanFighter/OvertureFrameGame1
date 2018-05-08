using System.Collections;
using System.Collections.Generic;
using Overture.FrameGame;
using UnityEngine;
using Overture.FrameGame;


public class GameFinished : MonoBehaviour {

    

    public void OnClick_FinishGame()
    {
        Overture.FrameGame.FrameGameManager.Instance.SubmitScore(-1,-1,-1,1);
        Overture.FrameGame.FrameGameManager.Instance.ReturnToDesktop();
    }
}
