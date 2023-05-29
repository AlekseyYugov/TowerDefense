using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TowerDefense;
using UnityEngine;


namespace TowerDefense
{
    public class TDLevelController : LevelController
    {
        private static int levelScore = 3;

        private new void Start()
        {
            base.Start();
            levelScore = 3;
            TDPlayer.Instance.OnPlayerDeath += () =>
            {
                StopLevelActivity();
                LevelResultController.Instance.Show(false);
            };
            m_ReferenceTime += Time.time;
            m_EventLevelCompleted.AddListener(()=>
            {
                StopLevelActivity();
                if(m_ReferenceTime <= Time.time)
                {
                    levelScore -= 1;
                }
                MapCompletion.SaveEpisodeResult(levelScore);

            });
            
            //TDPlayer.OnLifeUpdate += LifeScoreChange;
        }
        public static void LifeScoreChange(int _)
        {


            levelScore -= 1;
            TDPlayer.OnLifeUpdate -= LifeScoreChange;
        }
        private void StopLevelActivity()
        {
            foreach (var enemy in FindObjectsOfType<Enemy>())
            {
                enemy.GetComponent<SpaceShip>().enabled = false;
                enemy.GetComponent<Rigidbody2D>().velocity= Vector3.zero;

            }

            void DisableAll<T>() where T: MonoBehaviour
            {
                foreach (var obj in FindObjectsOfType<T>())
                {
                    obj.enabled = false;
                }
            }
            DisableAll<EnemyWave>();
            DisableAll<Projectile>();
            DisableAll<Tower>();
            DisableAll<NextWaveGUI>();


        }
    }

}

