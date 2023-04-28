using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TowerDefense
{
    public class TowerByControl : MonoBehaviour
    {
        [SerializeField] private TowerAsset m_TA;
        //[SerializeField] private Image m_Image;

        [SerializeField] private Text m_TextMoneyTowerStone;
        [SerializeField] private Button m_ButtonCreateTowerStone;

        [SerializeField] private Text m_TextMoneyTowerFire;
        [SerializeField] private Button m_ButtonCreateTowerFire;

        [SerializeField] private Text m_TextMoneyTowerMetal;
        [SerializeField] private Button m_ButtonCreateTowerMetal;

        [SerializeField] private Text m_TextMoneyTowerBoulder;
        [SerializeField] private Button m_ButtonCreateTowerBoulder;

        private void Awake()
        {
            TDPlayer.OnGoldUpdate += GoldStatusCheck;            
        }

        private void Start()
        {
            m_TextMoneyTowerStone.text = m_TA.m_GoldCostTowerStone.ToString();
            m_TextMoneyTowerFire.text = m_TA.m_GoldCostTowerFire.ToString();
            m_TextMoneyTowerMetal.text = m_TA.m_GoldCostTowerMetal.ToString();
            m_TextMoneyTowerBoulder.text = m_TA.m_GoldCostTowerBoulder.ToString();
            //m_Image.sprite= m_TA.GUISprite;
        }


        private void GoldStatusCheck(int gold)
        {
            if (gold >= m_TA.m_GoldCostTowerStone != m_ButtonCreateTowerStone.interactable)
            {
                m_ButtonCreateTowerStone.interactable = !m_ButtonCreateTowerStone.interactable;
                m_TextMoneyTowerStone.color = m_ButtonCreateTowerStone.interactable? Color.white : Color.red;
            }
            if (gold >= m_TA.m_GoldCostTowerFire != m_ButtonCreateTowerFire.interactable)
            {
                m_ButtonCreateTowerFire.interactable = !m_ButtonCreateTowerFire.interactable;
                m_TextMoneyTowerFire.color = m_ButtonCreateTowerFire.interactable ? Color.white : Color.red;
            }
            if (gold >= m_TA.m_GoldCostTowerMetal != m_ButtonCreateTowerMetal.interactable)
            {
                m_ButtonCreateTowerMetal.interactable = !m_ButtonCreateTowerMetal.interactable;
                m_TextMoneyTowerMetal.color = m_ButtonCreateTowerMetal.interactable ? Color.white : Color.red;
            }
            if (gold >= m_TA.m_GoldCostTowerBoulder != m_ButtonCreateTowerBoulder.interactable)
            {
                m_ButtonCreateTowerBoulder.interactable = !m_ButtonCreateTowerBoulder.interactable;
                m_TextMoneyTowerBoulder.color = m_ButtonCreateTowerBoulder.interactable ? Color.white : Color.red;
            }
        }
    }
}

