using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefense
{
    public class EnemyWaveManager : MonoBehaviour
    {
        public static event Action<Enemy> OnEnemySpawn;
        [SerializeField] private Path[] m_Paths;
        [SerializeField] private EnemyWave m_CurrentWave;
        [SerializeField] private Enemy m_EnemyPrefabs;
        private int m_ActiveEnemyCount = 0;
        public event Action OnAllWavesDead;

        private void RecordEnemyDeath()
        {
            if (--m_ActiveEnemyCount == 0)
            {
                ForceNextWave();
            }
        }

        private void Start()
        {
            m_CurrentWave.Prepare(SpawnEnemies);
        }
        private void SpawnEnemies()
        {
            foreach ((EnemyAsset asset, int count, int pathIndex) in m_CurrentWave.EnumerateSquads())
            {
                if (pathIndex < m_Paths.Length)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var e = Instantiate(m_EnemyPrefabs, m_Paths[pathIndex].StartArea.RandomInsideZone, Quaternion.identity);
                        e.OnEnd += RecordEnemyDeath;
                        e.Use(asset);
                        e.GetComponent<TDPatrolController>().SetPath(m_Paths[pathIndex]);
                        m_ActiveEnemyCount++;
                        OnEnemySpawn?.Invoke(e);
                    }                    
                }
                else
                {
                    Debug.LogWarning($"Invalid pathIndex in {name}");
                }
                
            }


            m_CurrentWave = m_CurrentWave.PrepareNext(SpawnEnemies);
        }

        public void ForceNextWave()
        {
            if(m_CurrentWave)
            {
                TDPlayer.Instance.ChangeGold((int)m_CurrentWave.GetRemaingTime());
                SpawnEnemies();
            }
            else
            {
                if(m_ActiveEnemyCount == 0) OnAllWavesDead?.Invoke();

            }
            

        }
    }
}

