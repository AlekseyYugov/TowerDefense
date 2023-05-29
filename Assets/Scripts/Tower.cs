using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private float m_Radius = 5f;
        private float m_Lead = 0.3f;
        private Turret[] turrets;
        private Rigidbody2D target = null;
        static public bool m_EndAnimationClip = false;
        private void Start()
        {
            turrets = GetComponentsInChildren<Turret>();
        }
        public void Use(TowerAsset asset)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = asset.sprite;
            turrets = GetComponentsInChildren<Turret>();
            foreach (var turret in turrets)
            {
                turret.AssignLoadout(asset.m_TurretProperties);
            }
            GetComponentInChildren<BuildSite>().SetBuildableTowers(asset.m_UpgradesTo);
        }

        private void Update()
        {
            if (target)
            {
                if (Vector3.Distance(target.transform.position, transform.position) <= m_Radius)
                {
                    //TowerShot.Shot = true; TODO
                    foreach (Turret turret in turrets)
                    {
                        turret.transform.up = target.transform.position - turret.transform.position + (Vector3)target.velocity * m_Lead;


                        turret.Fire();

                    }
                }
                else
                {
                    target = null;

                }

            }
            else
            {
                var enter = Physics2D.OverlapCircle(transform.position, m_Radius);
                if (enter)
                {
                    target = enter.transform.root.GetComponent<Rigidbody2D>();
                }
            }

        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;

            Gizmos.DrawWireSphere(transform.position, m_Radius);
        }

    }
}

