using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private AudioListener playerAudioListener;
    [SerializeField] private Canvas playerHud;
    [SerializeField] private MonoBehaviour[] ownerOnlyScripts;

    public override void OnNetworkSpawn()
    {
        if (IsOwner) return;

        // Remote copies are displayed, not played no camera, no sound, no input
        playerCamera.enabled = false;
        playerAudioListener.enabled = false;
        playerHud.gameObject.SetActive(false);

        for (int i = 0; i < ownerOnlyScripts.Length; i++)
        {
            ownerOnlyScripts[i].enabled = false;
        }

    }
}
