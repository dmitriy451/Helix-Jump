using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private float additionalScale;
    [SerializeField] private StartPlatform _spawnPlaform;
    [SerializeField] private Platform[] _platform;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _startAndFinishAdditionalScale = 0.5f;
    public float BeamScaleY => levelCount / 2f + _startAndFinishAdditionalScale + additionalScale /2;
    private void Awake()
    {
        build();
    }
    private void build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - additionalScale;

        SpawnPlatform(_spawnPlaform, ref spawnPosition, beam.transform);
        for (int i = 0; i < levelCount; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, beam.transform);
        }
        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
    }
    private void SpawnPlatform(Platform platform,ref Vector3 spawnPosition, Transform parent)
    {
        Platform _platform = Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        _platform.transform.localScale = new Vector3(1, _platform.transform.localScale.y / (levelCount / 4f),1);
        spawnPosition.y -= 1;
    }
}
