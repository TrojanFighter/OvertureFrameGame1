using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Overture.CensorBar
{

	public class CensorAreaAnimation : MonoBehaviour
	{

		public VideoPlayer video_player;

		//public Animation censor_animation;
		private Animator animator_component;
		int currentVideoFrame;
		bool isStarted = false;

		// Use this for initialization
		void Start()
		{
			animator_component = GetComponent<Animator>();
			//video_player = GameObject.Find ("Screen").GetComponent<VideoPlayer> ();

			Debug.Log(video_player);

			//censor_animation = Resources.Load ("/Animations/Target1") as Animation;

			//Debug.Log (censor_animation);

			//censor_animation["Target1"].speed = 0.0f;
		}

		// Update is called once per frame
		void Update()
		{
			if (!isStarted)
			{
				if (video_player.isPlaying)
				{
					animator_component.enabled = true;
					animator_component.Play("Target1");
					isStarted = true;
				}
			}

			/*float animationTime = (float)video_player.frame / (float)video_player.clip.frameCount * rate;
			Debug.Log (animationTime);
			animator_component.Play ("Target1", -1, animationTime);
			animator_component.speed = 0.0f;*/
		}
	}
}