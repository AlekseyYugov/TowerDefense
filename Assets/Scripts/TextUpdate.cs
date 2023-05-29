using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TowerDefense
{
    public class TextUpdate : MonoBehaviour
    {
        public enum UpdateSource
        {
            Gold,
            Life
        }
        public UpdateSource source = UpdateSource.Gold;
        private Text m_text;
        private void Start()
        {
            m_text = GetComponent<Text>();


            switch (source) 
            { 
                case UpdateSource.Gold: 
                    TDPlayer.GoldUpdateSub(UpdateText);
                    break;
                case UpdateSource.Life:
                    TDPlayer.LifeUpdateSub(UpdateText);
                    break;
            }
        }

        private void UpdateText(int life)
        {
            if (m_text == null) return;
            m_text.text = life.ToString();
        }


    }
}

