using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{    
    [CreateAssetMenu]
    public sealed class EnemyAsset : ScriptableObject
    {
        [Header("Внешний вид")]
        public Color color = Color.white;
        public Vector2 spriteScale = new Vector2(3,3);
        public RuntimeAnimatorController m_Animations;

        [Header("Игровые параметры")]
        public float m_MoveSpeed = 1;
        public int m_Hp = 1;
        public int m_Armor = 0;
        public Enemy.ArmorType m_ArmorType;
        public int m_Score = 1;
        public float m_Radius = 0.2f;
        public Vector2 m_Offset = new Vector2(0, -0.09f);
        public int m_Damage = 1;
        public int m_Gold = 1;
        
    }
}