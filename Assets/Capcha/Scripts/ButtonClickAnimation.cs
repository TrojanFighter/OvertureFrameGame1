using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overture.Capcha
{
	public class ButtonClickAnimation : MonoBehaviour
	{

		public Sprite retryPushed;
		public Sprite continuePushed;
		public Sprite submitPushed;
		Button submitButton;

		// Use this for initialization
		void Start()
		{
			submitButton = GetComponent<Button>();
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButton(0))
			{
				if (submitButton.image.sprite.name == "submit-b")
				{
					submitButton.image.sprite = submitPushed;
				}

				if (submitButton.image.sprite.name == "forward")
				{
					submitButton.image.sprite = continuePushed;
				}

				if (submitButton.image.sprite.name == "reload")
				{
					submitButton.image.sprite = retryPushed;
				}
			}
		}
	}
}