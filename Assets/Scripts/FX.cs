using UnityEngine;

public class FX : MonoBehaviour
{
    public static FX Instance;

    [SerializeField] private ParticleSystem cubeExplosionFX;

    ParticleSystem.MainModule cubeExploisonFXMainModule;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cubeExploisonFXMainModule = cubeExplosionFX.main;
    }

    public void PlayCubeExplosionFX (Vector3 Position, Color color)
    {
        cubeExploisonFXMainModule.startColor = new ParticleSystem.MinMaxGradient(color);
        cubeExplosionFX.transform.position = Position;
        cubeExplosionFX.Play();
    }
}
