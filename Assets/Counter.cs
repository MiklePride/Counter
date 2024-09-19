using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _currentCount;
    private bool _isCounterEnabled = false;
    private Coroutine _coroutine;

    private void Start()
    {
        Debug.Log(_currentCount);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

            Debug.Log(_currentCount);

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
