﻿using UnityEngine;
using UnityEngine.UI;

namespace DialogueEditor
{
    public class UIConversationButton : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI TextMesh;
        public Image OptionBackgroundImage;

        private OptionNode m_option;
        private SpeechNode m_action;

        public void SetImage(Sprite sprite, bool sliced)
        {
            if (sprite != null)
            {
                OptionBackgroundImage.sprite = sprite;

                if (sliced)
                    OptionBackgroundImage.type = Image.Type.Sliced;
                else
                    OptionBackgroundImage.type = Image.Type.Simple;
            }
        }

        public void SetAlpha(float a)
        {
            Color c_image = OptionBackgroundImage.color;
            Color c_text = TextMesh.color;
            c_image.a = a;
            c_text.a = a;
            OptionBackgroundImage.color = c_image;
            TextMesh.color = c_text;
        }

        public void SetOption(OptionNode option)
        {
            m_option = option;
            TextMesh.text = option.Text;
        }

        public void SetAction(SpeechNode action)
        {
            m_action = action;
            TextMesh.text = "Continue.";
        }

        public void SetAsEndConversation()
        {
            m_option = null;
            TextMesh.text = "End.";
        }

        public void OnOptionSelected()
        {
            if (m_action != null)
                ConversationManager.Instance.DoAction(m_action);
            else
                ConversationManager.Instance.OptionSelected(m_option);
        }
    }
}