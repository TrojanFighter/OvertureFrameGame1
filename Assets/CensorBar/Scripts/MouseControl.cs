using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.CensorBar
{

	public class MouseControl : MonoBehaviour
	{
		// MouseControl Script
		// attach to censor bar or enable the script to 
		// control the censor bar via mouse movement

		Rigidbody2D rb; // var to rename our rigidbody to rb as a shortcut
		public float startX; // var for our game object's starting x position
		public float startY; // var for our game object's starting y position


		void Start()
		{
			// Start Function
			rb = GetComponent<Rigidbody2D>(); // assign our var 'rb' to the rigidbody component of this game object
			startX = transform.position.x; // assign our var 'startX' to the x value of the transform posistion
			startY = transform.position.y; // assign our var 'startY' to the y value of the transform posistion

		} //END START


		void FixedUpdate()
		{
			// FixedUpdate Function
			this.gameObject.transform.position =
				Input.mousePosition; // this game object's transform position is equal to the position of the mouse
			rb.transform.position =
				Input.mousePosition; // this game object's rigidbody position is equal to the position of the mouse

		} //END UPDATE

	} //END SCRIPT
}