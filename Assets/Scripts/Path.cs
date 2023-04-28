using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private AIPointPatrol[] points;
        public int Length { get => points.Length; }
        public AIPointPatrol this[int i] { get => points[i]; }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            foreach (var p in points) 
            {
                Gizmos.DrawSphere(p.transform.position, p.Radius);
            }
            
        }
    }
}

