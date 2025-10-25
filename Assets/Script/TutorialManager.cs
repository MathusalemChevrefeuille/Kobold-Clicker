using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameManager gameManager;
    public UnlockManager unlockManager;
    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;

    private int step = 0;
    private bool tier2Shown = false;
    private bool tier3Shown = false;

    void Start()
    {
        ShowText("Clique sur la viande pour récolter de la nourriture et attirer ton premier kobold !");
    }

    void Update()
    {
        if (step == 0 && gameManager.koboldManager.totalKobolds >= 1)
        {
            ShowText("Tu as recruté ton premier kobold ! Clique sur 'Rôles' pour lui attribuer une tâche.");
            step = 1;
        }

        if (!tier2Shown && unlockManager.tier2Unlocked)
        {
            ShowText("De nouveaux rôles sont disponibles ! Découvre les Chamans et Recupérateurs !");
            tier2Shown = true;
        }

        if (!tier3Shown && unlockManager.tier3Unlocked)
        {
            ShowText("Les Chasseurs et Pillards rejoignent ton clan !");
            tier3Shown = true;
        }
    }

    void ShowText(string text)
    {
        tutorialPanel.SetActive(true);
        tutorialText.text = text;
        CancelInvoke();
        Invoke(nameof(HideText), 6f);
    }

    void HideText()
    {
        tutorialPanel.SetActive(false);
    }
}
