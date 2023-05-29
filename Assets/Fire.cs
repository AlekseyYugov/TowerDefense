using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class Fire : MonoBehaviour
    {
        //[SerializeField] private GameObject m_Slow;
        [SerializeField] private GameObject m_ButtonFire;
        [SerializeField] private Text m_Money;

        public static bool m_FireOpen = false;
        
        public static int m_FireLevel;

        [SerializeField] private int Radius;
        //public static bool m_Click = false;

        private void Start()
        {
            if (m_FireOpen)
            {
                m_ButtonFire.SetActive(true);
            }
            else
            {
                m_ButtonFire.SetActive(false);
            }
            Radius = m_FireLevel;
            //m_ButtonSlow.GetComponent<Button>().interactable = false;
        }
        private void Update()
        {

            currentTime = LevelController.Instance.LevelTime;
            //if (endTime + 5 < currentTime)
            //{
            //    m_ButtonSlow.GetComponent<Button>().interactable = true;
            //}
            if (GetMana.m_SummMana < 10)
            {
                m_ButtonFire.GetComponent<Button>().interactable = false;
            }
            if (GetMana.m_SummMana >= 10)
            {
                m_ButtonFire.GetComponent<Button>().interactable = true;
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

