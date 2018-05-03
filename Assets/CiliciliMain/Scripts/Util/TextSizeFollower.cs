/*******************************************************************
** 文件名:    TextSizeFollower.cs
** 版  权:    (C) 深圳冰川网络技术有限公司 2016 - Speed
** 创建人:    李旸
** 日  期:    2016/4/9
** 版  本:    1.0
** 描  述:    通用的跟踪可变文本位置与大小脚本
** 应  用:    主要用于将文本的背景与可变长文本实时对齐

**************************** 修改记录 ******************************
** 修改人:    
** 日  期:    
** 描  述:    
********************************************************************/


using UnityEngine;
using UnityEngine.UI;

    /// <summary>
    /// 跟踪的文本的ContentSizeFitter可变长模式，在PREFAB中需要手动选择类型
    /// </summary>
    public enum TextSizeFollowType
    {
        Vertical=0,//垂直方向可变长，水平方向不变
        Horizontal=1,//水平方向可变长，垂直方向不变,
        Both//两个方向一起跟踪
    }

    public class TextSizeFollower : MonoBehaviour
    {
        public TextSizeFollowType textSizeFollowType=TextSizeFollowType.Vertical;
        public Text TargetTextToFollow;//跟踪的文本
        public ContentSizeImmediate m_contentSizeImmediate;
        private RectTransform TargetRectToFollow;
        private RectTransform m_thisRectTransform;
        public Vector2 Padding;//大小的相对变化
        public Vector3 Offset;//位置的相对位移
        //int _reloadScrollerFrameCountLeft = -1;//内部计数器，用来在第二帧重新刷新最佳尺寸
        //private Image m_image;
        //private RawImage m_rawimage;

        private bool m_Inited = false;
        void Awake()
        {
            //分辨率适配/
            if (!m_Inited)
            {
                Init();
            }
        }

        void Init()
        {
            m_thisRectTransform = GetComponent<RectTransform>();
            TargetRectToFollow = TargetTextToFollow.GetComponent<RectTransform>();
            m_contentSizeImmediate = TargetTextToFollow.GetComponent<ContentSizeImmediate>();
            //m_image = GetComponent<Image>();
            //m_rawimage = GetComponent<RawImage>();
            m_Inited = true;
        }

        /// <summary>
        /// 跟踪变化的函数，需要文本框被传入文本时从外部调用
        /// </summary>
        public void FollowTargetSize()
        {
            if (!m_Inited)
            {
                Init();
            }
            /*if (!gameObject.activeInHierarchy)
            {
                return;
            }*/
            if (m_thisRectTransform == null)
            {
                m_thisRectTransform = GetComponent<RectTransform>();
            }
            //一帧内做判断，只能跟踪高度或长度之一
            if (textSizeFollowType == TextSizeFollowType.Vertical)
            {
                m_thisRectTransform.sizeDelta = new Vector2(TargetRectToFollow.rect.width + Padding.x, TargetTextToFollow.preferredHeight + Padding.y);
            }
            else if (textSizeFollowType == TextSizeFollowType.Horizontal)
            {
                m_thisRectTransform.sizeDelta = new Vector2(TargetTextToFollow.preferredWidth + Padding.x, TargetRectToFollow.rect.height + Padding.y);
            }
            //用两帧等刷新，可以同时跟踪长度和高度
            else
            {
                if (m_contentSizeImmediate != null)
                {
                    m_thisRectTransform.sizeDelta = new Vector2(
                        m_contentSizeImmediate.GetPreferredSize().x + Padding.x,
                        m_contentSizeImmediate.GetPreferredSize().y + Padding.y);
                }
                else
                {
                    LayoutElement layoutElement = TargetRectToFollow.GetComponent<LayoutElement>();
                    if (layoutElement != null)
                    {
                        float preferredWidth = layoutElement.preferredWidth;
                        //float preferredHeight = TargetRectToFollow.GetComponent<LayoutElement>().preferredHeight;
                        m_thisRectTransform.sizeDelta = new Vector2(preferredWidth + Padding.x,TargetTextToFollow.preferredHeight + Padding.y);
                    }
                    else
                    {
                        m_thisRectTransform.sizeDelta = new Vector2(TargetRectToFollow.rect.width + Padding.x,TargetTextToFollow.preferredHeight + Padding.y);
                    }
                }
                /*if (m_image != null)
                {
                    m_image.enabled=true;
                }
                if (m_rawimage != null)
                {
                    m_rawimage.enabled=true;
                }
                _reloadScrollerFrameCountLeft = 1;*/
            }
            //m_thisRectTransform.sizeDelta = new Vector2(TargetTextToFollow.preferredWidth + Padding.x, TargetTextToFollow.preferredHeight + Padding.y);


            //For Test +new Vector3(0.0001f,0.0001f,0.0001f)避免magnitude zero错误 
            m_thisRectTransform.localPosition = TargetRectToFollow.localPosition + Offset+new Vector3(0.0001f,0.0001f,0.0001f);
        }

        /// <summary>
        /// In this function, we will reload the scroller on multiple frames.
        /// This is because the content size fitter in the cell view doesn't process
        /// the sizes until a frame after the text is set. Since we need the size of the
        /// fitter, we have to keep reloading until the data is available.
        /// </summary>
        /*void LateUpdate()
        {
            // only process if we have a countdown left
            if (_reloadScrollerFrameCountLeft != -1)
            {
                // skip the first frame (frame countdown 1) since it is the one where we set up the scroller text.
                if (_reloadScrollerFrameCountLeft < 1)
                {

                    // reload two times, the first to put the newly set content size fitter values into the model,
                    // the second to set the scroller's cell sizes based on the model.
                    textSizeFollowType = TextSizeFollowType.Both;
                    FollowTargetSize();
                    if (m_image != null)
                    {
                        m_image.enabled=true;
                    }
                    if (m_rawimage != null)
                    {
                        m_rawimage.enabled=true;
                    }
                    _reloadScrollerFrameCountLeft--;
                    //FollowTargetSize(true);
                }

                // decrement the frame count
                _reloadScrollerFrameCountLeft--;
            }
        }*/
        public float GetHeight()
        {
            
            if (textSizeFollowType == TextSizeFollowType.Vertical)
            {
                return TargetTextToFollow.preferredHeight + Padding.y;
            }
            else if(textSizeFollowType==TextSizeFollowType.Horizontal)
            {
                return TargetTextToFollow.rectTransform.sizeDelta.x+ Padding.x;
            }
            else
            {
                if (m_contentSizeImmediate != null)
                {
                    return  m_contentSizeImmediate.GetPreferredSize().y + Padding.y;
                }
                
            }
            return m_thisRectTransform.sizeDelta.y;
        }

        public float GetWidth()
        {

            if (textSizeFollowType == TextSizeFollowType.Vertical)
            {
                return TargetTextToFollow.rectTransform.sizeDelta.y+ Padding.y;
            }
            else if (textSizeFollowType == TextSizeFollowType.Horizontal)
            {
                return TargetTextToFollow.preferredWidth + Padding.x;
            }
            else
            {
                if (m_contentSizeImmediate != null)
                {
                    return m_contentSizeImmediate.GetPreferredSize().x + Padding.x;
                }

            }
            return m_thisRectTransform.sizeDelta.x;
        }
    }

