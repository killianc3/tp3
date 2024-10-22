using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//on définit ici les états de mouvement utilisé dans Translation Commande
//Fixe ne fait rien, Positif fait "tourner" dans un sens, Negatif fait "tourner" dans l'autre sens
public enum EtatRotation { Fixe = 0, Positif = 1, Negatif = -1 };

public class RotationControleur : MonoBehaviour
{
    //l'articulation est initialisée en mode Fixe pour être "au repos"
    public EtatRotation rotationState = EtatRotation.Fixe;
    //vitesse de rotation par défaut, public siginifie qu'elle peut être modifiée dans l'inspecteur
    public float speed = 30.0f;

    private ArticulationBody articulation;

    void Start()
    {
        articulation = GetComponent<ArticulationBody>();
    }

    void FixedUpdate() //FixedUpdate est comme Update, mais synchronisé avec le moteur physique d'unity
    {
        if (rotationState != EtatRotation.Fixe)
        {
            float rotationChange = (float)rotationState * speed * Time.fixedDeltaTime;
            float rotationGoal = CurrentPrimaryAxisRotation() + rotationChange;
            RotateTo(rotationGoal);
        }
    }

    float CurrentPrimaryAxisRotation()
    {
        float currentRotationRads = articulation.jointPosition[0];
        float currentRotation = Mathf.Rad2Deg * currentRotationRads;
        return currentRotation;
    }

    void RotateTo(float primaryAxisRotation)
    {
        var drive = articulation.xDrive;
        drive.target = primaryAxisRotation;
        articulation.xDrive = drive;
    }
}
