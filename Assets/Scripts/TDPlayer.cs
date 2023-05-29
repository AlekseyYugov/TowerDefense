using SpaceShooter;
using UnityEngine;
using System;
using Unity.VisualScripting;

namespace TowerDefense
{
    public class TDPlayer : Player
    {
        public static new TDPlayer Instance { get { return Player.Instance as TDPlayer; } }
        private bool ReduseScoreLife = true;

        private static event Action<int> OnGoldUpdate;
        public static void GoldUpdateSub(Action<int> act)
        {
            OnGoldUpdate += act;
            act(Instance.m_gold);

        }
        public static event Action<int> OnLifeUpdate;
        public static void LifeUpdateSub(Action<int> act)
        {
            OnLifeUpdate += act;
            act(Instance.NumLives);
            
        }
        [SerializeField] private int m_gold = 0;
        public void ChangeGold(int change)
        {
            m_gold += change;
            OnGoldUpdate(m_gold);
        }
        public void ReduceLive(int change)
        {
            TakeDamage(change);
            OnLifeUpdate(NumLives);
            
            if (ReduseScoreLife) 
            {
                OnLifeUpdate += TDLevelController.LifeScoreChange;
                ReduseScoreLife= false;
            }
            
        }

        private void LateUpdate()
        {
            OnGoldUpdate(m_gold);
            OnLifeUpdate(NumLives);           

        }

        public void GoldUpdateUnSubscrible(Action<int> act)
        {
            OnGoldUpdate -= act;
        }

        public void LifeUpdateUnSubscrible(Action<int> act)
        {
            OnLifeUpdate -= act;
        }

        //public static void ScoreUpdateUnSubscrible(Action<int> act)
        //{
        //    OnScor -= act;
        //}

        [SerializeField] private Tower m_TowerPrefab;
        public void TryBuild(TowerAsset towerAsset, Transform buildSite)
        {
            ChangeGold(-towerAsset.m_GoldCost);
            var tower = Instantiate(m_TowerPrefab, buildSite.position, Quaternion.identity);
            Destroy(buildSite.gameObject);
        }



        [SerializeField] private UpgradeAsset healthUpgrade;
        public GameObject frostButton;


        

        private void Start()
        {
            var level_1 =  Upgrades.GetUpgradeLevel(healthUpgrade);
            TakeDamage(-level_1 * 5);


            
        }
        
        
    }
}

