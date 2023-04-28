using SpaceShooter;
using System;
using UnityEngine.Events;
using UnityEngine;

namespace TowerDefense
{
    public class TDPatrolController : AIController
    {
        [SerializeField] private UnityEvent OnEndPath;
        private Path m_path;
        private int pathIndex;
        public void SetPath(Path newPath)
        {
            m_path = newPath;
            pathIndex= 0;
            SetPatrolBehaviour(m_path[pathIndex]);
        }
        protected override void GetNewPoint()
        {
            pathIndex++;
            if (m_path.Length > pathIndex)
            {
                SetPatrolBehaviour(m_path[pathIndex]);
            }
            else
            {
                OnEndPath.Invoke();
                Destroy(gameObject);
            }
        }
    }
}

