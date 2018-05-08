using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

namespace Overture.CensorBar
{

	public class TrackingAnim : MonoBehaviour
	{

		float frameCount;
		float curFrame;
		string curAnim;
		private Animator animator_component;
		public VideoPlayer video_player;
		VideoClip curClip;
		float curTime;
		bool newClip = true;
		public float frameDiff = 3.3f;
		private string scene;

		void InitNewClip(string anim, VideoClip clip)
		{
			curAnim = anim;
			curClip = clip;
			frameCount = (float) clip.frameCount;
			//Debug.Log ("Frame Count is: " + frameCount);
			curFrame = 0;
			curTime = 0;

		}

		void Start()
		{
			animator_component = GetComponent<Animator>();
			scene = SceneManager.GetActiveScene().name;
		}

		void Update()
		{
			if (!newClip && video_player.isPlaying)
			{
				curTime = (video_player.frame / frameCount);
				//Debug.Log ("curTime: " + curTime);
				animator_component.Play(curAnim, -1, curTime * frameDiff);

				animator_component.speed = 0.0f;

			}
			else
			{
				newClip = false;
				if (scene == "Censor Level 1") InitNewClip("Lvl1Target", video_player.clip);
				if (scene == "Censor Level 2") InitNewClip("Lvl2Target", video_player.clip);
				
			}
		}
	}
}
