using System.Collections;
using System.Collections.Generic;
using Overture.FrameGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Overture.CensorBar
{

	public class Lvl1Scoring : MonoBehaviour
	{

		public BoxCollider2D target;
		private bool isCovering;
		public int FailFrames;
		private VideoPlayer _video;
		private bool _noPantsTime;
		private Image _fineUI;
		private Image _gtfoUI;

		// Use this for initialization
		void Start()
		{
			isCovering = false;
			FailFrames = 0;
			_video = GameObject.Find("Screen").GetComponent<VideoDisplay>().m_videoPlayer;
			_fineUI = GameObject.Find("Fine Image").GetComponent<Image>();
			_gtfoUI = GameObject.Find("GTFO Image").GetComponent<Image>();
			_noPantsTime = false;
			_gtfoUI.enabled = false;
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			if (_noPantsTime) return;
			if (other.bounds.Contains(target.bounds.min) &&
			    other.bounds.Contains(target.bounds.max))
			{
				Debug.Log("Censor Bar is covering");
				isCovering = true;
			}
			else
			{
				Debug.Log("Cover that dino!!");
				isCovering = false;
			}

		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (_noPantsTime) return;
			isCovering = false;
		}

		private void GetOffScreen()
		{
			if (gameObject.transform.position.y > 6 ||
			    gameObject.transform.position.y < -6 ||
			    gameObject.transform.position.x < -9.8 ||
			    gameObject.transform.position.x > 9.66)
			{
				isCovering = true;
			}
			else
			{
				isCovering = false;
			}

			_fineUI.enabled = false;
			_gtfoUI.enabled = true;
		}

		private void CheckForPants()
		{
			if ((_video.frame > 549 && _video.frame < 761) ||
			    (_video.frame > 1414 && _video.frame < 1699) ||
			    (_video.frame > 2059 && _video.frame < 2384))
			{
				_noPantsTime = true;
				Debug.Log("Get off Screen!");
				GetOffScreen();

			}
			else
			{
				_noPantsTime = false;
				_fineUI.enabled = true;
				_gtfoUI.enabled = false;
			}
		}
		

		private void CheckForEnd()
		{
			if (_video.frame > 2769)
			{
				isCovering = true;
 			if (FailFrames > 900 && FailFrames < 1200)
 			{
 				//finalScore.ModifyScoreTSP(-1, 0, 1);
				 GameSaveManager.StoreScore(-1,0,1,0);
				 GameStateManager.STATE = GameStateManager.GameState.MailReading;
				 SceneManager.LoadScene("MainFrame");
 			}
 			else if (FailFrames >= 1200)
 			{
				 GameSaveManager.StoreScore(1,0,-1,1);
				 GameStateManager.STATE = GameStateManager.GameState.MailReading;
				 SceneManager.LoadScene("TechnicalDifficulty");
 			}
 			else
 			{
 				//finalScore.ModifyScoreTSP(1, 0, -1);
				 GameSaveManager.StoreScore(1,0,-1,0);
				 GameStateManager.STATE = GameStateManager.GameState.MailReading;
				 SceneManager.LoadScene("MainFrame");
 			}

			}
			else
			{
				CheckForPants();
			}
		}

		// Update is called once per frame
		void Update()
		{
			if (!isCovering && _video.frame > 90) FailFrames++;
			CheckForEnd();
		}
	}
}