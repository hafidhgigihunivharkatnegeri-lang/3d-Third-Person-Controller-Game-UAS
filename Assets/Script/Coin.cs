using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start dipanggil sebelum frame pertama update

    void Start()
    {
        
    }

    // Update dipanggil sekali per frame
    void Update()
    {
        transform.Rotate(20 * Time.deltaTime, 0, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.numberOfCoins+=1;
            Debug.Log("Coins"+GameManager.numberOfCoins);
            Destroy(gameObject);
        }
}
}
