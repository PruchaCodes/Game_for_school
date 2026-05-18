using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
public class coinCounter : MonoBehaviour
{

    public static coinCounter Instance;
    public int currentCoins = 0;
    public TextMeshProUGUI coinText;
    private enemy_stats enemyStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        
        
    }

    void Update()
    {
        if(enemyStats == null)
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

            if(enemy != null)
            {
                enemyStats = enemy.GetComponent<enemy_stats>();
            }
        }
    }


    void Start()
    {
        coinText.text = "Coins: " + currentCoins.ToString();

    }

  

    public void AddCoins(int amount)
    {
        if(!enemyStats.isBoss && !enemyStats.isMiniboss && (Random.Range(0,2) > 0))
        {
            Debug.Log("No coins found");
        }
        else
        {
            currentCoins += amount;
            coinText.text = "Coins: " + currentCoins.ToString();
            Debug.Log("Looooooted!!!" + Random.Range(0,2));
            
        }
        
    }
}
