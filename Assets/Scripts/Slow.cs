using SpaceShooter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class Slow : MonoBehaviour
    {
        //[SerializeField] private GameObject m_Slow;
        [SerializeField] private GameObject m_ButtonSlow;
        [SerializeField] private Text m_Money;

        public static bool m_SlowOpen = false;
        public static int m_SlowLevel;
        public static bool m_Click = false;

        private void Start()
        {
            if (m_SlowOpen)
            {
                m_ButtonSlow.SetActive(true);
            }
            else
            {
                m_ButtonSlow.SetActive(false);
            }
            m_ButtonSlow.GetComponent<Button>().interactable= false;
        }
        private void Update()
        {

            currentTime = LevelController.Instance.LevelTime;
            //if (endTime + 5 < currentTime)
            //{
            //    m_ButtonSlow.GetComponent<Button>().interactable = true;
            //}
            if (m_Click)
            {
                endTime = currentTime;
                m_Click= false;
            }
            if (GetMana.m_SummMana < 5 || endTime + 5 > currentTime)
            {
                m_ButtonSlow.GetComponent<Button>().interactable = false;
            }
            if (GetMana.m_SummMana >= 5  && endTime + 5 < currentTime)
            {
                m_ButtonSlow.GetComponent<Button>().interactable = true;
            }
        }
        float currentTime;
        float endTime;

        //public void ArmagedonPlay()
        //{
        //    Instantiate(m_Slow,transform.position, Quaternion.identity);
        //    endTime= currentTime;
        //    TDPlayer.Instance.ChangeGold(-20);
        //    m_ButtonSlow.GetComponent<Button>().interactable = false;
        //}
    }
}

