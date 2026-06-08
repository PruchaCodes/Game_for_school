using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Random = UnityEngine.Random;
using TMPro;
public class BattleManager : MonoBehaviour
{
    public player_stats player_stats;
    public List<enemy_stats> enemies = new List<enemy_stats>();

    public bool playerTurn = true;
    private bool miniBossHere = true;
    private bool bossHere = true;
    public GameOverScreen gameOverScreen;
    public VictoryScreen victoryScreen;
    public coinCounter coinCounter;
    public TMPro.TextMeshProUGUI comentatoryText;

    public SoundManager soundManager;

    int i = 10;
    int iBoss = 100;
    int sanceMaxHp = 100;
    int sanceMaxHPRange = 1;

    void Update()
    {
        if(soundManager == null)
        {
            soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        }

        if (player_stats == null)
        {
            player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<player_stats>();
        }

        enemies.Clear();

        GameObject[] foundEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in foundEnemies)
        {
            enemy_stats stats = enemy.GetComponent<enemy_stats>();

            if(stats != null)
            {
                enemies.Add(stats);
            }
        }

        

        
    }



        public void SpecialAttackBarbar()
    {

        if (miniBossHere)
        {
           if(enemies[0].isMiniboss)
            {
                comentatoryText.SetText("Miniboss appered! He attacks immediately!");
                miniBossHere = false;
                StartCoroutine(EnemyTurn());
                return;
            }
            
        }

        if (bossHere)
        {
           
            if(enemies[0].isBoss)
            {
                comentatoryText.SetText("Boss appered! He attacks immediately!");
                bossHere = false;
                StartCoroutine(EnemyTurn());
                return;
            }
        }

        

        if (!playerTurn)
        {
            Vyhodnoceni();
            return;
        }

        if(player_stats.stamina < player_stats.maxStamina/3)
        {
            Vyhodnoceni();
            return;
        }

        if(enemies.Count == 0)
        {
            Vyhodnoceni();
            return;
        }

        if(player_stats.health <= 0)
        {
            Vyhodnoceni();
            return;
        }

        enemies.RemoveAll(enemy => enemy == null);

        if(enemies.Count > 0)
        {

            // Šance na zásah bosse
            if(enemies.Count > 0 && enemies[0] != null && enemies[0].health > 0 && player_stats.health > 0 && enemies[0].isBoss)
            {
                
                if(Random.Range(0, i) < 5)
                {

                    soundManager.PlaySFX(soundManager.RageSound);
                    enemies[0].health -= player_stats.damage + enemies[0].damage;
                    
                    i++;
                    comentatoryText.SetText("Boss hit by special attack! Chance to hit droped by 10%");
                }
                else
                {
                    if (i > 1)
                    {
                        i--;
                    }
                    comentatoryText.SetText("Boss missed! Chance to hit increased by 10%");
                }

                

            }
            else if(enemies.Count > 0 && enemies[0] != null && enemies[0].health > 0 && player_stats.health > 0)
            {
                soundManager.PlaySFX(soundManager.RageSound);
                enemies[0].health -= player_stats.damage + enemies[0].damage;
                comentatoryText.SetText("Player attacks! Damage dealt: " + player_stats.damage + enemies[0].damage);
            }

            if(enemies[0].isBoss && enemies[0].health <= 0)
            {
                Victory();
                Vyhodnoceni();
                return;
            }
            else if(enemies[0].health <= 0)
            {
                Destroy(enemies[0].gameObject);

                enemies.RemoveAt(0);
            }

        }

        player_stats.stamina -= player_stats.maxStamina/3;

        playerTurn = false;
        StartCoroutine(EnemyTurn());
    }


    public void SpecialAttackRanger()
    {

        if (miniBossHere)
        {
           if(enemies[0].isMiniboss)
            {
                comentatoryText.SetText("Miniboss appered! He attacks immediately!");
                miniBossHere = false;
                StartCoroutine(EnemyTurn());
                return;
            }
            
        }

        if (bossHere)
        {
           
            if(enemies[0].isBoss)
            {
                comentatoryText.SetText("Boss appered! He attacks immediately!");
                bossHere = false;
                StartCoroutine(EnemyTurn());
                return;
            }
        }

        

        if (!playerTurn)
        {
            Vyhodnoceni();
            return;
        }

        if(player_stats.stamina < player_stats.maxStamina/3)
        {
            Vyhodnoceni();
            return;
        }

        if(enemies.Count == 0)
        {
            Vyhodnoceni();
            return;
        }

        if(player_stats.health <= 0)
        {
            Vyhodnoceni();
            return;
        }

        enemies.RemoveAll(enemy => enemy == null);

        if(enemies.Count > 0)
        {

            // Šance na zásah bosse
            if(enemies.Count > 0 && enemies[0] != null && enemies[0].health > 0 && player_stats.health > 0 && enemies[0].isBoss)
            {
                
                if(Random.Range(0, i) < 5)
                {
                    soundManager.PlaySFX(soundManager.SneakAttackSound);
                    enemies[0].health -= player_stats.damage * 2;
                    
                    i++;
                    comentatoryText.SetText("Boss received a critical hit! Chance to hit droped by 10%");
                }
                else
                {
                    if (i > 1)
                    {
                        i--;
                    }
                    comentatoryText.SetText("Boss missed! Chance to hit increased by 10%");
                }

                

            }
            else if(enemies.Count > 0 && enemies[0] != null && enemies[0].health > 0 && player_stats.health > 0)
            {
                soundManager.PlaySFX(soundManager.SneakAttackSound);
                enemies[0].health -= player_stats.damage * 2;
                comentatoryText.SetText("Player attacks! Damage dealt: " + player_stats.damage * 2);
            }

            if(enemies[0].isBoss && enemies[0].health <= 0)
            {
                Victory();
                Vyhodnoceni();
                return;
            }
            else if(enemies[0].health <= 0)
            {
                Destroy(enemies[0].gameObject);

                enemies.RemoveAt(0);
            }

        }

        player_stats.stamina -= player_stats.maxStamina/3;

        playerTurn = false;
        StartCoroutine(EnemyTurn());
    }



    public void SpecialAttackMage()
    {

        if (miniBossHere)
        {
           if(enemies[0].isMiniboss)
            {
                comentatoryText.SetText("Miniboss appered! He attacks immediately!");
                miniBossHere = false;
                StartCoroutine(EnemyTurn());
                return;
            }
            
        }

        if (bossHere)
        {
           
            if(enemies[0].isBoss)
            {
                comentatoryText.SetText("Boss appered! He attacks immediately!");
                bossHere = false;
                StartCoroutine(EnemyTurn());
                return;
            }
        }

        

        if (!playerTurn)
        {
            Vyhodnoceni();
            return;
        }

        if(player_stats.stamina < 10)
        {
            Vyhodnoceni();
            return;
        }

        if(enemies.Count == 0)
        {
            Vyhodnoceni();
            return;
        }

        if(player_stats.health <= 0)
        {
            Vyhodnoceni();
            return;
        }

        enemies.RemoveAll(enemy => enemy == null);

        if(enemies.Count > 0)
        {

            // Šance na zásah bosse
            if(enemies.Count > 0 && enemies[0] != null && enemies[0].health > 0 && player_stats.health > 0 && enemies[0].isBoss)
            {
                
                if(Random.Range(0, i) < 5)
                {
                    soundManager.PlaySFX(soundManager.FireballSound);
                    
                    enemies[0].health -= player_stats.damage * 4;
                    
                    i++;
                    comentatoryText.SetText("Boss hit by FIRE BALL! Chance to hit droped by 10%");
                }
                else
                {
                    if (i > 1)
                    {
                        i--;
                    }
                    comentatoryText.SetText("Boss missed! Chance to hit increased by 10%");
                }

                

            }
            else if(enemies.Count > 0 && enemies[0] != null && enemies[0].health > 0 && player_stats.health > 0)
            {
                soundManager.PlaySFX(soundManager.FireballSound);
                enemies[0].health -= player_stats.damage * 4;
                comentatoryText.SetText("Player attacks! Damage dealt: " + player_stats.damage * 4);
            }

            if(enemies[0].isBoss && enemies[0].health <= 0)
            {
                Victory();
                Vyhodnoceni();
                return;
            }
            else if(enemies[0].health <= 0)
            {
                Destroy(enemies[0].gameObject);

                enemies.RemoveAt(0);
            }

        }

        player_stats.mana -= 30;

        playerTurn = false;
        
        StartCoroutine(EnemyTurn());
    }


        // Hráč útočí na nepřítele, pokud je jeho tah a má dostatek staminy
    public void PlayerAttack()
    {

        if (miniBossHere)
        {
           if(enemies[0].isMiniboss)
            {
                comentatoryText.SetText("Miniboss appered! He attacks immediately!");
                miniBossHere = false;
                StartCoroutine(EnemyTurn());
                return;
            }
            
        }

        if (bossHere)
        {
           
            if(enemies[0].isBoss)
            {
                comentatoryText.SetText("Boss appered! He attacks immediately!");
                bossHere = false;
                StartCoroutine(EnemyTurn());
                return;
            }
        }

        

        if (!playerTurn)
        {
            Vyhodnoceni();
            return;
        }

        if(player_stats.stamina < 10)
        {
            Vyhodnoceni();
            return;
        }

        if(enemies.Count == 0)
        {
            Vyhodnoceni();
            return;
        }

        if(player_stats.health <= 0)
        {
            Vyhodnoceni();
            return;
        }

        enemies.RemoveAll(enemy => enemy == null);

        if(enemies.Count > 0)
        {

            // Šance na zásah bosse
            if(enemies.Count > 0 && enemies[0] != null && enemies[0].health > 0 && player_stats.health > 0 && enemies[0].isBoss)
            {
                
                if(Random.Range(0, i) < 5)
                {
                    soundManager.PlaySFX(soundManager.AttackSound);
                    enemies[0].health -= player_stats.damage;
                    
                    i++;
                    comentatoryText.SetText("Boss hit! Chance to hit droped by 10%");
                }
                else
                {
                    if (i > 1)
                    {
                        i--;
                    }
                    comentatoryText.SetText("Boss missed! Chance to hit increased by 10%");
                }

                

            }
            else if(enemies.Count > 0 && enemies[0] != null && enemies[0].health > 0 && player_stats.health > 0)
            {
                soundManager.PlaySFX(soundManager.AttackSound);
                enemies[0].health -= player_stats.damage;
                comentatoryText.SetText("Player attacks! Damage dealt: " + player_stats.damage);
            }

            if(enemies[0].isBoss && enemies[0].health <= 0)
            {
                Victory();
                Vyhodnoceni();
                return;
            }
            else if(enemies[0].health <= 0)
            {
                Destroy(enemies[0].gameObject);

                enemies.RemoveAt(0);
            }

        }

        player_stats.stamina -= 10;

        playerTurn = false;
        StartCoroutine(EnemyTurn());
    }
        // Nepřítel útočí na hráče, pokud je jeho tah a hráč je stále naživu
    IEnumerator EnemyTurn()
    {

        
        comentatoryText.SetText("Enemy's turn!");
        
        yield return new WaitForSeconds(1.5f);
        
        if(enemies.Count > 0 && enemies[0] != null && enemies[0].health > 0 && player_stats.health > 0 && enemies[0].isBoss)
        {
            
            if(Random.Range(0, iBoss) < 20)
            {
                soundManager.PlaySFX(soundManager.CritSound);
                player_stats.health -= enemies[0].damage*2;
                iBoss+=5;
                comentatoryText.SetText("Critical hit! Chance to crit droped by 5%. Dmg dealt to player: " + enemies[0].damage*2);
            }
            else
            {
                if(iBoss > 15)
                {
                    iBoss-=15;
                    comentatoryText.SetText("No Critical hit! Chance to crit increased by 15%");
                }
                soundManager.PlaySFX(soundManager.EnemyAttackSound);
                player_stats.health -= enemies[0].damage;
                
            }

            if(enemies[0].health < enemies[0].maxHealth * 0.05f)
            {
                sanceMaxHPRange = 50;
                comentatoryText.SetText("Bosses chance to heal to max hp increased to 50%");
            }

            if(Random.Range(0, sanceMaxHp) < sanceMaxHPRange)
            {
                soundManager.PlaySFX(soundManager.HealSound);
                enemies[0].health = enemies[0].maxHealth;
                comentatoryText.SetText("Boss healed himself to max HP!");
            }

        }
        else if(enemies.Count > 0 && enemies[0] != null && enemies[0].health > 0 && player_stats.health > 0)
        {
            soundManager.PlaySFX(soundManager.EnemyAttackSound);
            player_stats.health -= enemies[0].damage;
            comentatoryText.SetText("Enemy attacks! Damage dealt: " + enemies[0].damage);
        }

        if(player_stats.health <= 0)
        {
            GameOver();
            Vyhodnoceni();
        }

        

        enemies.RemoveAll(enemy => enemy == null);

        if(enemies.Count == 0)
        {

        StartCoroutine(FindFirstObjectByType<EnemySpawn>().EnemyDefeated());
        miniBossHere = true;
        bossHere = true;
        }

        playerTurn = true;
    }

        //Regenerace staminy
    public void RegenStamina()
    {
        if (CheckBossFirstAttack())
            return;

        if (!playerTurn || player_stats.health <= 0)
        {
            Vyhodnoceni();
            return;
        }

        if (player_stats.stamina >= player_stats.maxStamina && player_stats.mana >= player_stats.maxMana)
        {
            Vyhodnoceni();
            return;
        }

        soundManager.PlaySFX(soundManager.StaminaRegen);

        comentatoryText.SetText("Regenerating stamina by 10!");
        player_stats.stamina += 10;
        player_stats.stamina = Math.Min(player_stats.stamina, player_stats.maxStamina);

        if(player_stats.maxMana > 0)
        {
            player_stats.mana += 10;
            player_stats.mana = Math.Min(player_stats.mana, player_stats.maxMana);
        }
        

        playerTurn = false;
        StartCoroutine(EnemyTurn());
    }

    private bool CheckBossFirstAttack()
    {
        enemies.RemoveAll(enemy => enemy == null);

        if (enemies.Count == 0)
            return false;

        if (miniBossHere && enemies[0].isMiniboss)
        {
            comentatoryText.SetText("Miniboss appeared! He attacks immediately!");
            miniBossHere = false;
            playerTurn = false;
            StartCoroutine(EnemyTurn());
            return true;
        }

        if (bossHere && enemies[0].isBoss)
        {
            comentatoryText.SetText("Boss appeared! He attacks immediately!");
            bossHere = false;
            playerTurn = false;
            StartCoroutine(EnemyTurn());
            return true;
        }

        return false;
    }

        //Vyhodnocení stavu
    public void Vyhodnoceni()
    {
        if(enemies.Count > 0 && enemies[0] != null && enemies[0].health <= 0)
        {
            comentatoryText.SetText("Enemy defeated!");
        }

        if(player_stats.stamina < 10)
        {
            comentatoryText.SetText("Not enough stamina to attack!");
        }

        if(player_stats.health <= 0)
        {
            Debug.Log("You have been defeated!");
            GameOver();
        }

        if(player_stats.stamina >= player_stats.maxStamina)
        {
            comentatoryText.SetText("Stamina is full!");
        }
    }

    public void GameOver()
    {
        gameOverScreen.Setup();
    }

    public void Victory()
    {
        victoryScreen.Setup();
    }

    public void HealPlayer()
    {

        if(coinCounter.Instance.currentCoins >= 20 && player_stats.health > 0)
        {
            player_stats.health = player_stats.maxHealth;
            coinCounter.Instance.currentCoins -= 20;
            coinCounter.Instance.UpdateCoinText();
        }
        else
        {
            comentatoryText.SetText("Not enough coins to heal!");
            return;
        }
        

    }
}
