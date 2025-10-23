using UnityEngine;
using TMPro;

public class KoboldFlavorText : MonoBehaviour
{
    public string[] flavorTexts;

    public TextMeshProUGUI flavorTextUI;

    private void Start()
    {
        if (flavorTexts == null || flavorTexts.Length == 0)
            LoadDefaultFacts();
    }

    public void ShowRandomFact()
    {
        if (flavorTexts == null || flavorTexts.Length == 0)
            LoadDefaultFacts();

        string randomFact = flavorTexts[Random.Range(0, flavorTexts.Length)];
        flavorTextUI.text = randomFact;
    }

    private void LoadDefaultFacts()
    {
        flavorTexts = new string[]
        {
            "Le saviez-vous ? Dans AD&D 2e édition, un kobold avait ½ dé de vie. Oui, c’est littéralement possible de mourir en éternuant trop fort.",
            "Fait amusant : les kobolds étaient considérés comme des “gobelins faibles”, jusqu’à ce qu’un designer décide qu’ils méritaient un culte draconique… et des frondes.",
            "Détail oublié : dans la version de 1977, les kobolds étaient roux et poilus. Oui, avant de devenir reptiliens, c’étaient des mini-gobelins punk.",
            "Fait historique : le mot “kobold” vient du vieil allemand pour “esprit de mine”. Donc même dans D&D, ils respectent la tradition syndicale.",
            "Petite précision : un kobold typique a une espérance de vie de 135 ans. C’est 134 de trop pour la plupart des aventuriers.",
            "Anecdote technique : dans Pathfinder, un kobold peut pondre des œufs ET miner du fer dans la même journée. Multitâche avant l’heure.",
            "Saviez-vous ? Les kobolds adorent les dragons, mais les dragons ne savent même pas qu’ils existent. Histoire classique d’amour à sens unique.",
            "Triste réalité : un kobold pèse 16 kg. Soit à peu près autant qu’un sac de pommes de terre.",
            "Fun fact : un groupe de 50 kobolds avec des frondes peut tuer un paladin de niveau 10. Statistiquement. Et dramatiquement.",
            "Saviez-vous que dans la 3.5, un kobold pouvait devenir moine et infliger 1d3 de dégâts à coups de queue ? Personne ne sait pourquoi."
        };
    }
}
