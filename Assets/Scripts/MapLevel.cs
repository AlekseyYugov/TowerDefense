using UnityEngine;
using SpaceShooter;
using UnityEngine.UI;
using System;

namespace TowerDefense
{
    public class MapLevel : MonoBehaviour
    {
        [SerializeField]private Episode m_Episode;
        //[SerializeField] private RectTransform resultPanel;
        [SerializeField] private Animator m_Anim;
        //[SerializeField] private Text text;
        [SerializeField] private int Score;


        //TODO
        public bool IsComplete { get { return gameObject.activeSelf && Score > 0; } }

        public void LoadLevel()
        {
            if (m_Episode) 
            {
                LevelSequenceController.Instance.StartEpisode(m_Episode);
            }
            
        }

        public int Initialise()
        {
            var score = MapCompletion.Instance.GetEpisodeScore(m_Episode);
            if (score == 0)
            {
                m_Anim.Play("Create_Level_Image");
            }
            if (score == 1)
            {
                m_Anim.Play("Create_Level_Image_Score1");
            }
            if (score == 2)
            {
                m_Anim.Play("Create_Level_Image_Score2");
            }
            if (score == 3)
            {
                m_Anim.Play("Create_Level_Image_Score3");
            }
            Score = score;
            return score;
        }
    }
}

