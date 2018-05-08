using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Overture.TextReplacement
{
	public class WordReplaceScript : MonoBehaviour
	{

		public string target = "hello"; //default target string- is public so it can be changed in Unity
		int index = 0; //sets character of current target string (string we want to change words to
		bool active = false; //a bool that prevents offscreen words from being affected
		TextMesh textMesh; //var for getting the text mesh component
		public AudioClip typeSound;
		public AudioClip wrongLetterSound;
		public AudioClip returnSound;
		private AudioSource source;

		void Start()
		{
			textMesh = GetComponent<TextMesh>(); //initializing textMesh var
		}

		void Awake()
		{

			source = GetComponent<AudioSource>();

		}

		// Update is called once per frame
		void Update()
		{
			if (active)
			{
				foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode)))
				{
					//Googled this. It allows us to check every possible keycode input at once.
					if (Input.GetKeyUp(code))
					{
						//triggers this if/then upon releasing any key
						var str = code.ToString(); //changes the enum value from numbers to english
						if (str.Length == 1)
						{
							//makes the program only care about 1-character long keycodes
							CheckLetter(System.Char.ToLower(str[0])); //passes lowercase version of released keycode to CheckLetter function
						}
					}
				}

				if (textMesh.text == target)
				{
					//if the textmesh component we just changed doesn't match the target, then run this
					//Player has completed word! Change color and set inactive
					textMesh.color = Color.blue;
					active = false;
					//Play sound
					source.PlayOneShot(returnSound, 1.0f);
				}
			}
		}

		void CheckLetter(char letter)
		{
			//creates variable for keycode passed to this function
			//A custom function! Checks whether the character at the current index matches the target string (which is now set easily in the unity editor)
			if (index >= target.Length)
			{
				return; //Ends the function once the target string has been reached (In gameplay, this means once a word has finished being replaced. Prevents errors.)
			}

			if (target[index] == letter)
			{
				//compares our passed keycode with the intended target. If it matches it, then it proceeds with the if/then
				StringBuilder
					sb = new StringBuilder(textMesh.text, target.Length); //creates the sb variable to refer to stringbuilder
				//Googled StringBuilder. Allows us to edit strings, rather than leaving strings immutable as is default.
				sb.Length = target.Length; //force stringbuilder to be as long as target
				sb[index] = letter; //now that we know the keycode is correct, we can set the current index in the stringbuilder to match it.
				textMesh.text = sb.ToString(); //replaces the text in the textmesh with the value we just set stringbuilder to
				index++; //moved on to the next character
				Debug.Log(letter + " correctly pressed"); //convenient for us
				//Play sound if they typed it correctly
				source.PlayOneShot(typeSound, 0.5f);
			}
			else
			{
				//Play incorrect sound if they typed the wrong letter
				source.PlayOneShot(wrongLetterSound, 0.5f);
			}

		}

		void OnTriggerEnter2D(Collider2D other)
		{
			//calls collider function
			if (other.gameObject.GetComponent<Healthandgameover>())
			{
				//checks to see if we collided with an item that has the healthandgameover script on it
				if (textMesh.text != target)
				{
					//if the textmesh component we just changed doesn't match the target, then run this
					Healthandgameover.health -= 1; //reduces health by 10
					Debug.Log("Health:" + Healthandgameover.health); //convenient for us
				}
			}

			if (other.gameObject.name == "cnndonlemon")
			{
				//sets active to true if it enters screen, so that words can be manipulated
				active = true;
			}
		}

	}
}