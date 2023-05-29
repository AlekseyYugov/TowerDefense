using SpaceShooter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefense
{
    public class MapCompletion : MonoSingleton<MapCompletion>
    {
        public const string m_Filename = "completion.dat";

        public static void ResetSaveData()
        {
            FileHandler.Reset(m_Filename);
        }

        [Serializable]
        private class EpisodeScore
        {
            public Episode m_Episode;
            public int m_Score;
        }

        

        public static void SaveEpisodeResult(int levelScore)
        {
            if (Instance)
            {
                Instance.SaveResult(LevelSequenceController.Instance.CurrentEpisode, levelScore);
            }
            else
            {
                //Debug.Log($"Episode complete with score {levelScore}");
            }
            
        }

        private void SaveResult(Episode currentEpisode, int levelScore)
        {
            foreach (var item in m_CompletionData)
            {
                if (item.m_Episode == currentEpisode)
                {
                    if (levelScore > item.m_Score)
                    {
                        m_TotalScore += levelScore - item.m_Score;
                        item.m_Score = levelScore;
                        Saver<EpisodeScore[]>.Save(m_Filename, m_CompletionData);
                    }
                }
            }
        }


        [SerializeField] private EpisodeScore[] m_CompletionData;
        private int m_TotalScore;
        public int TotalScore => m_TotalScore;

        private new void Awake()
        {
            base.Awake();
            Saver<EpisodeScore[]>.TryLoad(m_Filename, ref m_CompletionData);
            foreach (var episodeScore in m_CompletionData)
            {
                m_TotalScore += episodeScore.m_Score;
            }
        }
        public int GetEpisodeScore(Episode m_Episode)
        {
            foreach (var data in m_CompletionData)
            {
                if (data.m_Episode == m_Episode) return data.m_Score;
            }
            return 0;
        }
    }
}

