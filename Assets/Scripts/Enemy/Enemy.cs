using SpaceShooter;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;

namespace TowerDefense
{
    [RequireComponent(typeof(TDPatrolController))]
    public class Enemy : MonoBehaviour
    {

        public enum ArmorType { Base = 0, Mage = 1}
        private static Func<int, TDProjectile.DamageType, int, int>[] ArmorDamageFunctions =
        {
            (int power, TDProjectile.DamageType type, int armor) =>
            {//ArmorType.Base
                switch(type)
                {
                    case TDProjectile.DamageType.Magic: return power;
                        default: return Mathf.Max(power - armor, 1);
                }
            },
            (int power, TDProjectile.DamageType type, int armor) =>
            {//ArmorType.Magic

                if (TDProjectile.DamageType.Base == type)
                {
                    armor = armor/2;
                }
                return Mathf.Max(power - armor, 1);
            }

        };


        [SerializeField] private int m_Damage = 1;
        [SerializeField] private int m_Gold = 1;
        [SerializeField] private int m_Armor = 1;
        [SerializeField] private ArmorType m_ArmorType;
        private Destructible m_Destructible;


        private void Awake()
        {
            m_Destructible = GetComponent<Destructible>();
            
        }

        public event Action OnEnd;
        private void OnDestroy()
        {
            //print("Kill"+name);
            GetMana.m_SummMana += 1;
            OnEnd?.Invoke();
        }

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

            sr.GetComponent<Animator>().runtimeAnimatorController = asset.m_Animations;

            GetComponent<SpaceShip>().Use(asset);

            GetComponentInChildren<CircleCollider2D>().radius= asset.m_Radius;
            GetComponentInChildren<CircleCollider2D>().offset = asset.m_Offset;
            m_Damage = asset.m_Damage;
            m_Armor= asset.m_Armor;
            m_ArmorType= asset.m_ArmorType;
            m_Gold = asset.m_Gold;
        }

        public void DamagePlayer()
        {
            TDPlayer.Instance.ReduceLive(m_Damage);
        }

        public void GivePlayerGold()
        {
            TDPlayer.Instance.ChangeGold(m_Gold);
        }

        public void TakeDamage(int damage, TDProjectile.DamageType damageType)
        {
            m_Destructible.ApplyDamage(ArmorDamageFunctions[(int)m_ArmorType](damage, damageType, m_Armor));
            
        }

    }

#if UNITY_EDITOR
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
#endif
}

