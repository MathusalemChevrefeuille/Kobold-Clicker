using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TooltipKoboldInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Références")]
    public KoboldManager koboldManager;
    public TextMeshProUGUI tooltipText;

    [Header("Infos")]
    public string koboldName;
    [TextArea] public string description;

    public enum KoboldType { Forager, Miner, Hunter, Raider, Shaman, Scavenger, Idle, Total }
    public KoboldType koboldType;

    void Start()
    {
        if (tooltipText != null)
            tooltipText.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tooltipText == null || koboldManager == null) return;

        tooltipText.gameObject.SetActive(true);

        float productionIndividual = 0f;
        float productionTotal = 0f;
        string unit = "";
        string line2 = "";

        switch (koboldType)
        {
            case KoboldType.Forager:
                koboldName = "Kobold Fourrageur";
                description = "Cherche de la nourriture dans les tunnels voisins.";
                productionIndividual = koboldManager.foodPerForager;
                productionTotal = koboldManager.koboldsForager * productionIndividual;
                unit = "Nourriture/sec";
                break;

            case KoboldType.Miner:
                koboldName = "Kobold Mineur";
                description = "Creuse la roche pour extraire de l’or et des pierres précieuses.";
                productionIndividual = koboldManager.GoldPerMiner;
                productionTotal = koboldManager.koboldsMiner * productionIndividual;
                unit = "Or/sec";
                break;

            case KoboldType.Hunter:
                koboldName = "Kobold Chasseur";
                description = "Rapporte de la viande fraîche et augmente aussi la nourriture par clic.";
                productionIndividual = koboldManager.FoodperHunter;
                productionTotal = koboldManager.koboldsHunter * productionIndividual;
                unit = "Nourriture /sec";
                line2 = $"(Bonus clic : +{koboldManager.FoodClickperHunter} par chasseur)";
                break;

            case KoboldType.Raider:
                koboldName = "Kobold Pillard";
                description = "Part en expédition pour ramener de l’or.";
                productionIndividual = koboldManager.GoldperRaider;
                productionTotal = koboldManager.koboldsRaider * productionIndividual;
                unit = "Or/sec";
                break;

            case KoboldType.Shaman:
                koboldName = "Kobold Chaman";
                description = "Canalise la magie du feu pour réduire le cooldown des clics.";
                productionIndividual = koboldManager.shamanClickReducer * 100f;
                productionTotal = koboldManager.koboldsShaman * productionIndividual;
                unit = "% réduction de cooldown";
                break;

            case KoboldType.Scavenger:
                koboldName = "Kobold Charognard";
                description = "Récupère les restes des batailles et les revend.";
                productionIndividual = koboldManager.GoldperScavenger;
                productionTotal = koboldManager.koboldsScavenger * productionIndividual;
                unit = "Or/sec";
                break;

            case KoboldType.Idle:
                tooltipText.text = "Ces kobolds attendent une tâche à accomplir.";
                return;

            case KoboldType.Total:
                tooltipText.text = "Nombre total de kobolds dans la tribu.";
                return;
        }

        tooltipText.text =
            $"<b>{koboldName}</b>\n" +
            $"{description}\n\n" +
            $"Production : {productionIndividual} {unit} chacun — Total : {productionTotal:0.##} {unit}\n" +
            $"{line2}";

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tooltipText != null)
            tooltipText.gameObject.SetActive(false);
    }
}
