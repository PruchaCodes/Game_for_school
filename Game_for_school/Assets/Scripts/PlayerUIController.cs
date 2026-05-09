using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
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
        if(action_manager != null)
        {
            action_manager.AttackAction();
        }
    }
}
