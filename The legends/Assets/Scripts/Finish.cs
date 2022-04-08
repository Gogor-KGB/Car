using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private Timer_Points timerPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<Car>(out _)) 
            timerPoints.isTimerEnabled = false;
    }
}