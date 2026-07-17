using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int numberOfCoins;

    public Text coin;

    // Start dipanggil sebelum frame pertama update
    void Start()
    {
        numberOfCoins = 0;
        // Pastikan hanya ada satu instance GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update dipanggil sekali per frame
    void Update()
    {
        
    }

    // Method untuk menambah koin
    public void AddCoins(int amount)
    {
        numberOfCoins += amount;
        Debug.Log("Jumlah Koin: " + numberOfCoins);
        coin.text = "Coins: " + numberOfCoins;
    }
}
