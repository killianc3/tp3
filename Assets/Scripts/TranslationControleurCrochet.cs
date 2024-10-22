using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//on définit ici les états de mouvement utilisé dans Translation Commande
//Fixe ne fait rien, Positif fait "avancer", Negatif fait "reculer"

public class TranslationControleurCrochet : MonoBehaviour
{
    //l'articulation est initialisée en mode Fixe pour être "au repos"
    public EtatTranslation moveState = EtatTranslation.Fixe;
    //vitesse de translation par défaut, public siginifie qu'elle peut être modifiée dans l'inspecteur
    public float speed = 1.0f;

    private void FixedUpdate() //FixedUpdate est comme Update, mais synchronisé avec le moteur physique d'unity
    {
        if (moveState != EtatTranslation.Fixe)
        {
            ArticulationBody articulation = GetComponent<ArticulationBody>();

            //obtient la position du joint sur l'axe X ([0])
            float xDrivePostion = articulation.jointPosition[0];

            //change la position sur l'axe X
            float targetPosition = xDrivePostion + -(float)moveState * Time.fixedDeltaTime * speed;

            //donne l'ordre au joint de rejoindre la position définie par targetPosition
            var drive = articulation.xDrive;
            drive.target = targetPosition;
            articulation.xDrive = drive;
        }
    }
}
