using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overture.TextReplacement
{
	public class HealthDisplayScript : MonoBehaviour
	{

		Text myText;

		// Use this for initialization
		void Start()
		{
			myText = GetComponent<Text>(); //sets a variable for getting the UI text component
		}

		// Update is called once per frame
		void Update()
		{
			myText.text = "UNCENSORED WORD LIMIT: " + Healthandgameover.health; //displays health on the UI text
		}
	}
}