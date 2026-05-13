using System;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private BattleManager battleManager;


    void Start()
    {
        
        battleManager = FindObjectOfType<BattleManager>();
    }

    public void OnAttackButton()
    {
        battleManager.PlayerAttack();
    }
}
    
