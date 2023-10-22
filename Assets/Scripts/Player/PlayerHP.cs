using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{

    public int playerHealth = 100;


    // Update is called once per frame
    void Update()
    {

        if (playerHealth <= 0)
        {
            KillPlayer();
        }

    }

    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;
    }

    public void KillPlayer()
    {
        // Destroy(gameObject);
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        Time.timeScale = 0;

    }
}
