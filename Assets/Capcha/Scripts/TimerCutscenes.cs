using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.Captcha{

	public class TimerCutscenes : MonoBehaviour {

		float timer;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			timer = GameObject.Find ("Timer").GetComponent<TimerCountdown> ().timer;
			if (timer <= 0) {
				SceneManager.LoadScene ("Captcha-Level07");
			}
		}
	}
}
