using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overture.Captcha{

	public class Timer : MonoBehaviour {

		public static Timer instance = null;
		Image timerImage;
	//	public float timer;
	//	float timeTotal;
	//	public bool timeIsUp =  false;
		GameObject timerVisual;
		float timeRemain;
		float timeTotal;


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
			timerImage = this.GetComponent<Image>();
			timeTotal = GameObject.Find ("Timer").GetComponent<TimerCountdown> ().timeTotal;

		}

		void Update () 
		{
			timeRemain = GameObject.Find ("Timer").GetComponent<TimerCountdown> ().timer;
			timerImage.fillAmount = timeRemain / timeTotal;

		}

	}

}
