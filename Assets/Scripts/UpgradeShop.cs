using System;
using UnityEngine;
using UnityEngine.UI;



namespace TowerDefense
{
    public class UpgradeShop : MonoBehaviour
    {
        [SerializeField] private int money;
        [SerializeField] private Text moneyText;
        [SerializeField] private BuyUpgrade[] sales;

        private void Start()
        {
            
            foreach (var slot in sales)
            {
                slot.Initialize();
                //print(slot.transform.GetComponent<Button>());
                slot.transform.GetComponent<Button>().onClick.AddListener(UpdateMoney);
            }
            UpdateMoney();
        }

        public void UpdateMoney()
        {

            money= MapCompletion.Instance.TotalScore;
            money -= Upgrades.GetTotalCost();
            moneyText.text = money.ToString();
            foreach (var slot in sales)
            {
                slot.CheckCost(money);
            }
        }


    }
}

