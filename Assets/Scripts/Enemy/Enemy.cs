using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace TowerDefense
{
    [RequireComponent(typeof(TDPatrolController))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int m_Damage = 1;
        [SerializeField] private int m_Gold = 1;
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Enemy(Clone)") 
            {
                Physics2D.IgnoreCollision(collision.collider, GetComponentInChildren<CircleCollider2D>());
            }
        }

        public void Use(EnemyAsset asset)
        {
            var sr = transform.Find("Sprite").GetComponent<SpriteRenderer>();
            sr.color = asset.color;
            sr.transform.localScale = new Vector3(asset.spriteScale.x, asset.spriteScale.y, 1f);

            sr.GetComponent<Animator>().runtimeAnimatorController = asset.animations;

            GetComponent<SpaceShip>().Use(asset);

            GetComponentInChildren<CircleCollider2D>().radius= asset.radius;
            GetComponentInChildren<CircleCollider2D>().offset = asset.offset;
            m_Damage = asset.damage;
            m_Gold = asset.gold;
        }

        public void DamagePlayer()
        {
            TDPlayer.Instance.ReduceLive(m_Damage);
        }

        public void GivePlayerGold()
        {
            TDPlayer.Instance.ChangeGold(m_Gold);
        }

    }
    [CustomEditor(typeof(Enemy))]

    public class EnemyInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EnemyAsset a = EditorGUILayout.ObjectField(null, typeof(EnemyAsset), false) as EnemyAsset;
            if (a != null) 
            {
                (target as Enemy).Use(a);
            }
        }
    }
}

