using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Overture.CommentCensor
{
	public class DataManager :Singleton<DataManager>
	{
		//public static GameManager Instance;
		public static Dictionary<int, Comment> CommentDic;


		public override void Init()
		{
			base.Init();
			if (Application.platform == RuntimePlatform.Android) {
				
//				Debug.Log ("ASSET PATH: " + Application.streamingAssetsPath + GlobalDefine.PathDefines.XML_Path +
//					GlobalDefine.FileName.SoldierType);
//				Debug.Log ("FILE EXISTS: " + System.IO.File.Exists (Application.streamingAssetsPath + GlobalDefine.PathDefines.XML_Path +
//					GlobalDefine.FileName.SoldierType));
//				SoldierTypes = XMLReader.ReadSoldierTypeFile("file:///android_asset/XML/" + GlobalDefine.FileName.SoldierType);
//				Fractions = XMLReader.ReadFractionsFile(Application.streamingAssetsPath + GlobalDefine.PathDefines.XML_Path +
//					GlobalDefine.FileName.Fraction);

				CommentDic = XMLReader.ReadCommentsFile(Application.streamingAssetsPath + GlobalDefine.PathDefines.XML_Path +
					GlobalDefine.FileName.Comments);
			} else {
				CommentDic = XMLReader.ReadCommentsFile(Application.dataPath + GlobalDefine.PathDefines.XML_Path +
					GlobalDefine.FileName.Comments);
			}
		}

		public override void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
