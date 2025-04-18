using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreMesh;
    private int score;

    void Start()
    {
        scoreMesh = GetComponentInChildren<TextMeshProUGUI>();
        scoreMesh.text = score.ToString();
    }

    public void Score()
    {
        score += 1000;
    }

    void Update()
    {
        scoreMesh.text = score.ToString();
    }
}
