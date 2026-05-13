using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private BattleManager battle_manager;

    void Update()
    {
        if (battle_manager == null)
        {
            battle_manager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
        }
    }

    public void AttackButton()
    {
        if (battle_manager != null)
        {
            battle_manager.PlayerAttack();
        }
    }

    public void RegenStaminaButton()
    {
        if(battle_manager != null)
        {
            battle_manager.RegenStamina();
        }
    }
}