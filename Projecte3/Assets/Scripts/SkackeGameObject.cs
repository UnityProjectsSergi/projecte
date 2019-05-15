using UnityEngine;
using System.Collections;

// based onarticle from https://roystan.net/articles/camera-shake.html
public class SkackeGameObject : MonoBehaviour
{

    public bool hasRecovery;
    public bool PositionShake;
    public bool RotationShake;

    public Vector3 maxPositionShake = Vector3.one;
    public Vector3 maxAngularShake = Vector3.one * 15;
    public float frequency = 25;
    public float traumaExponent = 1;
    public float recoverySpeed = 1;
    private float trauma;

    private float seed;

    private void Start()
    {
        seed = Random.value;
    }

    private void Update()
    {
        float shake = Mathf.Pow(trauma, traumaExponent);
        Shake(shake);
        if(hasRecovery)
            trauma = Mathf.Clamp01(trauma - recoverySpeed * Time.deltaTime);
    }
    
    public void InduceShacke(float shacke)
    {
        trauma = Mathf.Clamp01(trauma + shacke);
    }
    public void Shake(float shake)
    {
        if (PositionShake)
        {
            transform.localPosition = new Vector3(maxPositionShake.x * (Mathf.PerlinNoise(seed, Time.time * frequency) * 2 - 1),maxPositionShake.y * (Mathf.PerlinNoise(seed + 1, Time.time * frequency) * 2 - 1),
                maxPositionShake.z * (Mathf.PerlinNoise(seed + 2, Time.time * frequency) * 2 - 1)
            ) * shake;
        }
        if (RotationShake)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(maxAngularShake.x * (Mathf.PerlinNoise(seed + 3, Time.time * frequency) * 2 - 1),maxAngularShake.y * (Mathf.PerlinNoise(seed + 4, Time.time * frequency) * 2 - 1),
                maxAngularShake.z * (Mathf.PerlinNoise(seed + 5, Time.time * frequency) * 2 - 1)
            ) * shake);
        }
    }

    internal void StopShake()
    {
        trauma = 0;
    }
}
