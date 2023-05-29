using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TowerDefense
{
    public class TowerBuyControl : MonoBehaviour
    {
        [SerializeField] private TowerAsset m_TowerAsset;
        public void SetTowerAsset(TowerAsset asset) { m_TowerAsset= asset; }
        //[SerializeField] private Image m_Image;

        [SerializeField] private Text m_TextMoney;
        [SerializeField] private Button m_Button;


        private void Start()
        {
            m_TextMoney.text = m_TowerAsset.m_GoldCost.ToString();
            //m_TextMoneyTowerFire.text = m_TowerAsset.m_GoldCostTowerFire.ToString();
            //m_TextMoneyTowerMetal.text = m_TowerAsset.m_GoldCostTowerMetal.ToString();
            //m_TextMoneyTowerBoulder.text = m_TowerAsset.m_GoldCostTowerBoulder.ToString();
            
            TDPlayer.GoldUpdateSub(GoldStatusCheck);
            
        }



        private void GoldStatusCheck(int gold)      
        {


            if (gold >= m_TowerAsset.m_GoldCost != m_Button.interactable)
            {
                m_Button.interactable = !m_Button.interactable;
                m_TextMoney.color = m_Button.interactable ? Color.white : Color.red;
                //}
                //if (gold >= m_TowerAsset.m_GoldCostTowerFire != m_ButtonCreateTowerFire.interactable)
                //{
                //    m_ButtonCreateTowerFire.interactable = !m_ButtonCreateTowerFire.interactable;
                //    m_TextMoneyTowerFire.color = m_ButtonCreateTowerFire.interactable ? Color.white : Color.red;
                //}
                //if (gold >= m_TowerAsset.m_GoldCostTowerMetal != m_ButtonCreateTowerMetal.interactable)
                //{
                //    m_ButtonCreateTowerMetal.interactable = !m_ButtonCreateTowerMetal.interactable;
                //    m_TextMoneyTowerMetal.color = m_ButtonCreateTowerMetal.interactable ? Color.white : Color.red;
                //}
                //if (gold >= m_TowerAsset.m_GoldCostTowerBoulder != m_ButtonCreateTowerBoulder.interactable)
                //{
                //    m_ButtonCreateTowerBoulder.interactable = !m_ButtonCreateTowerBoulder.interactable;
                //    m_TextMoneyTowerBoulder.color = m_ButtonCreateTowerBoulder.interactable ? Color.white : Color.red;
                //}
            }
        }
        private void OnDestroy()
        {
            TDPlayer.Instance.GoldUpdateUnSubscrible(GoldStatusCheck);
    }
    }
}

