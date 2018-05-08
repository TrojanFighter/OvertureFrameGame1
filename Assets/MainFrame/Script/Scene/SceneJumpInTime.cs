using System.Collections;
using System.Collections.Generic;
using Overture.FrameGame;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJumpInTime : MonoBehaviour
{

	public float waitTime;

	public Scene m_nextSceneToLoad;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(DelayGoToScene(waitTime));
	}

	IEnumerator DelayGoToScene(float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		if (m_nextSceneToLoad != null)
		{
			SceneManager.LoadScene(m_nextSceneToLoad.name);
		}
		else
		{
			FrameGameManager.Instance.ReturnToDesktop();
		}
	}

	void SaveScore()
	{
		
	}

}
