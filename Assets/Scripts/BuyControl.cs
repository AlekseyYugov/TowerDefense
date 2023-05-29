using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefense
{
    public class BuyControl : MonoBehaviour
    {
        [SerializeField] private TowerBuyControl m_TowerBuyPrefab;
        private List<TowerBuyControl> m_ActiveControl;
        private RectTransform m_RectTransform;

        private void Awake()
        {
            OnDestroy();
            m_RectTransform = gameObject.GetComponent<RectTransform>();
            BuildSite.OnClickEvent += MoveToBuildSite;
            gameObject.SetActive(false);
            m_ActiveControl = new List<TowerBuyControl>();

        }

        public void OnDestroy()
        {
            BuildSite.OnClickEvent -= MoveToBuildSite;
        }

        private void MoveToBuildSite(BuildSite buildSite)
        {
            if (buildSite)
            {
                var position = Camera.main.WorldToScreenPoint(buildSite.transform.root.position);

                m_RectTransform.anchoredPosition = position;
                gameObject.SetActive(true);
                m_ActiveControl = new List<TowerBuyControl>();
                foreach (var asset in buildSite.buldableTowers)
                {
                    if (asset.IsAvailable())
                    {
                        var newControl = Instantiate(m_TowerBuyPrefab, transform);
                        m_ActiveControl.Add(newControl);
                        newControl.SetTowerAsset(asset);
                    }
                }
                foreach (var tbc in GetComponentsInChildren<CreateTower>())
                {
                    tbc.SetBuildSite(buildSite.transform.root);
                }
            }
            else
            {
                if (m_ActiveControl!=null)
                {
                    foreach (var control in m_ActiveControl)
                    {
                        Destroy(control.gameObject);
                    }
                    m_ActiveControl.Clear();
                }
                
                gameObject.SetActive(false);
            }
            //Debug.Log(GetComponentsInChildren<CreateTower>().Length);
            
        }
    }
}

