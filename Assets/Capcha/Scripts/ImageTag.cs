using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.Captcha{

	public class ImageTag : MonoBehaviour {

		public bool isSelected = false;
		public string ButtonImageTag1;
		public string ButtonImageTag2;
		public GameObject selectedObj;
		public GameObject frame;


		void OnMouseDown() {

			isSelectedRun ();
		}

		//Instantiate the frame around selected buttons
		void isSelectedRun() {

			if (isSelected == false){
				isSelected = true;
				if (frame == null) {
					frame = Instantiate (selectedObj, this.gameObject.transform);
					frame.transform.localPosition = Vector3.zero;
				}
			}
			else {
				isSelected = false;
				if (frame != null) {
					Destroy (frame);
				}	
			}
		}
	}
}
