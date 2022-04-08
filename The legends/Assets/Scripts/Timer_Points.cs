using System.Globalization;
using TMPro;
using UnityEngine;

public class Timer_Points : MonoBehaviour
{
    [SerializeField] private float startTimerValue = 60f;

    public bool isTimerEnabled = true;
    private TextMeshProUGUI _timer;

    private void Start()
    {
        _timer = GetComponent<TextMeshProUGUI>();
        _timer.text = $"{startTimerValue}";
    }

    private void Update()
    {
        if (isTimerEnabled)
        {
            startTimerValue -= Time.deltaTime;
            _timer.text = startTimerValue.ToString("F1", CultureInfo.InvariantCulture);
        }

        if (startTimerValue <= 0)
            isTimerEnabled = false;
    }
}