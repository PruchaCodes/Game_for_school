using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public CharacterData[] characters;

    public Image cardImage;
    public TMP_Text statsText;

    private int currentIndex = 0;

    void Start()
    {
        ShowCharacter();
    }

    public void NextCharacter()
    {
        currentIndex++;

        if (currentIndex >= characters.Length)
        {
            currentIndex = 0;
        }

        ShowCharacter();
    }

    public void PreviousCharacter()
    {
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = characters.Length - 1;
        }

        ShowCharacter();
    }

    void ShowCharacter()
    {
        CharacterData currentCharacter = characters[currentIndex];

        cardImage.sprite = currentCharacter.portrait;

        statsText.text =
            currentCharacter.characterName +
            "\nHP: " + currentCharacter.maxHealth +
            "\nDMG: " + currentCharacter.damage +
            "\nSTA: " + currentCharacter.maxStamina +
            "\nMANA: " + currentCharacter.maxMana;
    }

    public void PlayGame()
    {
        CharacterData currentCharacter = characters[currentIndex];

        GameManager.Instance.selectedCharacter = currentCharacter;

        GameManager.Instance.currentHealth = currentCharacter.maxHealth;
        GameManager.Instance.currentMaxHealth = currentCharacter.maxHealth;
        GameManager.Instance.currentDamage = currentCharacter.damage;
        GameManager.Instance.currentStamina = currentCharacter.maxStamina;
        GameManager.Instance.currentMaxStamina = currentCharacter.maxStamina;
        GameManager.Instance.currentMana = currentCharacter.maxMana;
        GameManager.Instance.currentMaxMana = currentCharacter.maxMana;

        SceneManager.LoadScene("MainGame");
    }
}