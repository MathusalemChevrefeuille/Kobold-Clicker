using UnityEngine;
using TMPro;

public class UpgradeMenuManager : MonoBehaviour
{
    public GameObject panel;
    public bool isOpen = false;

    public KoboldManager koboldManager;
    public UIManager uiManager;
 
    public TextMeshProUGUI foragerCountText;
    public TextMeshProUGUI minerCountText;
    public TextMeshProUGUI shamanCountText;
    public TextMeshProUGUI scavengerCountText;
    public TextMeshProUGUI hunterCountText;
    public TextMeshProUGUI raiderCountText;

    public GameObject feedbackPrefab;   
    public Transform feedbackParent;


    public void ShowFeedback(string message, Color color)
    {
        GameObject obj = Instantiate(feedbackPrefab, feedbackParent);
        obj.transform.position = Input.mousePosition; // pop à la souris

        var fb = obj.GetComponent<FloatingFeedback>();
        fb.SetText(message, color);
    }

    void Start()
    {
        panel.SetActive(false);
    }

    public void ToggleMenu()
    {
        isOpen = !isOpen;
        panel.SetActive(isOpen);
    }

    public void AddForager()
    {
        int result = koboldManager.AssignForager();

        if (result == 0) 
            {
            ShowFeedback("Aucun kobold disponible !", Color.red);
            return; 
            }
        else if (result == 1)
        {
            ShowFeedback("Pas assez de ressources !", Color.red);
            return;
        }
        else if (result == 2)
        {
            RefreshUI();
        }
    }

    public void RemoveForager()
    {
        int result = koboldManager.UnassignForager();

        if (result == 0)
        {
            ShowFeedback("Aucun Kobold à retirer !", Color.red);
            return;
        }
        else if (result == 1)
        {
            RefreshUI(); 
        }
    }

    public void AddMiner()
    {
        int result = koboldManager.AssignMiner();

        if (result == 0)
        {
            ShowFeedback("Aucun kobold disponible !", Color.red);
            return;
        }
        else if (result == 1)
        {
            ShowFeedback("Pas assez de ressources !", Color.red);
            return;
        }
        else if (result == 2)
        {
            RefreshUI();
        }
    }

    public void RemoveMiner()
    {
        int result = koboldManager.UnassignMiner();

        if (result == 0)
        {
            ShowFeedback("Aucun Kobold à retirer !", Color.red);
            return;
        }
        else if (result == 1)
        {
            RefreshUI();
        }
    }
    public void AddShaman()
    {
        int result = koboldManager.AssignShaman();

        if (result == 0)
        {
            ShowFeedback("Aucun kobold disponible !", Color.red);
            return;
        }
        else if (result == 1)
        {
            ShowFeedback("Pas assez de ressources !", Color.red);
            return;
        }
        else if (result == 2)
        {
            RefreshUI();
        }
    }

    public void RemoveShaman()
    {
        int result = koboldManager.UnassignShaman();

        if (result == 0)
        {
            ShowFeedback("Aucun Kobold à retirer !", Color.red);
            return;
        }
        else if (result == 1)
        {
            RefreshUI();
        }
    }
    public void AddScavenger()
    {
        int result = koboldManager.AssignScavenger();

        if (result == 0)
        {
            ShowFeedback("Aucun kobold disponible !", Color.red);
            return;
        }
        else if (result == 1)
        {
            ShowFeedback("Pas assez de ressources !", Color.red);
            return;
        }
        else if (result == 2)
        {
            RefreshUI();
        }
    }

    public void RemoveScavenger()
    {
        int result = koboldManager.UnassignScavenger();

        if (result == 0)
        {
            ShowFeedback("Aucun Kobold à retirer !", Color.red);
            return;
        }
        else if (result == 1)
        {
            RefreshUI();
        }
    }
    public void AddHunter()
    {
        int result = koboldManager.AssignHunter();

        if (result == 0)
        {
            ShowFeedback("Aucun kobold disponible !", Color.red);
            return;
        }
        else if (result == 1)
        {
            ShowFeedback("Pas assez de ressources !", Color.red);
            return;
        }
        else if (result == 2)
        {
            RefreshUI();
        }
    }

    public void RemoveHunter()
    {
        int result = koboldManager.UnassignHunter();

        if (result == 0)
        {
            ShowFeedback("Aucun Kobold à retirer !", Color.red);
            return;
        }
        else if (result == 1)
        {
            RefreshUI();
        }
    }
    public void AddRaider()
    {
        int result = koboldManager.AssignRaider();

        if (result == 0)
        {
            ShowFeedback("Aucun kobold disponible !", Color.red);
            return;
        }
        else if (result == 1)
        {
            ShowFeedback("Pas assez de ressources !", Color.red);
            return;
        }
        else if (result == 2)
        {
            RefreshUI();
        }
    }

    public void RemoveRaider()
    {
        int result = koboldManager.UnassignRaider();

        if (result == 0)
        {
            ShowFeedback("Aucun Kobold à retirer !", Color.red);
            return;
        }
        else if (result == 1)
        {
            RefreshUI();
        }
    }
    public void RefreshUI()
    {
        foragerCountText.text = koboldManager.koboldsForager.ToString();
        minerCountText.text = koboldManager.koboldsMiner.ToString();
        shamanCountText.text = koboldManager.koboldsShaman.ToString();
        scavengerCountText.text = koboldManager.koboldsScavenger.ToString();
        hunterCountText.text = koboldManager.koboldsHunter.ToString();
        raiderCountText.text = koboldManager.koboldsRaider.ToString();
        koboldManager.UpdateTotalKobolds();


        uiManager.UpdateKoboldDisplay(koboldManager);
    }
}
