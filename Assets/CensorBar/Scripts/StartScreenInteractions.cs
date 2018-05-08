using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.CensorBar
{

	public class StartScreenInteractions : MonoBehaviour
	{
		// StartScreenInteractions Script
		// to control the behaviour and movement of the censor bar on the start screen
		// including movment and the overlap detection 


		public KeyCode upKey; // var for our up key , assigned in the inspector
		public KeyCode downKey; // var for our down key , assigned in the inspector
		public KeyCode leftKey; // var for our left key , assigned in the inspector
		public KeyCode rightKey; // var for our right key , assigned in the inspector

		private Rigidbody2D rb; // var for our rigigbody

		public float rateOfHorizontalSpeed; // var for the rate of horizontal speed
		public float rateOfVerticalSpeed; // var for the rate of vertical speed
		public float horizontalForce; // var for the rate of horizontal force
		public float verticalForce; // var for the rate of vertical force



		void Start()
		{
			// Start Function
			rb = GetComponent<Rigidbody2D>(); // assign the var 'rb' to the rigidbody2D component of this game object
		} //END START


		void FixedUpdate()
		{
			// FixedUpdate Function

			if (Input.GetKey(upKey)) // if the upKey is pressed
				moveUp(); // run the moveUp function

			if (Input.GetKey(downKey)) // if the downKey is pressed
				moveDown(); // run the moveDown function

			if (Input.GetKey(leftKey)) // if the leftKey is pressed
				moveLeft(); // run the moveLeft function

			if (Input.GetKey(rightKey)) // if the rightKey is pressed
				moveRight(); // run the moveRight function

			//else rb.velocity = new Vector2(0,0);  								// else, the velocity of the rigidbody is zero

//	if (rb.renderer.bounds.Intersects(object2.renderer.bounds)) {
// do something
// }
//		if (GameObject.FindGameObjectsWithTag ("DetectionZone"))  {
//		}
//		https://docs.unity3d.com/ScriptReference/Collider2D.OverlapPoint.html


		} //END FIXED UPDATE

		void moveUp()
		{
			// moveUP Function
			rb.AddForce(Vector2.up *
			            verticalForce); // add force to the rb (rigidbody) using Vector2.up (a built in unity vector2 value of 0,1), 
			// multiplied by our verticalForce variable
		} //END MOVE UP

		void moveDown()
		{
			// moveDown Function 
			rb.AddForce(Vector2.down *
			            verticalForce); // add force to the rb (rigidbody) using Vector2.down (a built in unity vector2 value of 0,-1), 
			// multiplied by our verticalForce variable
		} //END MOVE DOWN

		void moveLeft()
		{
			// moveLeft Function
			rb.AddForce(Vector2.left *
			            horizontalForce); // add force to the rb (rigidbody) using Vector2.left (a built in unity vector2 value of -1,0), 
			// multiplied by our horizonalForce variable
		} //END MOVE LEFT

		void moveRight()
		{
			// moveRight Function
			rb.AddForce(Vector2.right *
			            horizontalForce); // add force to the rb (rigidbody) using Vector2.right (a built in unity vector2 value of 1,0), 
			// multiplied by our horizonalForce variable
		} //END MOVE RIGHT


	} //END START SCREEN INTERACTIONS SCRIPT
}