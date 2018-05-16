using System.Collections;
using System.Collections.Generic;
using Overture.FrameGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

namespace Overture.CensorBar
{

	public class Lvl2Scoring : MonoBehaviour
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
			else isCovering = false;
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (_noPantsTime) return;
			isCovering = false;
		}

		private void GetOffScreen()
		{
			if (gameObject.transform.position.y > 5.52 ||
			    gameObject.transform.position.y < -5.52 ||
			    gameObject.transform.position.x < -8.73 ||
			    gameObject.transform.position.x > 8.73)
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
			if ((_video.frame > 1209 && _video.frame < 1272) ||
			    (_video.frame > 1343 && _video.frame < 1418) ||
			    (_video.frame > 1585 && _video.frame < 2525) ||
			    (_video.frame > 2695 && _video.frame < 2945) ||
			    (_video.frame > 3013 && _video.frame < 3096) ||
				(_video.frame > 3153 && _video.frame < 3265) ||
				(_video.frame > 3340 && _video.frame < 3420) ||
				(_video.frame > 3550 && _video.frame < 3814))
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
			Debug.Log("Ending");
			//if (_video.frame >= 3813)
			{
				isCovering = true;
				if (FailFrames > 900 && FailFrames < 1200)
				{
					Debug.Log("Ending1");
					//finalScore.ModifyScoreTSP(-1, 0, 1);
					GameSaveManager.StoreScore(-1,0,1,0);
					SceneManager.LoadScene("EndingScene");
				}
				else if (FailFrames >= 1200)
				{
					Debug.Log("Ending2");
					GameSaveManager.StoreScore(1,0,-1,1);
					SceneManager.LoadScene("TechnicalDifficultyEnding");
				}
				else
				{
					Debug.Log("Ending3");
					GameSaveManager.StoreScore(1,0,-1,0);
					SceneManager.LoadScene("EndingScene");
				}

			}
			/*else
			{
				CheckForPants();
			}*/
		}

		// Update is called once per frame
		void Update()
		{
			//Debug.Log("_video.frame: "+_video.frame);
			if (!isCovering && _video.frame > 90) FailFrames++;
			if (Time.timeSinceLevelLoad>_video.clip.length&& !_video.isPlaying)
			{
				CheckForEnd();
			}
			else
			{
				CheckForPants();
			}
		}
	}
}