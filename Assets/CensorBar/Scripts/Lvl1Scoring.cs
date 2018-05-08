using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

		// Use this for initialization
		void Start()
		{
			isCovering = false;
			FailFrames = 0;
			_video = GameObject.Find("Screen").GetComponent<VideoPlayerMonitor>().m_videoPlayer;
			_noPantsTime = false;
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
			}
		}

		private void CheckForEnd()
		{
			if (_video.frame > 2769)
			{
				isCovering = true;
//				if (FailFrames > 900 && FailFrames < 1200)
//				{
//					finalScore.ModifyScoreTSP(-1, 0, 1);
//				}
//				else if (FailFrames >= 1200)
//				{
//					finalScore.TriggerFail();
//				}
//				else
//				{
//					finalScore.ModifyScoreTSP(1, 0, -1);
//				}

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