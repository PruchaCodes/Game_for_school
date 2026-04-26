using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Game/Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;

    public int maxHealth;
    public int damage;
    public int maxStamina;
    public int maxMana;

    public Sprite portrait;
}