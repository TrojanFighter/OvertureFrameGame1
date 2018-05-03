using System.Collections;
using System.Collections.Generic;
using Overture.FrameGame;
using UnityEngine;

public class GameFinished : MonoBehaviour {

    

    public void OnClick_FinishGame()
    {
        GameManager.Instance.ReturnToDesktop();
    }
}
