using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overture.FrameGame
{
//Just keeps track of what our game state is.
	public static class GameSaveManager
	{

		public static int StoredTRexScore=0, StoredStegosaursScore=0, StoredPterosaursScore=0, StoredFailureCount=0;
		public static List<int> extraEmailsToLoad;

		public static bool hasExtraMail = false;
		
		public static bool hasExtractedScore = false;
		
		public static void StoreScore(int _TRexScore, int _StegosaursScore, int _PterosaursScore, int _FailureCount)
		{
			hasExtractedScore = false;	
			StoredTRexScore = _TRexScore;
			StoredStegosaursScore = _StegosaursScore;
			StoredPterosaursScore = _PterosaursScore;
			StoredFailureCount = _FailureCount;
		}

		public static void ClearStoredScore()
		{
			StoredTRexScore = 0;
			StoredStegosaursScore = 0;
			StoredPterosaursScore = 0;
			StoredFailureCount = 0;
			hasExtractedScore = true;
		}
		
		public static void SpecialEmailStoredToShow(List<int> specialEmailID)
		{
			extraEmailsToLoad = specialEmailID;
		}
	}
}