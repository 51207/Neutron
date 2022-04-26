using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{


    public static List<List<int>> allpositionjoueurs = new List<List<int>>();
    public static List<List<int>> allpositionennemi = new List<List<int>>();
    public static List<int> Stockvalueballball = new List<int>();


    // Start is called before the first frame update
    public static int Get_Calculfunction()
    {
        //on utilise cette fonction lorsqu'un pion (joueur ou ennemi ou ball) n'a pas de possiblité de jouer, le jeu se termine là 
        //on cherche à savoir en ce moment qui gagne


    int valuesEnnemi = 0;
        int valuesJoueur = 0;
        //plus on est proche de la ligne opposée, plus on bloque les mouvements des adversaires ,plus on est succeptible de gagner

        foreach (var item in  allpositionjoueurs)
        {
            //on prend seulement la position i  de chaque pion ennemi
            // valuesEnnemi += ( item[0]-6);
            valuesJoueur += (item[0]);

        }

        //on fait -2 et +2 au niveau de la postion de la balle
        valuesJoueur += (4 - Stockvalueballball[0]);
        foreach (var item in allpositionennemi)
        {

            valuesEnnemi += (4 + item[0]);

        }
        valuesEnnemi += (Stockvalueballball[0] + 2);
        //si la fonction retourne une valeur negative  cvd que je l'ennemi gagne 
        return valuesJoueur - valuesEnnemi;
    }

}
