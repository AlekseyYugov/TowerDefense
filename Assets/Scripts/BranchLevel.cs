using System;
using UnityEngine;
using UnityEngine.UI;


namespace TowerDefense
{
    [RequireComponent(typeof(MapLevel))]
    public class BranchLevel : MonoBehaviour
    {
        [SerializeField] private MapLevel m_RootLevel;
        [SerializeField] private Text m_PointText;
        [SerializeField] private int m_NeedPoints = 3;

        public void TryActivate()
        {
            gameObject.SetActive(m_RootLevel.IsComplete);
            if (m_NeedPoints > MapCompletion.Instance.TotalScore) 
            {
                m_PointText.text = m_NeedPoints.ToString();
            }
            else
            {
                GetComponent<MapLevel>().Initialise();
                m_PointText.transform.parent.gameObject.SetActive(false);
            }
            
        }
    }
}

