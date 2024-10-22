using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationCommande : MonoBehaviour
{
    public GameObject Translation;
    public string axe = "Fleche";
    private TranslationControleur controller;

    void Update() //envoie l'état de mouvement à TranslationControleur
    {
        float input = Input.GetAxis(axe);
        EtatTranslation moveState = MoveStateForInput(input);
        TranslationControleur controller = Translation.GetComponent<TranslationControleur>();
        controller.moveState = moveState;
    }

    //envoie dans quel état de mouvement l'articulation devrait être
    EtatTranslation MoveStateForInput(float input)
    {
        if (input > 0)
        {
            return EtatTranslation.Positif;
        }
        else if (input < 0)
        {
            return EtatTranslation.Negatif;
        }
        else
        {
            return EtatTranslation.Fixe;
        }
    }
}
