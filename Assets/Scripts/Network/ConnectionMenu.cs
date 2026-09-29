using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine.UI;
using UnityEngine;



public class ConnectionMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuRoot;
    [SerializeField] private Camera menuCamera;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private InputField addressField;
    [SerializeField] private ushort port = 7777;
    private void Start()
    {
        hostButton.onClick.AddListener(OnHostClicked);
        clientButton.onClick.AddListener(OnClientClicked);
    }

    private void OnHostClicked()
    {
        ConfigureTransport(addressField.text, true);

        if (NetworkManager.Singleton.StartHost())
        {
            HideMenu();
        }
    }

    private void OnClientClicked()
    {
        ConfigureTransport(addressField.text, false);

        if (NetworkManager.Singleton.StartClient())
        {
            HideMenu();
        }
    }

    private void HideMenu()
    {
        menuRoot.SetActive(false);
        menuCamera.gameObject.SetActive(false);
    }

    private void ConfigureTransport(string address, bool asHost)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            address = "127.0.0.1";
        }

        UnityTransport transport =
            (UnityTransport)NetworkManager.Singleton.NetworkConfig.NetworkTransport;

        if (asHost)
        {
            // 0.0.0.0 lets machines on the local network reach this host.
            transport.SetConnectionData(address, port, "0.0.0.0");
        }
        else
        {
            transport.SetConnectionData(address, port);
        }
    }
}

