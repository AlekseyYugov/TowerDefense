using System;
using UnityEngine;
using UnityEngine.UI;



namespace TowerDefense
{
    public class BuyUpgrade : MonoBehaviour
    {
        [SerializeField] private UpgradeAsset m_Asset;
        [SerializeField] private Image m_UpgradeIcon;
        private int m_CostNumber = 0;
        [SerializeField] private Text m_Level, m_CostText;
        [SerializeField] private Button m_BuyButton;

        public void Initialize()
        {
            m_UpgradeIcon.sprite = m_Asset.sprite;
            var savedLevel = Upgrades.GetUpgradeLevel(m_Asset);

            if (savedLevel >= m_Asset.costByLevel.Length)
            {
                m_Level.text = "(Max)";
                m_BuyButton.interactable= false;
                m_BuyButton.transform.Find("ImageStar").gameObject.SetActive(false);
                m_CostText.text = "X";
                m_CostNumber = int.MaxValue;
            }
            else
            {
                m_Level.text = $"level {savedLevel + 1}";
                m_CostNumber = m_Asset.costByLevel[savedLevel];
                m_CostText.text = $"buy {m_Asset.costByLevel[savedLevel]}";
            }

            
        }

        public void Buy()
        {
            Upgrades.BuyUpgrade(m_Asset);
            Initialize();
        }

        public void CheckCost(int money)
        {
            m_BuyButton.interactable = money >= m_CostNumber;
        }
    }
}

