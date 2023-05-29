using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using Unity.VisualScripting;
using UnityEngine;

public class TowerShot : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private string m_ShotClip;
    //[SerializeField] private string m_ChargeClip;

    static public bool Shot;
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    private void Update()
    {
        
        //if (Shot)
        //{
        //    m_Animator.SetBool(m_ShotClip, true);

        //}
        //else
        //{
        //    m_Animator.SetBool(m_ShotClip, false);
        //} TODO


    }

    public void AttackToogle()
    {
        Tower.m_EndAnimationClip = true;
    }

    public void ChargeToogle()
    {
        Tower.m_EndAnimationClip = false;
    }

}
