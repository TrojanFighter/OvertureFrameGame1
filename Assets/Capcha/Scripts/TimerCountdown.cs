using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.Captcha{

	public class TimerCountdown : MonoBehaviour {

		public static TimerCountdown instance = null;
		public float timer;
		public float timeTotal;
		public bool timeIsUp =  false;

		public bool TimerIsOn = true;
		// Use this for initialization

		void Awake()
		{
			if (instance == null) {
				instance = this;
				DontDestroyOnLoad(gameObject);

			} else if (instance != this) {
				Destroy (gameObject);
			}
		}

		void Start () 
		{
			timeTotal = timer;
		}


		void Update () 
		{
			if (!TimerIsOn)
			{
				return;
			}

			timer -= Time.deltaTime;
			if (timer <= 0) {
				timeIsUp = true;
				timer = timeTotal;
				SceneManager.LoadScene ("Captcha-Level07");
			}
		}
	}
}
