using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class coinCounter : MonoBehaviour
{
    public static coinCounter Instance;

    public int currentCoins = 0;

    public TextMeshProUGUI coinText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoins(enemy_stats defeatedEnemy)
    {
        if(defeatedEnemy == null)
        {
            Debug.Log("No enemy supplied.");
            return;
        }

        bool coinDropped = Random.Range(0,2) == 1;

        if(!defeatedEnemy.isBoss && !defeatedEnemy.isMiniboss && !coinDropped)
        {
            Debug.Log("No coins found");
            return;
        }

        int amount = 0;

        if(defeatedEnemy.isBoss)
        {
            amount = Random.Range(30,51);
        }
        else if(defeatedEnemy.isMiniboss)
        {
            amount = Random.Range(15,31);
        }
        else
        {
            amount = Random.Range(3,11);
        }

        currentCoins += amount;

        UpdateCoinText();

        Debug.Log("Looted " + amount + " coins!");
    }

    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + currentCoins.ToString();
    }
}