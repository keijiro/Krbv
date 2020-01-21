using UnityEngine;
using Unity.Mathematics;

sealed class SpiralMove : MonoBehaviour
{
    [SerializeField] float _noiseFrequency = 0.5f;
    [SerializeField] float _noiseToRotation = 1;
    [SerializeField] float _speed = 0.2f;

    float3 _position;

    void Update()
    {
        var t = Time.time * _noiseFrequency;

        var n = math.float3(
            noise.snoise(math.float2(t, 323.341f)),
            noise.snoise(math.float2(t, 113.434f)),
            noise.snoise(math.float2(t, 3.14334f))
        );

        var rot = quaternion.EulerZXY(n * _noiseToRotation);

        _position += math.mul(rot, math.float3(0, 0, _speed * Time.deltaTime));

        transform.localPosition = _position;
        transform.localRotation = rot;
    }
}
