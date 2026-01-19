using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PIckUpsScript : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask exludeLayers;
    public GameObject pickupPanel;
    public float pickupDisplayDistance = 8;

    public Text mainTitles;
    public Image mainImage;

    public Sprite[] weaponIcons;
    public string[] weaponTitles;

    public Sprite[] itemIcons;
    public string[] itemTitles;

    public Sprite[] ammoIcons;
    public string[] ammoTitles;

    public GameObject doorMessageObj;
    public Text doorMessage;
    public AudioClip[] pickupSounds;


    private int objID = 0;
    private AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        pickupPanel.SetActive(false);
        audioPlayer = GetComponent<AudioSource>();
        doorMessageObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 30, ~exludeLayers))
        {
            if(Vector3.Distance(transform.position, hit.transform.position)< pickupDisplayDistance)
            { 
            if (hit.transform.gameObject.CompareTag("Weapon"))

            {
                pickupPanel.SetActive(true);
                objID = (int)hit.transform.gameObject.GetComponent<WeaponType>().chooseWeapon;
                mainImage.sprite = weaponIcons[objID];
                mainTitles.text = weaponTitles[objID];

                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.weaponAmts[objID]++;
                        audioPlayer.clip = pickupSounds[3];
                        audioPlayer.Play();
                        SaveScript.change = true;
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
            }
                else if (hit.transform.gameObject.CompareTag("item"))

                {
                    pickupPanel.SetActive(true);
                    objID = (int)hit.transform.gameObject.GetComponent<ItemsType>().chooseItem;
                    mainImage.sprite = itemIcons[objID];
                    mainTitles.text = itemTitles[objID];

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.itemAmts[objID]++;
                        audioPlayer.clip = pickupSounds[3];
                        audioPlayer.Play();
                        SaveScript.change = true;
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                }

                else if (hit.transform.gameObject.CompareTag("ammo"))

                {
                    pickupPanel.SetActive(true);
                    objID = (int)hit.transform.gameObject.GetComponent<AmmoType>().chooseAmmo;
                    mainImage.sprite = ammoIcons[objID];
                    mainTitles.text = ammoTitles[objID];

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.ammoAmts[objID]++;
                        audioPlayer.clip = pickupSounds[3];
                        audioPlayer.Play();
                        SaveScript.change = true;
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                }

                else if (hit.transform.gameObject.CompareTag("door"))

                {
                    objID = (int)hit.transform.gameObject.GetComponent<DoorType>().chooseDoor;

                    if (hit.transform.gameObject.GetComponent<DoorType>().locked == true)
                    {
                        hit.transform.gameObject.GetComponent<DoorType>().message = "Locked. You nee to use the " + hit.transform.gameObject.GetComponent<DoorType>().chooseDoor+ " key";
                            
                    }

                    doorMessageObj.SetActive(true);
                    doorMessage.text = hit.transform.gameObject.GetComponent<DoorType>().message;
                    if (Input.GetKeyDown(KeyCode.E) && hit.transform.gameObject.GetComponent<DoorType>().locked == false)
                    {
                        audioPlayer.clip = pickupSounds[objID];
                        audioPlayer.Play();
                        if(hit.transform.gameObject.GetComponent<DoorType>().opened == false)
                        {
                            hit.transform.gameObject.GetComponent<DoorType>().message = "Press E to close the door";
                            hit.transform.gameObject.GetComponent<DoorType>().opened = true;
                            hit.transform.gameObject.GetComponent<Animator>().SetTrigger ("Open");
                        }

                        else if (hit.transform.gameObject.GetComponent<DoorType>().opened == true)
                        {
                            hit.transform.gameObject.GetComponent<DoorType>().message = "Press E to open the door";
                            hit.transform.gameObject.GetComponent<DoorType>().opened = false;
                            hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Close");
                        }
                        audioPlayer.Play();
                    }
                }

            }
            else
            {
                pickupPanel.SetActive(false);
                doorMessageObj.SetActive(false);

            }
        }
    }
}
