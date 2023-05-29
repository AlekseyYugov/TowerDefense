using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter;
using Unity.VisualScripting;
using UnityEngine.UI;

namespace TowerDefense
{
    public class Abilities : MonoSingleton<Abilities>
    {
        //public interface Usable { void Use(); }
        [Serializable]
        public class FireAbility  
        {
            public int cost = 5;            
            public int damage = 2;
            [SerializeField] private Color m_TargetingColor;
            public void Use() 
            {
                GetMana.m_SummMana -= 10;
                ClickProtection.Instance.Activate((Vector2 v) => 
                {
                    Vector3 position = v;
                    position.z = -Camera.main.transform.position.z;
                    position = Camera.main.ScreenToWorldPoint(position);
                    foreach (var collider in Physics2D.OverlapCircleAll(position, Fire.m_FireLevel))
                    {
                        print(collider.name);
                        if (collider.transform.parent.TryGetComponent<Enemy>(out var enemy))
                        {
                            enemy.TakeDamage(damage, TDProjectile.DamageType.Magic);
                        }
                    }
                });
            } 
        }

        //private void InitiateTargeting(Color color, Action<Vector2> mouseAction)
        //{
        //    m_TargetCircle.color = color;
        //    ClickProtection.Instance.Activate(mouseAction);
        //}

        [Serializable]
        public class TimeAbility  
        {
            public int cost = 10;
            public float cooldown = 15f;
            [SerializeField] private float duration = 5;
            public void Use() 
            {
                GetMana.m_SummMana -= 5;
                Slow.m_Click = true;
                void SlowEnemy(Enemy ship)
                {
                    ship.GetComponent<SpaceShip>().HalfMaxLinearVelocity();
                }
                foreach (var ship in FindObjectsOfType<SpaceShip>())
                {
                    ship.HalfMaxLinearVelocity();
                }
                EnemyWaveManager.OnEnemySpawn += SlowEnemy;
                IEnumerator Restore()
                {
                    yield return new WaitForSeconds(duration);
                    foreach (var ship in FindObjectsOfType<SpaceShip>())
                    {
                        ship.RestoreMaxLinearVelocity();
                    }
                    EnemyWaveManager.OnEnemySpawn -= SlowEnemy;
                }
                Instance.StartCoroutine(Restore());
                IEnumerator TimeAbilityButton()
                {
                    Instance.TimeButton.interactable = false;
                    yield return new WaitForSeconds(cooldown);
                    Instance.TimeButton.interactable = true;


                }
                Instance.StartCoroutine(TimeAbilityButton());
            } 
        }
        [SerializeField] private Image m_TargetCircle;
        [SerializeField] private Button TimeButton;
        [SerializeField] private FireAbility m_FireAbility;
        public void UseFireAbility() => m_FireAbility.Use();
        [SerializeField] private TimeAbility m_TimeAbility;
        public void UseTimeAbility() => m_TimeAbility.Use();
    }
}

