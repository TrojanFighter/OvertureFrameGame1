using System.Collections;
using System.Collections.Generic;
using Overture.FrameGame;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.FrameGame
{




	public class SceneJumpInTime : MonoBehaviour
	{

		public float waitTime;

		public string m_nextSceneToLoad;

		// Use this for initialization
		void Start()
		{
			StartCoroutine(DelayGoToScene(waitTime));
		}

		IEnumerator DelayGoToScene(float delayTime)
		{
			yield return new WaitForSeconds(delayTime);
			if (m_nextSceneToLoad != string.Empty)
			{
				GameStateManager.STATE = GameStateManager.GameState.MailReading;
				SceneManager.LoadScene(m_nextSceneToLoad);
			}
			else
			{
				FrameGameManager.Instance.ReturnToDesktop();
			}
		}

	}
}
