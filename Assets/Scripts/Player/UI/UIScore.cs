using TMPro;
using UnityEngine;

namespace Player.UI
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counterText;
        [SerializeField] private string _counterTextFormat;

        private void Start()
        {
            InboxCounter.Instance.UpdatedScoreEvent += UpdateScoreTextBox;
        }

        private void OnDisable()
        {
            InboxCounter.Instance.UpdatedScoreEvent -= UpdateScoreTextBox;
        }

        private void UpdateScoreTextBox(int score)
        {
            _counterText.SetText(string.Format(_counterTextFormat, score));
        }
    }
}
