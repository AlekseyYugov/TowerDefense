using SpaceShooter;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu]
    public class TowerAsset: ScriptableObject
    {        
        public int m_GoldCost = 10;
        public Sprite sprite;
        //public Sprite GUISprite;
        public TurretProperties m_TurretProperties;
        [SerializeField] private UpgradeAsset m_RequiredUpgrade;
        [SerializeField] private int m_RequiredUpgradeLevel;
        public bool IsAvailable() => !m_RequiredUpgrade || m_RequiredUpgradeLevel <= Upgrades.GetUpgradeLevel(m_RequiredUpgrade);

        public TowerAsset[] m_UpgradesTo;
    }
}

