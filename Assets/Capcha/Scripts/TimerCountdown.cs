using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.Capcha
{
	public class TimerCountdown : MonoBehaviour
	{

		public static TimerCountdown instance = null;
		public float timer;
		public float timeTotal;

		public bool timeIsUp = false;
		// Use this for initialization

		void Awake()
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);

			}
			else if (instance != this)
			{
				Destroy(gameObject);
			}
		}

		void Start()
		{
			timeTotal = timer;
		}


		void Update()
		{
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
				timeIsUp = true;
			}
		}
	}
}