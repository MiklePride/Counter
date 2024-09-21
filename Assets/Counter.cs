using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _currentCount;
    private bool _isCounterEnabled = false;
    private CounterRenderer _counterRenderer;
    private Coroutine _coroutine;

    public event Action<int> CounterChenged;

    private void Start()
    {
        CounterChenged?.Invoke(_currentCount);
    }

    private void Update()
    {
        int leftMouseButton = 0;

        if (Input.GetMouseButtonDown(leftMouseButton))
        {
            if (!_isCounterEnabled)
            {
                StartCount();
            }
            else
            {
                StopCount();
            }
        }
    }

    private IEnumerator Count()
    {
        float delayBeforeIncrease = 0.5f;
        var wait = new WaitForSeconds(delayBeforeIncrease);

        while (true)
        {
            _currentCount++;

            CounterChenged?.Invoke(_currentCount);

            yield return wait;
        }
    }

    private void StartCount()
    {
        _isCounterEnabled = true;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Count());
    }

    private void StopCount()
    {
        _isCounterEnabled = false;

        StopCoroutine(_coroutine);
    }
}
