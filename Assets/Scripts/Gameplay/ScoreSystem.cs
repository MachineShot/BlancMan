using Platformer.Mechanics;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    int score = 0;
    public PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = score.ToString();
    }

    public void Update()
    {
        if(player.coins > score)
        {
            this.score = player.coins;
            scoreDisplay.text = this.score.ToString();
        }
    }
}
