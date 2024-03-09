using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; 
    [SerializeField] private int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        scoreText.text = "Score: " + scoreValue.ToString();
    }

    /*
     * Set new scoreValue
     */
    public void SetScoreValue()
    {
        scoreValue += 100;
        scoreText.text = "Score: " + scoreValue.ToString("N0");
    }

    /*
     * Return scoreValue
     */
    public int GetScoreValue()
    {
        return scoreValue;
    }
}
