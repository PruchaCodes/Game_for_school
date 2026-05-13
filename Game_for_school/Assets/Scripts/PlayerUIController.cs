using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private Action_manager action_manager;

    void Update()
    {
        if (action_manager == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                action_manager = player.GetComponent<Action_manager>();
            }
        }
    }

    public void AttackButton()
    {
        if (action_manager != null)
        {
            action_manager.Attack();
        }
    }
}