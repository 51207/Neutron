using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropNeed 
{
    // Start is called before the first frame update
    public static bool[,] caseoccupe= new bool[5,5];
                     


    public static bool ballpassing = true;
    //ces deux booleen permettent de faire une passe seulement lorque q'un des joueur joue
    public bool ballpassingOneforennemi = false;
    public bool ballpassingOneforplayer = true;

    //permet de savoir s'il existe un pion ennemi ou joueur dans le mouvement diagonale
    //si c'est le cas, le mouvement diagonal est interdit
    public bool blocagepionennemi = false;
    public bool blocagepion_ennemi_joueur_VH = false;

    //le compteur permet de gerer le tour de jeu des joueurs . Chaque joueur peut effectuer 2 tours ensuite faire une passe .

    public static int compteurdetours = 0;



    public static int compteurde2deplacementparjoueur = 0;
    public  static int compteurde2deplacementparennemi = 0;


    public static List<int> Stockvalue = new List<int>();
    public static List<int> stocvalueEnd = new List<int>();
    public static List<Pion> deselectedcolorPlayer = new List<Pion>();

    public static List<Pion> deselectedcolorEnnemi = new List<Pion>();
    //List<PictureBox> deselectedcolorSolution = new List<PictureBox>();
    public static List<int> deselectedcolorSolution = new List<int>();
    public static List<int> deselectedcolorPionPrincipale = new List<int>();



    public static List<int> deletetags = new List<int>();


 



    //**** pour le min max : ****




    private bool makepasse_IA = false;
    private int nbredetours_IA = 0;
    //stocke chaque etat etat avec son score qui lui correspond lors du calucl in-max
    //Dictionary<State, int> all_get_score = new Dictionary<State, int>();
    // public int scoretest = 0;

    //permet de stocker les 4 mouvement qu'on veut reutiliser au min -max
    private List<int> stock_four_mvt = new List<int>();


}
