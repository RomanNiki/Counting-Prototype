using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour, ICounter
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private string _counterTextFormat;
    private int _score;

    private void UpdateScoreText()
    {
        _counterText.SetText(string.Format(_counterTextFormat, _score));
    }

   

    public void UpdateScoreText(int scorePoint)
    {
        _score += scorePoint;
        UpdateScoreText();
    }
}

public interface ICounter
{
    void UpdateScoreText(int scorePoint);
}