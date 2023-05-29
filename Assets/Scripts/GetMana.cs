using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class GetMana : MonoBehaviour
    {
        public static int m_Mana = 0;
        [SerializeField] private Text m_ManaText;
        public static int m_SummMana = 0;
        private void Update()
        {
            m_ManaText.text = m_SummMana.ToString();
            
        }
    }
}

