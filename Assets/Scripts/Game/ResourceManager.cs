using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;  

    public int coins;
    public List<int> playerEarnedCards = new List<int>();

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        } 
        else 
        {
            Destroy(gameObject);
            return;
        }

        Application.targetFrameRate = 75;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coins = Mathf.Clamp(coins, 0, 99999);
    }

    public void AddEarnedCard(int cardId)
    {
        playerEarnedCards.Add(cardId);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("coins", coins);
        
        string earnedCards = "";
        foreach(int card in playerEarnedCards)
        {
            earnedCards += card.ToString() + " ";
        }

        earnedCards = earnedCards.Substring(0, earnedCards.Length - 1);
    
        PlayerPrefs.SetString("earnedCards", earnedCards);
    }

    public void Load()
    {
        coins = PlayerPrefs.GetInt("coins"); 

        int cardValue;
        string[] earnedCards = PlayerPrefs.GetString("earnedCards").Split(' ');
        playerEarnedCards = new List<int>();

        foreach(string card in earnedCards)
        {
            int.TryParse(card, out cardValue);
            playerEarnedCards.Add(cardValue);
        }
    }
}
