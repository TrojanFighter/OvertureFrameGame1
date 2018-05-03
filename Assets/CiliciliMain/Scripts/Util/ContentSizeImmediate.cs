/*******************************************************************
** 文件名:    ContentSizeImmediate.cs
** 版  权:    (C) 深圳冰川网络技术有限公司 2016 - Speed
** 创建人:    李旸
** 日  期:    2016/11/15
** 版  本:    1.0
** 描  述:    在当前帧通过ContextSizeFitter立即取得最终值的方法
** 应  用:    

**************************** 修改记录 ******************************
** 修改人:    
** 日  期:    
** 描  述:    
********************************************************************/

using UnityEngine;
using UnityEngine.UI;
using FitMode = UnityEngine.UI.ContentSizeFitter.FitMode;

[RequireComponent(typeof(ContentSizeFitter))]
public class ContentSizeImmediate : MonoBehaviour
{
	private RectTransform m_RectTransform;
	private RectTransform rectTransform
	{
		get
		{
			if (m_RectTransform == null)
				m_RectTransform = GetComponent<RectTransform>();
			return m_RectTransform;
		}
	}

	private ContentSizeFitter m_ContentSizeFitter;
	private ContentSizeFitter contentSizeFitter
	{
		get
		{
			if (m_ContentSizeFitter == null)
				m_ContentSizeFitter = GetComponent<ContentSizeFitter>();
			return m_ContentSizeFitter;
		}
	}
	//立即获取ContentSizeFitter的区域
	public Vector2 GetPreferredSize()
	{
		LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
		return new Vector2(HandleSelfFittingAlongAxis(0), HandleSelfFittingAlongAxis(1));
	}

	private float HandleSelfFittingAlongAxis(int axis)
	{
		FitMode fitting = (axis == 0 ? contentSizeFitter.horizontalFit : contentSizeFitter.verticalFit);
		if (fitting == FitMode.MinSize)
		{
			return LayoutUtility.GetMinSize(rectTransform, axis);
		}
		else
		{
			return LayoutUtility.GetPreferredSize(rectTransform, axis);
		}
	}

}