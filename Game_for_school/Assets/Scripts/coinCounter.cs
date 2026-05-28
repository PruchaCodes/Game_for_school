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

    public void AddCoins(EnemyData defeatedEnemyData)
    {
        if (defeatedEnemyData == null)
        {
            Debug.Log("No enemy data supplied.");
            return;
        }

        bool coinDropped = Random.Range(0, 2) == 1;

        if (!defeatedEnemyData.isBoss && !defeatedEnemyData.isMiniboss && !coinDropped)
        {
            Debug.Log("No coins found");
            return;
        }

        currentCoins += defeatedEnemyData.value;
        UpdateCoinText();

        Debug.Log("Looted " + defeatedEnemyData.value + " coins!");
    }

    public void UpdateCoinText()
    {
        coinText.text = "Coins: " + currentCoins;
    }
}