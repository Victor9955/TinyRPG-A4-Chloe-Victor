using System.Threading.Tasks;
using UnityEngine;

public class RoundItemSpawner : MonoBehaviour, ITriggerAction
{
    [SerializeField] ItemSO item;
    [SerializeField] Transform spawnPos;
    [SerializeField] float spawnRadius = 5f;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] int numberOfItems = 10;

    public void IOnTriggerEnter(Collider other)
    {
        // Test Animation avec async await
        SpawnObjectsInCircle();
    }

    public void IOnTriggerStay(Collider other) { }

    public void IOnTriggerStop(Collider other) { }

    public async Task SpawnObjectsInCircle()
    {
        for (int i = 0; i < 10; i++)
        {
            float angle = i * (2 * Mathf.PI) / numberOfItems;
            Vector3 spawnPosition = new Vector3(
                spawnPos.position.x + Mathf.Cos(angle) * spawnRadius,
                spawnPos.position.y,
                spawnPos.position.z + Mathf.Sin(angle) * spawnRadius
            );
            PoolManager.Instance.Get(item,spawnPosition, Quaternion.LookRotation(spawnPosition));

            await Task.Delay(Mathf.RoundToInt(spawnInterval * 1000));
        }
    }
}
