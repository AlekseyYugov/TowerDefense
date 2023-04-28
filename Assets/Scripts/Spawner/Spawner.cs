using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SpaceShooter;

namespace TowerDefense
{

    public abstract class Spawner : MonoBehaviour
    {
        protected abstract GameObject GenerateSpawnedEntity();
        /// <summary>
        /// Зона спавна.
        /// </summary>
        [SerializeField] private CircleArea m_Area;

        /// <summary>
        /// Режим спавна.
        /// </summary>
        public enum SpawnMode
        {
            /// <summary>
            /// На методе Start()
            /// </summary>
            Start,

            /// <summary>
            /// Периодически используя время m_RespawnTime
            /// </summary>
            Loop
        }

        [SerializeField] private SpawnMode m_SpawnMode;

        /// <summary>
        /// Кол-во объектов которые будут разом заспавнены.
        /// </summary>
        [SerializeField] private int m_NumSpawns;

        /// <summary>
        /// Время респавна. Здесь важно заметить что респавн таймер должен быть больше времени жизни объектов.
        /// </summary>
        [SerializeField] private float m_RespawnTime;

        private float m_Timer;

        private void Start()
        {
            if(m_SpawnMode == SpawnMode.Start)
            {
                SpawnEntities();
            }
            
        }
        private void LateUpdate()
        {
            if (m_Timer > 0)
                m_Timer -= Time.deltaTime;


            if (m_SpawnMode == SpawnMode.Loop && m_Timer <= 0)
            {
                SpawnEntities();
                m_Timer = m_RespawnTime;
            }
        }

        //private void Update()
        //{
        //    Debug.Log(m_Timer);
        //    if (m_Timer > 0)
        //        m_Timer -= Time.deltaTime;


        //    if(m_SpawnMode == SpawnMode.Loop && m_Timer <= 0)
        //    {
        //        SpawnEntities();
        //        m_Timer = m_RespawnTime;
        //    }
        //}

        private void SpawnEntities()
        {
            for(int i = 0; i < m_NumSpawns; i++)
            {
                var e = GenerateSpawnedEntity();
                e.transform.position = m_Area.RandomInsideZone;

                //var prefabToSpawn = m_EntityPrefabs[UnityEngine.Random.Range(0, m_EntityPrefabs.Length)];
                //var e = Instantiate(prefabToSpawn);

                
                //if (e.TryGetComponent<TDPatrolController>(out var ai))
                //{
                //    ai.SetPath(m_path[Random.Range(0, m_path.Length)]);
                //}
                //if (e.TryGetComponent<Enemy>(out var en))
                //{
                //    en.Use(m_EnemySetting[Random.Range(0, m_EnemySetting.Length)]);
                //}
            }
        }
    }
}