using UnityEngine;
using System.Collections.Generic;

sealed class DelayFollower : MonoBehaviour
{
    [SerializeField] Transform _target = null;
    [SerializeField] float _delay = 1;

    Queue<(float time, Vector3 position, Quaternion rotation)> _queue
        = new Queue<(float, Vector3, Quaternion)>();

    (float time, Vector3 position, Quaternion rotation) _last;

    float _lastUpdateTime;

    void Update()
    {
        var current = Time.time;

        while (_queue.Count > 0)
        {
            var next = _queue.Peek();
            if (next.time > current - _delay) break;
            _last = _queue.Dequeue();
        }

        if (_queue.Count > 0)
        {
            var next = _queue.Peek();
            var t = (current - _delay - _last.time) / (next.time - _last.time);
            transform.position = Vector3.Lerp(_last.position, next.position, t);
            transform.rotation = Quaternion.Slerp(_last.rotation, next.rotation, t);
        }

        _queue.Enqueue((current, _target.position, _target.rotation));
    }
}
