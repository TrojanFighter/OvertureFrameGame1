using System.Collections;
using System.Collections.Generic;
using Overture.FrameGame;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Overture.Captcha{
public class ButtonClick : MonoBehaviour {

	Button submitButton;
	public bool submitted = false;

	public Sprite retryImage;
	public Sprite continueImage;

	public Sprite retryPushed;
	public Sprite continuePushed;
	public Sprite submitPushed;

	public bool BGoToDesktopNext=false;



//if (GameObject.Find("name of the gameobject holding the script with the bool").GetComponent<name of the script holding the bool>().IsLightOn)

	void Start () {
		submitButton = GetComponent<Button> ();
//		submitButton.GetComponentInChildren<Text>().text = "Submit";
		submitButton.onClick.AddListener (Submit);

	}

	void Update(){
//		if (Input.GetMouseButton (0)) {
//			if (submitButton.image.sprite != continueImage) {
//				submitButton.image.sprite = submitPushed;
//			}
//
//			if (submitButton.image.sprite == continueImage) {
//				submitButton.image.sprite = continuePushed;
//			}
//		}
	}
		
	public void Submit(){
		//Change the buttons depending on the answer / Retry or Continue
	
		if (submitted == false) {
			submitted = true;
			if (GameObject.Find ("GameManager").GetComponent<GameManager> ().selectedAllTargets == true) {
//				submitButton.GetComponentInChildren<Text>().text = "";
				submitButton.image.sprite = continueImage;
			} else {
//				submitButton.GetComponentInChildren<Text>().text = "";
				submitButton.image.sprite = retryImage;	
			}
		} else {
			if (GameObject.Find ("GameManager").GetComponent<GameManager> ().selectedAllTargets == true) {

				if (!BGoToDesktopNext)
				{
					Application.LoadLevel(Application.loadedLevel + 1);
				}
				else
				{
					GameObject timer = GameObject.Find("Timer");
					if (timer != null)
					{
						timer.GetComponent<TimerCountdown>().TimerIsOn = false;
						Destroy(timer);
					}

					if (FrameGameManager.Instance != null)
					{
						FrameGameManager.Instance.ReturnToDesktop();
					}
					else
					{
						GameStateManager.STATE = GameStateManager.GameState.MailReading;
						SceneManager.LoadScene("MainFrame");
					}
				}
			} else {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}
}
}
