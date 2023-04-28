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
        private void Awake()
        {
            m_text = GetComponent<Text>();


            switch (source) 
            { 
                case UpdateSource.Gold: 
                    TDPlayer.OnGoldUpdate += UpdateText;
                    break;
                case UpdateSource.Life:
                    TDPlayer.OnLifeUpdate += UpdateText;
                    break;
            }
        }

        private void UpdateText(int life)
        {
            m_text.text = life.ToString();
        }


    }
}

