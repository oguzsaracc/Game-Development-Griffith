using UnityEngine;
using TMPro;

public class AddingScore : MonoBehaviour
{
    public string finishTag = "Finish";
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(finishTag))
        {
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}