using System;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Action_manager action_manager;

    // Update is called once per frame
    void Update()
    {
        if(action_manager == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player != null)
            {
                action_manager = player.GetComponent<Action_manager>();
            }
        }
    }

    public void AttackButton()
    {
        Debug.Log("Attack button pressed");
        if(action_manager != null)
        {
            action_manager.Attack();
        }
    }
    public void StaminaRegenButton()
    {
        Debug.Log("Stamina regen button pressed");
        if(action_manager != null)
        {
            action_manager.StaminaRegen();
        }
    }
}
