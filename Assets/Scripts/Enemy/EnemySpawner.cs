﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SpaceShooter;

namespace TowerDefense
{

    public class EnemySpawner : Spawner
    {
        [SerializeField] private Enemy m_EnemyPrefabs;
        [SerializeField] private Path m_Path;
        [SerializeField] private EnemyAsset[] m_EnemyAssets;

        protected override GameObject GenerateSpawnedEntity()
        {
            var e = Instantiate(m_EnemyPrefabs);
            e.Use(m_EnemyAssets[Random.Range(0, m_EnemyAssets.Length)]);
            e.GetComponent<TDPatrolController>().SetPath(m_Path);
            return e.gameObject;
        }


    }
}