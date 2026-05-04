using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectButton : MonoBehaviour
{
    public CharacterData thisCharacter;

    public void SelectCharacter()
    {
        GameManager.Instance.selectedCharacter = thisCharacter;

        GameManager.Instance.currentHealth = thisCharacter.maxHealth;
        GameManager.Instance.currentMaxHealth = thisCharacter.maxHealth;
        GameManager.Instance.currentDamage = thisCharacter.damage;
        GameManager.Instance.currentStamina = thisCharacter.maxStamina;
        GameManager.Instance.currentMaxStamina = thisCharacter.maxStamina;
        GameManager.Instance.currentMana = thisCharacter.maxMana;
        GameManager.Instance.currentMaxMana = thisCharacter.maxMana;

        SceneManager.LoadScene("MainGame");
    }
}