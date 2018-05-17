using System;
using UnityEngine;
using System.Collections.Generic;
using System.Xml;

namespace Overture.CommentCensor
{

public static class XMLReader{
	public static Dictionary<int,Comment> ReadCommentsFile(string path)
	{
		Dictionary<int,Comment> commentList = new Dictionary<int, Comment>();
		XmlDocument xDoc = new XmlDocument();
			// Android hack fix that doesn't require filepath
//			if (Application.platform == RuntimePlatform.Android) {
//				TextAsset soldierXML = Resources.Load<TextAsset> ("XML/Soldiers");
//				xDoc.LoadXml (soldierXML.commentText);
//			} else {
//				xDoc.Load (path);
//			}
			//TextAsset commentsXML = Resources.Load<TextAsset> (path);
			//Debug.Log (commentsXML.text);
			//xDoc.LoadXml (commentsXML.text);
		xDoc.Load (path);
		XmlNamespaceManager xnm = new XmlNamespaceManager(xDoc.NameTable);
		xnm.AddNamespace("WB", "urn:schemas-microsoft-com:office:spreadsheet");
		XmlElement root = xDoc.DocumentElement;
		XmlNodeList rows = root.SelectNodes("/WB:Workbook/WB:Worksheet/WB:Table/WB:Row", xnm);

		for (int i = 3; i < rows.Count; i++)
		{
			XmlElement rowNode = rows[i] as XmlElement;
			if (rowNode != null)
			{
				Comment newcomment = new Comment();
				//评论ID
				//Debug.LogWarning(GetInnerData(rowNode.ChildNodes[0]));
				newcomment.commentID = int.Parse(GetInnerData(rowNode.ChildNodes[0]));

				newcomment.commentText = GetInnerData(rowNode.ChildNodes[1]);

				newcomment.InVideoTime= float.Parse(GetInnerData(rowNode.ChildNodes[2]));

				newcomment.date = DateTime.Parse(GetInnerData(rowNode.ChildNodes[3]));//, "mm/dd/yyyy",System.Globalization.CultureInfo.InvariantCulture);//new DateTime(); //(GetInnerData(rowNode.ChildNodes[3]));
				
				newcomment.CommenterName=(GetInnerData(rowNode.ChildNodes[4]));

				newcomment.offset=int.Parse( GetInnerData(rowNode.ChildNodes[5]));

				newcomment.m_correctCensorTypes =(GlobalDefine.CensorTypes)int.Parse( GetInnerData (rowNode.ChildNodes [6]));
				newcomment.upvoteReaction =( GetInnerData (rowNode.ChildNodes [7]));
				newcomment.muteReaction =( GetInnerData (rowNode.ChildNodes [8]));
				
				newcomment.TRexesReactionUp =float.Parse( GetInnerData (rowNode.ChildNodes [9]));
				newcomment.StegosaursReactionUp =float.Parse( GetInnerData (rowNode.ChildNodes [10]));
				newcomment.PterosaursReactionUp =float.Parse( GetInnerData (rowNode.ChildNodes [11]));
				
				newcomment.TRexesReactionDoNothing =float.Parse( GetInnerData (rowNode.ChildNodes [12]));
				newcomment.StegosaursReactionDoNothing =float.Parse( GetInnerData (rowNode.ChildNodes [13]));
				newcomment.PterosaursReactionDoNothing =float.Parse( GetInnerData (rowNode.ChildNodes [14]));
				
				newcomment.TRexesReactionRemove =float.Parse( GetInnerData (rowNode.ChildNodes [15]));
				newcomment.StegosaursReactionRemove =float.Parse( GetInnerData (rowNode.ChildNodes [16]));
				newcomment.PterosaursReactionRemove =float.Parse( GetInnerData (rowNode.ChildNodes [17]));

				commentList.Add(newcomment.commentID,newcomment);
				//Debug.Log("Comment: "+newcomment.commentID+" "+newcomment.commentText);
			}
		}
		return commentList;
	}



	private static string GetInnerData(XmlNode node) {
		if (node.ChildNodes[0] != null)
		{
			return node.ChildNodes[0].InnerText;
		}
		else {
			return string.Empty;
		}
	}


}
	
}

