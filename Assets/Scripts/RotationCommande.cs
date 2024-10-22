using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCommande : MonoBehaviour
{
    public GameObject Rotation;
    public string axe;
    public int Sens = 1;


    void Update()//envoie l'état de mouvement à RotationControleur
    {
        float input = Input.GetAxis(axe);
        EtatRotation rotationState = MoveStateForInput(input);
        RotationControleur controller = Rotation.GetComponent<RotationControleur>();
        controller.rotationState = rotationState;
    }

    //envoie dans quel état de mouvement l'articulation devrait être
    EtatRotation MoveStateForInput(float input)
    {
        if (Sens == 1)
        {
            if (input > 0)
            {
                return EtatRotation.Positif;
            }
            else if (input < 0)
            {
                return EtatRotation.Negatif;
            }
            else
            {
                return EtatRotation.Fixe;
            }
        }
        else if (Sens == -1)
        {
            if (input < 0)
            {
                return EtatRotation.Positif;
            }
            else if (input > 0)
            {
                return EtatRotation.Negatif;
            }
            else
            {
                return EtatRotation.Fixe;
            }
        }
        else
        {
            return EtatRotation.Fixe;
        }
    }
}
