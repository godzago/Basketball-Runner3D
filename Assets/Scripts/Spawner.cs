using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 SpawnPos;
    public Transform SpawnPlacePos;
    public GameObject spawnObject;
    private float newSpanwDuration = 1.0f;

    #region Singleton 

    public static Spawner Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        SpawnPos = SpawnPlacePos.position;
    }
    public void SpanwNewObject()
    {
        Instantiate(spawnObject, SpawnPos, Quaternion.identity);
    }
    public void NewSpawnRequst()
    {
        Invoke("SpanwNewObject", newSpanwDuration);
    }
}
