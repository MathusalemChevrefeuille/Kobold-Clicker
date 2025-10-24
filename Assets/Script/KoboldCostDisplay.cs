using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class KoboldCostDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public KoboldManager koboldManager;
    public TextMeshProUGUI costText;

    public enum KoboldType { Forager, Miner, Hunter, Raider, Shaman, Scavenger }
    public KoboldType koboldType;


    public void OnPointerEnter(PointerEventData eventData)
    {

        int foodCost = 0;
        int goldCost = 0;

        switch (koboldType)
        {
            case KoboldType.Forager:
                foodCost = koboldManager.costForagerFood;
                goldCost = koboldManager.costForagerGold;
                break;
            case KoboldType.Miner:
                foodCost = koboldManager.costMinerFood;
                goldCost = koboldManager.costMinerGold;
                break;
            case KoboldType.Hunter:
                foodCost = koboldManager.costHunterFood;
                goldCost = koboldManager.costHunterGold;
                break;
            case KoboldType.Raider:
                foodCost = koboldManager.costRaiderFood;
                goldCost = koboldManager.costRaiderGold;
                break;
            case KoboldType.Shaman:
                foodCost = koboldManager.costShamanFood;
                goldCost = koboldManager.costShamanGold;
                break;
            case KoboldType.Scavenger:
                foodCost = koboldManager.costScavengerFood;
                goldCost = koboldManager.costScavengerGold;
                break;
        }

        costText.text = $"Coût : {foodCost} Nourriture / {goldCost} Or";
        costText.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (costText != null)
            costText.gameObject.SetActive(false);
    }
}
