using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overture.Captcha{

	public class ChangeFeedbackText : MonoBehaviour {

		GameManager gameManager;
		bool answerSubmitted;
		ButtonClick submitted;
		public Text feedbackText;
		public string goodFeedbackText;
		public string badFeedbackText;
		GameObject feedbackTextObj;

		void Start(){

			gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
			submitted = GameObject.Find ("SubmitButton").GetComponent<ButtonClick> ();
			feedbackTextObj = GameObject.Find ("FeedbackText");
			//Text sets your text to say this message
			feedbackText.text = " ";
		}

		void Update() {
			answerSubmitted = gameManager.selectedAllTargets;

	//		Debug.Log (submitted.submitted);
	//		Debug.Log (answerSubmitted);

			if (submitted.submitted == true) {
				feedbackTextObj.SetActive (true);
				if (answerSubmitted == true) {
	//				feedbackText.text = goodFeedbackText;
					feedbackText.text = "";
					feedbackText.text += goodFeedbackText;
				} 
				else {
					//feedbackText.text = badFeedbackText;
					feedbackText.text = badFeedbackText;
					feedbackText.text = "";
					feedbackText.text += badFeedbackText;
				}
			}
		}
	}
}
