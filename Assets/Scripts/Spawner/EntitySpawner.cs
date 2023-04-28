using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SpaceShooter;

namespace TowerDefense
{

    public class EntitySpawner : Spawner
    {
        /// <summary>
        /// Ссылки на то что спавнить.
        /// </summary>
        [SerializeField] private GameObject[] m_EntityPrefabs;

        protected override GameObject GenerateSpawnedEntity()
        {
            return Instantiate(m_EntityPrefabs[Random.Range(0, m_EntityPrefabs.Length)]);
        }


    }
}