using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//on définit ici les états de mouvement utilisé dans Translation Commande
//Fixe ne fait rien, Positif fait "avancer", Negatif fait "reculer"
public enum EtatTranslation { Fixe = 0, Positif = 1, Negatif = -1 };
public enum ArticulationAxis { XDrive, YDrive, ZDrive };

public class TranslationControleur : MonoBehaviour
{
    //l'articulation est initialisée en mode Fixe pour être "au repos"
    public EtatTranslation moveState = EtatTranslation.Fixe;
    //vitesse de translation par défaut, public siginifie qu'elle peut être modifiée dans l'inspecteur
    public float speed = 1.0f;
    public ArticulationAxis selectedAxis = ArticulationAxis.XDrive;

    private void FixedUpdate() //FixedUpdate est comme Update, mais synchronisé avec le moteur physique d'unity
    {
        if (moveState != EtatTranslation.Fixe)
        {
            ArticulationBody articulation = GetComponent<ArticulationBody>();

            //obtient la position du joint sur l'axe X ([0])
            float xDrivePostion = articulation.jointPosition[0];

            //change la position sur l'axe X
            float targetPosition = xDrivePostion + -(float)moveState * Time.fixedDeltaTime * speed;

            var drive = new ArticulationDrive();
            switch (selectedAxis)
            {
                case ArticulationAxis.XDrive:
                    drive = articulation.xDrive;
                    break;
                case ArticulationAxis.YDrive:
                    drive = articulation.yDrive;
                    break;
                case ArticulationAxis.ZDrive:
                    drive = articulation.zDrive;
                    break;
            }

            //donne l'ordre au joint de rejoindre la position définie par targetPosition
            drive.target = targetPosition;

            switch (selectedAxis)
            {
                case ArticulationAxis.XDrive:
                    articulation.xDrive = drive;
                    break;
                case ArticulationAxis.YDrive:
                    articulation.yDrive = drive;
                    break;
                case ArticulationAxis.ZDrive:
                    articulation.zDrive = drive;
                    break;
            }
        }
    }
}
