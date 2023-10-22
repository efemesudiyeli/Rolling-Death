using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Slider healthBar;
    [SerializeField] PlayerHP playerHP;

    [SerializeField] int playerScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "CRUSHED CIVILIANS: " + playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerHP.playerHealth;
    }

    public void AddScore(int scoreValue)
    {
        playerScore += scoreValue;
        scoreText.text = "CRUSHED CIVILIANS: " + playerScore;
    }
}
