using System.Collections;
using System.Collections.Generic;
using Overture.FrameGame;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.TextReplacement
{
	public class Healthandgameover : MonoBehaviour
	{
		public static int health = 50; //sets health as a public static int (Thanks AP!)

		// Use this for initialization
		void Start()
		{

			health = 5;

		}

		// Update is called once per frame
		void Update()
		{

			if (health <= 0)
			{
				//ModifyScoreTSP (1, 1, 0); JEFF LOOK HERE
				//TriggerFail (); JEFF LOOK HERE
				//SceneManager.LoadScene ("gameoverscene"); //loads the gameoverscene when health runs out
				
				FrameGameManager.Instance.SubmitScore(1,1,0,0);
				FrameGameManager.Instance.ReturnToDesktop();
			}


		}

		//void OnTriggerEnter2D(Collider2D other) { //leftover from previous version, kept in here for reference and if I want to do collider stuff here
		/*if (other.gameObject.GetComponent<textmove> ()) {
			health -= 10;
			Debug.Log ("Health:" + health);
		}*/
		/*var wordscript = other.gameObject.GetComponent<ByeScript> ();
		if (wordscript) {
			if (wordscript.CheckCorrect() == false) {
				health -= 10;
				Debug.Log ("Health:" + health);
			}
		}*/
		//}
	}
}