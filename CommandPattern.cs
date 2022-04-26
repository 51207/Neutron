using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CommandPattern_select 
{
    // le command pattern va rendre reel un appel à une function 
    //cad  on va remplacé l'appel à cette function par une  classe , ou un objet qui va aencapsuler cette function
    //remmapping de touche
    void select(Pion p);
    
}
public interface CommandPattern_move
{
    // le command pattern va rendre reel un appel à une function 
    //cad  on va remplacé l'appel à cette function par une  classe , ou un objet qui va aencapsuler cette function
    //remmapping de touche
  
    void move(Square b);
}
public class movement_SelectCommand : CommandPattern_select
{

    //************pion*******************
    public static void deselectedPlayerColor()
    {
        // to deselected backColor

        Pion previous_GameObject_player;
        Pion previous_GameObject_ennemi;
        GameObject antboxSolution;


        if (PropNeed.deselectedcolorPlayer.Count != 0)
        {
            previous_GameObject_player = (Pion)PropNeed.deselectedcolorPlayer[0];


            previous_GameObject_player.GetComponent<Renderer>().material.color = Color.black;

        }

        if (PropNeed.deselectedcolorEnnemi.Count != 0)
        {
            previous_GameObject_ennemi = (Pion)PropNeed.deselectedcolorEnnemi[0];
            previous_GameObject_ennemi.GetComponent<Renderer>().material.color = Color.black;


        }



        if (PropNeed.deselectedcolorSolution.Count != 0)
        {


            for (int i = 0; i < (PropNeed.deselectedcolorSolution.Count - 1); i++)
            {
                if (i % 2 == 0)
                {
                    grille.tab[PropNeed.deselectedcolorSolution[i], PropNeed.deselectedcolorSolution[i + 1]].GetComponent<Renderer>().material.color = Color.white;
                


                }
            }
        }


        PropNeed.deselectedcolorEnnemi.Clear();
        PropNeed.deselectedcolorPlayer.Clear();
        PropNeed.deselectedcolorSolution.Clear();
        PropNeed.deselectedcolorPionPrincipale.Clear();

    }




    public int check_Vertical(int antx, int anty)
    {
        int countTotal = 0;

        int i = antx;
        int j = anty;
        // on monte

        if (j != 4)
        {
            j += 1;
            int count = 0;
            while (j < 4 && j > 0)
            {

                if (PropNeed.caseoccupe[i, j] == true)
                {
                    count++;
                    j -= 1;
                    if (!(i == antx && j == anty))
                    {
                        grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                        grille.tab[i, j].selectSolution_ = "S";
                        PropNeed.deselectedcolorSolution.Add(i);
                        PropNeed.deselectedcolorSolution.Add(j);
                        countTotal++;
                        break;

                    }
                    else { break; }

                }
                else
                {
                    j += 1;
                    continue;
                }

            }
            //count permet de savoir s'il n'y a pas de pion sur la ligne
            if (count == 0)
            {
                if (!(i == antx && j == anty))
                {
                    if (PropNeed.caseoccupe[i, j] == true)
                    {

                        j -= 1;
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;
                        }
                    }
                    else
                    {
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;
                        }
                    }
                }
            }
        }

        //on descend
        i = antx;
        j = anty;


        if (j != 0)
        {
            j -= 1;

            int count2 = 0;
            while (j < 4 && j > 0)
            {

                if (PropNeed.caseoccupe[i, j] == true)
                {
                    count2++;
                    j += 1;
                    if (!(i == antx && j == anty))
                    {
                        grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                        grille.tab[i, j].selectSolution_ = "S";
                        PropNeed.deselectedcolorSolution.Add(i);
                        PropNeed.deselectedcolorSolution.Add(j);
                        countTotal++;
                        break;

                    }
                    else { break; }


                }
                else
                {
                    j -= 1;
                    continue;
                }
            }

            //count permet de savoir s'il n'y a pas de pion sur la ligne
            if (count2 == 0)
            {
                if (!(i == antx && j == anty))
                {
                    if (PropNeed.caseoccupe[i, j] == true)
                    {

                        j += 1;
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;
                        }
                    }
                    else
                    {
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;
                        }
                    }

                }
            }


        }
        return countTotal;
    }

    public int check_Horizontal(int antx, int anty)
    {

        int countTotal = 0;

        int i = antx;
        int j = anty;

        if (i != 4)
        {
            //à droite  
            int count = 0;
            i += 1;
            while (i < 4 && i > 0)
            {

                if (PropNeed.caseoccupe[i, j] == true)
                {
                    count++;
                    i -= 1;
                    if (!(i == antx && j == anty))
                    {
                        grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                        grille.tab[i, j].selectSolution_ = "S";
                        PropNeed.deselectedcolorSolution.Add(i);
                        PropNeed.deselectedcolorSolution.Add(j);
                        countTotal++;
                        break;

                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    i += 1;
                    continue;
                }

            }
            //count permet de savoir s'il n'y a pas de pion sur la ligne
            if (count == 0)
            {
                if (!(i == antx && j == anty))
                {

                    if (PropNeed.caseoccupe[i, j] == true)
                    {

                        i -= 1;
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;
                        }
                    }
                    else
                    {
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;



                        }
                    }
                }
            }
        }




        //à gauche
        i = antx;
        j = anty;

        if (i != 0)
        {

            i -= 1;
            int count2 = 0;

            while (i < 4 && i > 0)
            {

                if (PropNeed.caseoccupe[i, j] == true)
                {
                    count2++;
                    i += 1;
                    if (!(i == antx && j == anty))
                    {
                        grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                        grille.tab[i, j].selectSolution_ = "S";
                        PropNeed.deselectedcolorSolution.Add(i);
                        PropNeed.deselectedcolorSolution.Add(j);
                        countTotal++;
                        break;

                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    i -= 1;
                    continue;
                }

            }
            //count permet de savoir s'il n'y a pas de pion sur la ligne
            if (count2 == 0)
            {
                if (!(i == antx && j == anty))
                {
                    if (PropNeed.caseoccupe[i, j] == true)
                    {
                        i += 1;
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;
                        }
                    }
                    else
                    {
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;
                        }
                    }
                }
            }


        }
        return countTotal;
    }


    public int check_diagonal(int antx, int anty)
    {
        int countTotal = 0;
        int i = antx; int j = anty;

        if (j != 4)
        {
            if (i != 4)
            {
                //on monte vers la droite 
                int count = 0;
                i += 1; j += 1;
                while ((i < 4 && i > 0) && (j < 4 && j > 0))
                {

                    if (PropNeed.caseoccupe[i, j] == true)
                    {
                        count++;
                        i -= 1; j -= 1;
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;
                            break;

                        }
                        else { break; }

                    }
                    else
                    {
                        i += 1; j += 1;
                        continue;
                    }
                }
                if (count == 0)
                {
                    if (!(i == antx && j == anty))
                    {

                        if (PropNeed.caseoccupe[i, j] == true)
                        {
                            i -= 1; j -= 1;
                            if (!(i == antx && j == anty))
                            {
                                grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                                grille.tab[i, j].selectSolution_ = "S";
                                PropNeed.deselectedcolorSolution.Add(i);
                                PropNeed.deselectedcolorSolution.Add(j);
                                countTotal++;
                            }
                        }
                        else
                        {
                            if (!(i == antx && j == anty))
                            {
                                grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                                grille.tab[i, j].selectSolution_ = "S";
                                PropNeed.deselectedcolorSolution.Add(i);
                                PropNeed.deselectedcolorSolution.Add(j);
                                countTotal++;

                            }
                        }
                    }
                }

            }
        }



        i = antx;
        j = anty;
        if (j != 0)
        {
            if (i != 4)
            {
                //on descend vers la droite 
                i += 1; j -= 1;
                int count2 = 0;
                while ((i > 0 && i < 4) && (j > 0 && j < 4))
                {

                    if (PropNeed.caseoccupe[i, j] == true)
                    {
                        count2++;
                        i -= 1; j += 1;
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;
                            break;

                        }

                    }
                    else
                    {
                        i += 1; j -= 1;
                        continue;
                    }
                }
                if (count2 == 0)
                {
                    if (!(i == antx && j == anty))
                    {
                        if (PropNeed.caseoccupe[i, j] == true)
                        {
                            i -= 1; j += 1;
                            if (!(i == antx && j == anty))
                            {
                                grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                                grille.tab[i, j].selectSolution_ = "S";
                                PropNeed.deselectedcolorSolution.Add(i);
                                PropNeed.deselectedcolorSolution.Add(j);
                                countTotal++;
                            }
                        }
                        else
                        {
                            if (!(i == antx && j == anty))
                            {
                                grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                                grille.tab[i, j].selectSolution_ = "S";
                                PropNeed.deselectedcolorSolution.Add(i);
                                PropNeed.deselectedcolorSolution.Add(j);
                                countTotal++;
                            }
                        }
                    }
                }
            }
        }



        i = antx;
        j = anty;
        if (j != 4)
        {
            if (i != 0)
            {
                //on monte vers la gauche
                int count3 = 0;
                i -= 1; j += 1;
                while ((i > 0 && i < 4) && (j < 4 && j > 0))
                {

                    if (PropNeed.caseoccupe[i, j] == true)
                    {
                        count3++;
                        i += 1; j -= 1;
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;
                            break;

                        }

                    }
                    else
                    {
                        i -= 1; j += 1;
                        continue;
                    }
                }
                if (count3 == 0)
                {
                    if (!(i == antx && j == anty))
                    {
                        if (PropNeed.caseoccupe[i, j] == true)
                        {
                            i += 1; j -= 1;
                            if (!(i == antx && j == anty))
                            {
                                grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                                grille.tab[i, j].selectSolution_ = "S";
                                PropNeed.deselectedcolorSolution.Add(i);
                                PropNeed.deselectedcolorSolution.Add(j);
                                countTotal++;
                            }
                        }
                        else
                        {
                            if (!(i == antx && j == anty))
                            {
                                grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                                grille.tab[i, j].selectSolution_ = "S";
                                PropNeed.deselectedcolorSolution.Add(i);
                                PropNeed.deselectedcolorSolution.Add(j);
                                countTotal++;
                            }
                        }
                    }
                }
            }

        }




        i = antx;
        j = anty;
        if (j != 0)
        {
            if (i != 0)
            {

                //on descend vers la gauche 
                i -= 1; j -= 1;
                int count4 = 0;
                while ((i > 0 && i < 4) && (j > 0 && j < 4))
                {

                    if (PropNeed.caseoccupe[i, j] == true)
                    {
                        count4++;
                        i += 1; j += 1;
                        if (!(i == antx && j == anty))
                        {
                            grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                            grille.tab[i, j].selectSolution_ = "S";
                            PropNeed.deselectedcolorSolution.Add(i);
                            PropNeed.deselectedcolorSolution.Add(j);
                            countTotal++;
                            break;

                        }

                    }
                    else
                    {
                        i -= 1; j -= 1;
                        continue;
                    }
                }
                if (count4 == 0)
                {
                    if (!(i == antx && j == anty))
                    {
                        if (PropNeed.caseoccupe[i, j] == true)
                        {
                            i += 1; j += 1;
                            if (!(i == antx && j == anty))
                            {
                                grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                                grille.tab[i, j].selectSolution_ = "S";
                                PropNeed.deselectedcolorSolution.Add(i);
                                PropNeed.deselectedcolorSolution.Add(j);
                                countTotal++;
                            }
                        }
                        else
                        {
                            if (!(i == antx && j == anty))
                            {
                                grille.tab[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                                grille.tab[i, j].selectSolution_ = "S";
                                PropNeed.deselectedcolorSolution.Add(i);
                                PropNeed.deselectedcolorSolution.Add(j);
                                countTotal++;

                            }
                        }
                    }
                }

            }
        }
        return countTotal;
    }

    private void unselectedTags_()
    {
        for (int i = 0; i < 5; i++)
        {

            for (int j = 0; j < 5; j++)
            {
                grille.tab[i, j].selectSolution_ = "";
            }

        }
    }
    private void selectsolution(Pion box, int valueI, int valueJ, bool[,] solution)
    {


        //permet de montrer les solutions proposer au joueur sur lequel on a cliqué dessus

        if ((box.name == "Joueur" || box.name == "Ennemi" || box.name == "Ball"))

        {
            int check_H, check_V, check_D;
            Debug.Log(valueJ.ToString() + "," + valueJ.ToString());
            check_H = check_Horizontal(valueI, valueJ);
            check_V = check_Vertical(valueI, valueJ);
            check_D = check_diagonal(valueI, valueJ);


            //lorsque le pion ne peut plus se mouvoir  
            if (check_H == 0 && check_D == 0 && check_V == 0)
            {

                int functionHeurisk = State.Get_Calculfunction();
                if (functionHeurisk > 0)
                {

                    Debug.Log("============== Player a gagné ================");

                    Application.Quit();
                }
                else if (functionHeurisk < 0)
                {

                    Debug.Log("============== Ennemi a gagné ================");

                    Application.Quit();
                }
            }

        }


    }

    public void Onmousedown_function(Pion p)
    {
        unselectedTags_();

        string[] msg = p.TagPosition.Split(',');


        int valueI;
        int valueJ;
        // attempt to parse the value using the TryParse functionality of the integer type

        int.TryParse(msg[0], out valueI);
        int.TryParse(msg[1], out valueJ);

        // methode qui permet de changer le backcolor du joueur 
        deselectedPlayerColor();

        //permet de recuperer la valeur de chaque picture box  selectionner


        //stockvalue est une  liste qui stocke les valeur x et y du pion (permet donc de stocker la position du joueur du depart)
        // lorsqu'on clique sur un pion on veut l'identifier avec une couleur 



        if (PropNeed.caseoccupe[valueI, valueJ] == true)
        {
            PropNeed.Stockvalue.Clear();
            PropNeed.Stockvalue.Add(valueI);
            PropNeed.Stockvalue.Add(valueJ);
            //pour differencier les pions normaux et le pion qui detient la balle :
            //-si un pion a comme propriété AccessibleDescription == null cvd c'est un pion normal
            //-si un pion a comme propriété AccessibleDescription == "E" ou "J" cvd c'est un pion qui detient la balle
            if (p.name == "Joueur" && PropNeed.ballpassing == false && PropNeed.compteurdetours == 1)
            {
                p.GetComponent<Renderer>().material.color = Color.blue;


                PropNeed.deselectedcolorPlayer.Add(p);
            }
            else if (p.name == "Ball" && PropNeed.ballpassing == true && (PropNeed.compteurdetours == 0))
            {


                p.GetComponent<Renderer>().material.color = Color.grey;
                PropNeed.deselectedcolorPlayer.Add(p);
            }
            else if (p.name == "Ball" && PropNeed.compteurdetours == 2)
            {
                p.GetComponent<Renderer>().material.color = Color.cyan;
                PropNeed.deselectedcolorPlayer.Add(p);

            }
            else if (p.name == "Ennemi" && PropNeed.ballpassing == false && PropNeed.compteurdetours == 3)
            {

                p.GetComponent<Renderer>().material.color = Color.gray;
                //je stocke ce picture box pour mettre ensuite de le reutiliser pour en lenver les différentes couleurs
                PropNeed.deselectedcolorEnnemi.Add(p);
                //tour.GetComponent<Renderer>().material.color = Color.red;

            }
        }


        if (PropNeed.caseoccupe[valueI, valueJ] == false)
        {
            PropNeed.stocvalueEnd.Clear();
            PropNeed.stocvalueEnd.Add(valueI);
            PropNeed.stocvalueEnd.Add(valueJ);
        }

        //cette methode  permet de montrer les possibilités(solution en affichant des couleur) pour jouer 
        selectsolution(p, valueI, valueJ, PropNeed.caseoccupe);


    }



    public void select(Pion p)
    {
        Onmousedown_function(p);
    }
    
}







//******************board**************
public class Moov_Command : CommandPattern_move
{
    public void move(Square b)
    {
        Onmousedown_move(b);
    }

    public static void deselectedPlayerColor()
    {
        // to deselected backColor

        Pion previous_GameObject_player;
        Pion previous_GameObject_ennemi;
        GameObject antboxSolution;


        if (PropNeed.deselectedcolorPlayer.Count != 0)
        {
            previous_GameObject_player = (Pion)PropNeed.deselectedcolorPlayer[0];


            previous_GameObject_player.GetComponent<Renderer>().material.color = Color.black;

        }

        if (PropNeed.deselectedcolorEnnemi.Count != 0)
        {
            previous_GameObject_ennemi = (Pion)PropNeed.deselectedcolorEnnemi[0];
            previous_GameObject_ennemi.GetComponent<Renderer>().material.color = Color.black;


        }



        if (PropNeed.deselectedcolorSolution.Count != 0)
        {


            for (int i = 0; i < (PropNeed.deselectedcolorSolution.Count - 1); i++)
            {
                if (i % 2 == 0)
                {
                    grille.tab[PropNeed.deselectedcolorSolution[i], PropNeed.deselectedcolorSolution[i + 1]].GetComponent<Renderer>().material.color = Color.white;

                }
            }
        }


        PropNeed.deselectedcolorEnnemi.Clear();
        PropNeed.deselectedcolorPlayer.Clear();
        PropNeed.deselectedcolorSolution.Clear();
        PropNeed.deselectedcolorPionPrincipale.Clear();

    }

    public void Onmousedown_move(Square b)
    {
        string[] msg = b.TagPosition.Split(',');


        int valueI;
        int valueJ;


        // attempt to parse the value using the TryParse functionality of the integer type
        int.TryParse(msg[0], out valueI);
        int.TryParse(msg[1], out valueJ);
        //valueI = this.getX();
        //valueJ = this.getY();
        Debug.Log(valueI.ToString() + "," + valueJ.ToString());


        if (PropNeed.caseoccupe[valueI, valueJ] == false)
        {
            PropNeed.stocvalueEnd.Clear();
            PropNeed.stocvalueEnd.Add(valueI);
            PropNeed.stocvalueEnd.Add(valueJ);

            if (PropNeed.Stockvalue.Count == 2 && PropNeed.stocvalueEnd.Count == 2)
            {// on supprime les deux derniers element de la list
             //in verse les valeur parceque le premier element qu'on va ajouté sera lesecond elemnt lorsqu'on rajoute un nouveau element
             //  if (compteurdetours != 2 && compteurdetours != 5)

                moving(PropNeed.Stockvalue[0], PropNeed.Stockvalue[1], PropNeed.stocvalueEnd[0], PropNeed.stocvalueEnd[1]);

            }
        }
    }

    private void moving(int antx, int anty, int nextx, int nexty)
    {
        //pour se deplacer on supprimer les deux pictures et on remplace par les picturebox qui correspond
        //les pions oranges
        //la condition Tag = "C" 


        if (PropNeed.caseoccupe[nextx, nexty] == false && grille.tab[nextx, nexty].selectSolution_ == "S")
        {

            if (grille.tab2[antx, anty].name == "Ennemi" && PropNeed.compteurdetours == 3)
            {
                configmoov_P_E(antx, anty, nextx, nexty);
                //pour le nombre de tour
                PropNeed.compteurdetours++;



                //probleme
                for (int i = 0; i < State.allpositionennemi.Count; i++)
                {
                    if (State.allpositionennemi[i][0] == antx && State.allpositionennemi[i][1] == anty)
                    {
                        State.allpositionennemi[i][0] = nextx;
                        State.allpositionennemi[i][1] = nexty;
                    }

                }


            }
            else if (grille.tab2[antx, anty].name == "Joueur" && PropNeed.compteurdetours == 1)
            {

                configmoov_P_E(antx, anty, nextx, nexty);

                PropNeed.compteurdetours++;

                for (int i = 0; i < State.allpositionjoueurs.Count; i++)
                {
                    if (State.allpositionjoueurs[i][0] == antx && State.allpositionjoueurs[i][1] == anty)
                    {
                        State.allpositionjoueurs[i][0] = nextx;
                        State.allpositionjoueurs[i][1] = nexty;
                    }

                }


            }
            else if (grille.tab2[antx, anty].name == "Ball" && (PropNeed.compteurdetours == 0 || PropNeed.compteurdetours == 2))
            {


                configmoov_P_E(antx, anty, nextx, nexty);
                PropNeed.compteurdetours++;
                State.Stockvalueballball[0] = nextx;
                State.Stockvalueballball[1] = nexty;

            }



            if (PropNeed.compteurdetours == 4)
            {
                PropNeed.compteurdetours = 0;

            }
        }
    }
    public void configmoov_P_E(int antx, int anty, int nextx, int nexty)
    {
        //deselectionne les couleurs
        //Pion.deselectedPlayerColor();
        deselectedPlayerColor();
        //on modifie la position des joueurs ici
        Vector3 vector3 = new Vector3(nextx, nexty);
        grille.tab2[antx, anty].transform.position = vector3;


        PropNeed.caseoccupe[antx, anty] = false;
        PropNeed.caseoccupe[nextx, nexty] = true;

        Pion tmp = grille.tab2[antx, anty];

        grille.tab2[nextx, nexty] = tmp;
        grille.tab2[nextx, nexty].TagPosition = nextx.ToString() + "," + nexty.ToString();
        grille.tab2[antx, anty] = null;


        if (PropNeed.compteurdetours == 1)
        {
            grille.tab2[nextx, nexty].GetComponent<Renderer>().material.color = Color.black;
            grille.tab2[nextx, nexty].tagname = "Joueur";
            grille.tab2[nextx, nexty].name = "Joueur";



        }
        if (PropNeed.compteurdetours == 3)
        {
            grille.tab2[nextx, nexty].GetComponent<Renderer>().material.color = Color.red;
            grille.tab2[nextx, nexty].tagname = "Ennemi";
            grille.tab2[nextx, nexty].name = "Ennemi";
        }

        if (PropNeed.compteurdetours == 0 || PropNeed.compteurdetours == 2)
        {
            grille.tab2[nextx, nexty].GetComponent<Renderer>().material.color = Color.cyan;
            grille.tab2[nextx, nexty].tagname = "Ball";
            grille.tab2[nextx, nexty].name = "Ball";




            //observe qui gagne 
            if (PropNeed.compteurdetours == 0 && nexty == 0)
            {

                Debug.Log("============== Player a gagné ================");

                Application.Quit();

            }
            if (PropNeed.compteurdetours == 2 && nexty == 4)
            {

                Debug.Log("==============- Ennemi a gagné ================");

                Application.Quit();

            }

        }



        PropNeed.Stockvalue.Clear();
        PropNeed.stocvalueEnd.Clear();

        unselectedTags();
    }



    private void unselectedTags()
    {
        for (int i = 0; i < 5; i++)
        {

            for (int j = 0; j < 5; j++)
            {
                grille.tab[i, j].selectSolution_ = "";
            }

        }
    }

}
