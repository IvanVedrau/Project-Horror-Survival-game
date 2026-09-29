using Unity.Netcode;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    private int nextSpawnIndex;

    private void Start()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += HandleConnectionApproval;
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.ConnectionApprovalCallback -= HandleConnectionApproval;
        }
    }

    private void HandleConnectionApproval(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {
        Transform spawnPoint = spawnPoints[nextSpawnIndex % spawnPoints.Length];
        nextSpawnIndex++;

        response.Approved = true;
        response.CreatePlayerObject = true;
        response.Position = spawnPoint.position;
        response.Rotation = spawnPoint.rotation;
    }
}
