using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    public GameManager gameManager;

    [Header("Slots menu Upgrade")]
    public GameObject foragerSlotUpgrade;
    public GameObject minerSlotUpgrade;
    public GameObject shamanSlotUpgrade;
    public GameObject scavengerSlotUpgrade;
    public GameObject hunterSlotUpgrade;
    public GameObject raiderSlotUpgrade;

    [Header("Cases UI principale (barre du haut)")]
    public GameObject foragerUI;
    public GameObject minerUI;
    public GameObject shamanUI;
    public GameObject scavengerUI;
    public GameObject hunterUI;
    public GameObject raiderUI;

    [Header("Seuils de déblocage")]
    public int tier2Threshold = 200;
    public int tier3Threshold = 400;


    public bool tier2Unlocked = false;
    public bool tier3Unlocked = false;

    void Start()
    {

        foragerSlotUpgrade.SetActive(true);
        minerSlotUpgrade.SetActive(true);
        foragerUI.SetActive(true);
        minerUI.SetActive(true);


        shamanSlotUpgrade.SetActive(false);
        scavengerSlotUpgrade.SetActive(false);
        hunterSlotUpgrade.SetActive(false);
        raiderSlotUpgrade.SetActive(false);

        shamanUI.SetActive(false);
        scavengerUI.SetActive(false);
        hunterUI.SetActive(false);
        raiderUI.SetActive(false);
    }

    void Update()
    {
        int food = gameManager.food;
        int gold = gameManager.gold;


        if (!tier2Unlocked && food >= tier2Threshold && gold >= tier2Threshold)
        {
            tier2Unlocked = true;

            shamanSlotUpgrade.SetActive(true);
            scavengerSlotUpgrade.SetActive(true);
            shamanUI.SetActive(true);
            scavengerUI.SetActive(true);

        }

        if (!tier3Unlocked && food >= tier3Threshold && gold >= tier3Threshold)
        {
            tier3Unlocked = true;

            hunterSlotUpgrade.SetActive(true);
            raiderSlotUpgrade.SetActive(true);
            hunterUI.SetActive(true);
            raiderUI.SetActive(true);
        }
    }
}
