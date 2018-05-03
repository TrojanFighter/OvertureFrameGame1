using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Overture.Capcha
{
	public class ButtonCutScreen : MonoBehaviour
	{

		Button buttonCutScreen;

		// Use this for initialization
		void Start()
		{
			buttonCutScreen = GetComponent<Button>();
			buttonCutScreen.onClick.AddListener(Submit);
		}

		public void Submit()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}