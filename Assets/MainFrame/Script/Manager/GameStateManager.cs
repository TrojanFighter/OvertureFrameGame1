﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.FrameGame
{
//Just keeps track of what our game state is.
	public static class GameStateManager
	{

		//Enum for our game states
		public enum GameState
		{
			
			MailReading=0,
			SavingProgress,
			Gaming,
			Restarting,
			Ending,
			Reset,
		};

		public static GameState STATE = GameState.MailReading;

		//Time since we entered this state
		static float TIME;

		//Helper function that tells us how long this state has been running
		public static float GetCurrentStateTimeElapsed()
		{
			return Time.time - TIME;
		}

		//Helper function that sets the state
		public static void SetCurrentState(GameState TEMP)
		{
			STATE = TEMP;
			TIME = Time.time;
		}
	}
}