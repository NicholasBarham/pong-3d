using System.Collections;
using UnityEngine;
using Util.Variables;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private bool freezeTranslation = false;
    [SerializeField]
    private Vector3 maximumTranslationShake = Vector3.one;

    [SerializeField]
    private bool freezeRotation = false;
    [SerializeField]
    private Vector3 maximumAngularShake = Vector3.one * 15f;

    [SerializeField]
    private float frequency = 25f;

    [SerializeField]
    private float traumaExponent = 2f;

    [SerializeField]
    private float recoverySpeed = 1f;

    [SerializeField]
    private FloatVariable trauma = null;

    private float seed;

    private Coroutine _decreasingTrauma = null;

    private void Awake()
    {
        seed = Random.value;
    }

    private void DecreaseTrauma()
    {
        float shake = Mathf.Pow(trauma.Value, traumaExponent);

        if (!freezeTranslation)
        {
            transform.localPosition = new Vector3(
                maximumTranslationShake.x * (Mathf.PerlinNoise(seed, Time.time * frequency) * 2 - 1),
                maximumTranslationShake.y * (Mathf.PerlinNoise(seed + 1, Time.time * frequency) * 2 - 1),
                maximumTranslationShake.z * (Mathf.PerlinNoise(seed + 2, Time.time * frequency) * 2 - 1)
            ) * shake;
        }

        if (!freezeRotation)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(
                maximumAngularShake.x * (Mathf.PerlinNoise(seed + 3, Time.time * frequency) * 2 - 1),
                maximumAngularShake.y * (Mathf.PerlinNoise(seed + 4, Time.time * frequency) * 2 - 1),
                maximumAngularShake.z * (Mathf.PerlinNoise(seed + 5, Time.time * frequency) * 2 - 1)
            ) * shake);
        }

        trauma.Value = Mathf.Clamp01(trauma.Value - recoverySpeed * Time.deltaTime);
    }

    private IEnumerator DecreasingTrauma()
    {
        while (trauma.Value > 0f)
        {
            DecreaseTrauma();
            yield return null;
        }

        _decreasingTrauma = null;
    }

    public void InduceStress(float stress)
    {
        trauma.Value = Mathf.Clamp01(trauma.Value + stress);

        if (_decreasingTrauma == null)
            _decreasingTrauma = StartCoroutine(DecreasingTrauma());
    }
}
