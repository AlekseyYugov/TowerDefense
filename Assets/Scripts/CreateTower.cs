using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class CreateTower : MonoBehaviour
{
    [SerializeField] private Tower m_Tower;
    

    private Transform m_BuildSite;
    
    public void SetBuildSite(Transform value)
    {
        m_BuildSite = value;
    }


    public void Buy()
    {
        if (m_Tower.name == "ArcherTower")
        {
            TDPlayer.Instance.ChangeGold(-10);
        }
        if (m_Tower.name == "TowerFire")
        {
            TDPlayer.Instance.ChangeGold(-15);
        }
        if (m_Tower.name == "TowerMetal")
        {
            TDPlayer.Instance.ChangeGold(-20);
        }
        if (m_Tower.name == "TowerBoulder")
        {
            TDPlayer.Instance.ChangeGold(-40);
        }
        var tower = Instantiate(m_Tower, m_BuildSite.root.position, Quaternion.identity);
        Destroy(m_BuildSite.gameObject);
        BuildSite.HideControls();
    }
    
}
