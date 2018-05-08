using System.Collections;
using System.Collections.Generic;
using Overture.FrameGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace Overture.FrameGame
{




	public class SceneJumpInTime : MonoBehaviour
	{

		public float waitTime;

		public string m_nextSceneToLoad;

		public VideoPlayer m_videoToMonitor;

		// Use this for initialization
		void Start()
		{
			if (m_videoToMonitor == null)
			{
				StartCoroutine(DelayGoToScene(waitTime));
			}
			else
			{
				StartCoroutine(DelayGoToScene(waitTime+(float)m_videoToMonitor.clip.length));
			}
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
