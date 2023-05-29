using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class EnemyWave: MonoBehaviour
    {
        public static Action<float> OnWavePrepare;

        [Serializable]
        private class Squad
        {
            public EnemyAsset m_Asset;
            public int m_Count;
        }


        [Serializable]
        private class PathGroup
        {
            public Squad[] m_Squads;

        }

        [SerializeField] private PathGroup[] m_Groups;
        [SerializeField] private float m_PrepareTime = 10f;
        public float GetRemaingTime() { return m_PrepareTime - Time.time; }
        private void Awake()
        {
            enabled = false;
        }

        private event Action OnWaveReady;

        public void Prepare(Action spawnEnemies)
        {
            OnWavePrepare?.Invoke(m_PrepareTime);
            m_PrepareTime += Time.time;
            enabled= true;
            OnWaveReady += spawnEnemies;

        }

        private void Update()
        {
            if (Time.time >= m_PrepareTime)
            {
                enabled = false;
                OnWaveReady?.Invoke();
            }
        }
        public IEnumerable<(EnemyAsset asset, int count, int pathIndex)> EnumerateSquads()
        {
            for (int i = 0; i < m_Groups.Length; i++)
            {
                foreach (var squad in m_Groups[i].m_Squads)
                {
                    yield return (squad.m_Asset, squad.m_Count, i);
                }
                
            }
            
        }
        [SerializeField] private EnemyWave next;
        public  EnemyWave PrepareNext(Action spawnEnemies)
        {
            OnWaveReady -= spawnEnemies;
            if (next) next.Prepare(spawnEnemies);
            return next;
        }
    }
}