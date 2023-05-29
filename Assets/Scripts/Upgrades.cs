using SpaceShooter;
using System;
using UnityEngine;


namespace TowerDefense
{
    public class Upgrades : MonoSingleton<Upgrades>
    {
        public const string filename = "upgrades.dat";


        [Serializable]
        private class UpgradeSave
        {
            public UpgradeAsset asset;
            public int level = 0;
        }
        [SerializeField] private UpgradeSave[] save;

        private new void Awake()
        {
            base.Awake();
            Saver<UpgradeSave[]>.TryLoad(filename, ref save);

        }

        public static void BuyUpgrade(UpgradeAsset asset) 
        {
            foreach (var upgrade in Instance.save)
            {
                if (upgrade.asset == asset)
                {
                    upgrade.level += 1;
                    Saver<UpgradeSave[]>.Save(filename, Instance.save);
                    
                }
            }
        }


        public static int GetTotalCost()
        {
            int result = 0;
            foreach (var upgrade in Instance.save)
            {
                //Debug.Log($"upgrade.asset: {upgrade.asset.name} upgrade.level: {upgrade.level}");
                if (upgrade.asset.name =="FireUpgrade" && upgrade.level > 0)
                {
                    Fire.m_FireOpen = true;
                    Fire.m_FireLevel= upgrade.level;
                }
                if (upgrade.asset.name == "SlowUpgrade" && upgrade.level > 0)
                {
                    Slow.m_SlowOpen = true;
                    Slow.m_SlowLevel = upgrade.level;
                }
                for (int i = 0; i < upgrade.level; i++)
                {
                    result += upgrade.asset.costByLevel[i];
                }
            }
            
            return result;
        }

        public static int GetUpgradeLevel(UpgradeAsset asset)
        {
            foreach (var upgrade in Instance.save)
            {
                if (upgrade.asset == asset)
                {
                    
                    return upgrade.level;
                }
            }
            return 0;
        }
    }
}

