using UnityEngine;

public class CounterRenderer : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterChenged += OnRender;
    }

    private void OnDestroy()
    {
        _counter.CounterChenged -= OnRender;
    }

    public void OnRender(int value)
    {
        Debug.Log(value);
    }
}
