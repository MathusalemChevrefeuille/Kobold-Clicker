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
            "Le saviez-vous ? Dans AD&D 2e �dition, un kobold avait � d� de vie. Oui, c�est litt�ralement possible de mourir en �ternuant trop fort.",
            "Fait amusant : les kobolds �taient consid�r�s comme des �gobelins faibles�, jusqu�� ce qu�un designer d�cide qu�ils m�ritaient un culte draconique� et des frondes.",
            "D�tail oubli� : dans la version de 1977, les kobolds �taient roux et poilus. Oui, avant de devenir reptiliens, c��taient des mini-gobelins punk.",
            "Fait historique : le mot �kobold� vient du vieil allemand pour �esprit de mine�. Donc m�me dans D&D, ils respectent la tradition syndicale.",
            "Petite pr�cision : un kobold typique a une esp�rance de vie de 135 ans. C�est 134 de trop pour la plupart des aventuriers.",
            "Anecdote technique : dans Pathfinder, un kobold peut pondre des �ufs ET miner du fer dans la m�me journ�e. Multit�che avant l�heure.",
            "Saviez-vous ? Les kobolds adorent les dragons, mais les dragons ne savent m�me pas qu�ils existent. Histoire classique d�amour � sens unique.",
            "Triste r�alit� : un kobold p�se 16 kg. Soit � peu pr�s autant qu�un sac de pommes de terre.",
            "Fun fact : un groupe de 50 kobolds avec des frondes peut tuer un paladin de niveau 10. Statistiquement. Et dramatiquement.",
            "Saviez-vous que dans la 3.5, un kobold pouvait devenir moine et infliger 1d3 de d�g�ts � coups de queue ? Personne ne sait pourquoi."
        };
    }
}
