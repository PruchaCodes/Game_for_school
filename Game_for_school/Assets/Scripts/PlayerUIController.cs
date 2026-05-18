using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    private BattleManager battle_manager;
    private Animator player_animator;
    void Update()
    {
        if (battle_manager == null)
        {
            battle_manager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
        }

        player_animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        


        
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