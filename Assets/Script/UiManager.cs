using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Textes UI")]
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI koboldTotalText;
    public TextMeshProUGUI koboldIdleText;
    public TextMeshProUGUI koboldMinerText;
    public TextMeshProUGUI koboldForagerText;
    public TextMeshProUGUI koboldShamanText;
    public TextMeshProUGUI koboldScavengerText;
    public TextMeshProUGUI koboldHunterText;
    public TextMeshProUGUI koboldRaiderText;

    public void UpdateFoodDisplay(int value) => foodText.text = value.ToString();
    public void UpdateGoldDisplay(int value) => goldText.text = value.ToString();

    public void UpdateKoboldDisplay(KoboldManager koboldManager)
    {
        koboldTotalText.text = koboldManager.totalKobolds.ToString();
        koboldIdleText.text = koboldManager.idleKobolds.ToString();
        koboldMinerText.text = koboldManager.koboldsMiner.ToString();
        koboldForagerText.text = koboldManager.koboldsForager.ToString();
        koboldShamanText.text = koboldManager.koboldsShaman.ToString();
        koboldScavengerText.text = koboldManager.koboldsScavenger.ToString();
        koboldHunterText.text = koboldManager.koboldsHunter.ToString();
        koboldRaiderText.text = koboldManager.koboldsRaider.ToString();
    }

    public void UpdateAllDisplays(int food, int gold, KoboldManager koboldManager)
    {
        UpdateFoodDisplay(food);
        UpdateGoldDisplay(gold);
        UpdateKoboldDisplay(koboldManager);
    }
}
