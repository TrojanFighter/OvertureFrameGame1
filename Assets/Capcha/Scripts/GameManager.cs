using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

namespace Overture.Captcha{

	public class GameManager : MonoBehaviour {

		public bool selectedAllTargets = true;
		public GameObject targetObjPrefab;
		public string targetTag1;

		public float tileWidth = 2f;
		public float tileHeight = 2f;
		int index;

		public string levelFile = "level1.txt";
		public GameObject[] buttons;
		GameObject currentObj;

		public QuestionTag tag;

		//LEVEL GENERATED
		// Use this for initialization
		void Start () {
		
			// Reading the file into string.
			string levelString = File.ReadAllText(Application.dataPath + Path.DirectorySeparatorChar + levelFile);

			// Splitting the string into lines.
			string[] levelLines = levelString.Split('\n');
			int width = 0;
			// Iterating over the lines.
			for (int row = 0; row < levelLines.Length; row++) {
				string currentLine = levelLines[row];
				width = currentLine.Length;
				// Iterating over all the chars in a line.
				for (int col = 0; col < currentLine.Length; col++) {
					char currentChar = currentLine[col];
					if (currentChar == 'b') {
						GameObject currentButton = Instantiate(buttons[Random.Range(0, buttons.Length)]);
						currentButton.transform.parent = transform;
						currentButton.transform.position = new Vector3(col*tileWidth, -row*tileHeight, 0);
					}
					else if (currentChar == 's') {

						GameObject appleObj = Instantiate(targetObjPrefab);
						appleObj.transform.parent = transform;
						appleObj.transform.position = new Vector3(col*tileWidth, -row*tileHeight, 0);
					}
				}
			}
			buttons = GameObject.FindGameObjectsWithTag("button");
	//		Debug.Log (buttons.Length);
	//		float myX = -(width*tileWidth)/2f + tileWidth/2f;
	//		float myY = (levelLines.Length*tileHeight)/2f - tileHeight/2f;
	//		transform.position = new Vector3(myX, myY, 0);

			// If we were centering the level by moving the camera
			//float cameraY = -(levelLines.Length*tileHeight)/2f + tileHeight/2f;
			//float cameraX = (width*tileWidth)/2f - tileWidth/2f;
			//Camera.main.transform.position = new Vector3(cameraX, cameraY, -10);

		}
		

		void Update () {
			checkButtons ();
			Debug.Log (selectedAllTargets);
		}


		// Check whether the player selected the correct buttons
		public void checkButtons() {


			foreach (GameObject buttonObj in buttons) {
				string buttonTag1 = buttonObj.GetComponent<ImageTag>().ButtonImageTag1;
				string buttonTag2 = buttonObj.GetComponent<ImageTag>().ButtonImageTag2;
				bool buttonIsSelected = buttonObj.GetComponent<ImageTag> ().isSelected;
				string questionTag = tag.QuestionType;


				if (buttonTag1 == targetTag1) {
					if (buttonIsSelected == true) {
						// We found a button that's a duck that we didn't select, therefore we have not selected all ducks
						selectedAllTargets = true;
					} else {
						selectedAllTargets = false;
						return;
					}
				}

				if (buttonTag1 != targetTag1) {
					if (buttonIsSelected == true) {
						// We found a button that's NOT a duck that we DID select, therefore we have not selected ONLY the ducks.
						selectedAllTargets = false;
						return;
					} else {
						selectedAllTargets = true;
					}
				}

			

	//
	//				if (buttonTag1 != targetTag1 && buttonTag2 != targetTag2) {
	//					if (buttonIsSelected == true) {
	//						selectedAllTargets = false;
	//						return;
	//					} else {
	//						selectedAllTargets = true;
	//					}
	//				}
	//			}
			}
		
		}
	}
}
