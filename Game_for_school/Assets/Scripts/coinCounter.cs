using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class coinCounter : MonoBehaviour
{
    public static coinCounter Instance;

    public int currentCoins = 0;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI comentatoryText;
    public TextMeshProUGUI coinTextShop;
    public TextMeshProUGUI comentatoryTextShop;

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
            comentatoryText.SetText("No coins found");
            return;
        }

        currentCoins += defeatedEnemyData.value;
        UpdateCoinText();

        comentatoryText.SetText("Looted " + defeatedEnemyData.value + " coins!");
    }

    public void UpdateCoinText()
    {
        coinText.text = "Coins: " + currentCoins;
        coinTextShop.text = "Coins: " + currentCoins;
    }
}