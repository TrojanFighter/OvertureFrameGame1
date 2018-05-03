using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.Capcha
{
	public class TimerCutscenes : MonoBehaviour
	{

		public float timer;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
				SceneManager.LoadScene("Level00");
			}
		}
	}
}