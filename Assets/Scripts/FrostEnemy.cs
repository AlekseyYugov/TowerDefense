using SpaceShooter;
using System;
using UnityEngine;
using UnityEngine.UI;


namespace TowerDefense
{
    public class FrostEnemy : MonoBehaviour
    {

        float currentTime;
        float endTime;

        [SerializeField] private GameObject m_ButtonFrost;
        public static bool m_Frost = false;

        [SerializeField] private Text m_Money;

        private void Start()
        {
            if (m_Frost == false)
            {
                m_ButtonFrost.SetActive(false);
            }
            else
            {
                m_ButtonFrost.SetActive(true);
            }
            
        }
        void Update()
        {
            currentTime = LevelController.Instance.LevelTime;
            if (Convert.ToInt32(m_Money.text) < 10)
            {
                m_ButtonFrost.GetComponent<Button>().interactable = false;
            }
            if (endTime < currentTime)
            {
                GoEnemy();
            }
            if (Convert.ToInt32(m_Money.text) >= 10)
            {
                m_ButtonFrost.GetComponent<Button>().interactable = true;
            }
        }

        private void GoEnemy()
        {
            foreach (var enemy in FindObjectsOfType<Enemy>())
            {
                enemy.GetComponent<SpaceShip>().enabled = true;
                enemy.GetComponentInChildren<Animator>().enabled = true;
                enemy.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }
            if (Convert.ToInt32(m_Money.text) >= 10)
            {
                m_ButtonFrost.GetComponent<Button>().interactable = true;
            }
        }
        public void FrostEnemyTrue()
        {
            
            endTime = currentTime + 3f;
            foreach (var enemy in FindObjectsOfType<Enemy>())
            {
                enemy.GetComponent<SpaceShip>().enabled = false;
                enemy.GetComponentInChildren<Animator>().enabled = false;
                enemy.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
                enemy.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                
            }

            TDPlayer.Instance.ChangeGold(-10);

            m_ButtonFrost.GetComponent<Button>().interactable = false;
        }
    }
}


