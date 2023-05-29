using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace TowerDefense
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button m_ContinueButton;
        private void Start()
        {
            m_ContinueButton.interactable = FileHandler.HasFile(MapCompletion.m_Filename);
            
        }
        public void Continue()
        {
            SceneManager.LoadScene(1);
        }
        public void NewGame()
        {
            FileHandler.Reset(MapCompletion.m_Filename);
            FileHandler.Reset(Upgrades.filename);
            SceneManager.LoadScene(1);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}

