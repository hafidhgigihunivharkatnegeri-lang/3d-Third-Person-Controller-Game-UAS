using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int gemValue = 1; // The amount of gems this pickup is worth
    public AudioClip gemPickupSound; // Assign the gem pickup sound clip in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add gemValue to the player's gem count
            GemsManager.instance.IncreaseGems(gemValue);

            // Play the gem pickup sound
            AudioSource.PlayClipAtPoint(gemPickupSound, transform.position);

            // Destroy the gem object
            Destroy(gameObject);
        }
    }
}
