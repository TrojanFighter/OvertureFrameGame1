using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overture.CensorBar
{

	public class StartSceneScript : MonoBehaviour
	{
		// StartSceneScript Script


		public KeyCode startKey; // var for our startKey, assigned in the inspector



		void Update()
		{
			// Update Function
			if (Input.GetKeyDown(startKey)) // if the startKey is pressed, THEN
				SceneManager.LoadScene("CHIXXX"); // use the SceneManager ot load the scene named "CHIXX"

		} //END UPDATE FUNCTION

	} //END START SCENE SCRIPT
}