using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grille : MonoBehaviour
{
    // Start is called before the first frame update

    //public  Board Squares1;
    public  Pion Circle;
    public Square Squares;
    


    
    private const int SIZE = 5;
    public static Square[,] tab = new Square[SIZE, SIZE];
    public static Pion[,] tab2 = new Pion[SIZE, SIZE];
   public static Renderer[,] gridGame = new Renderer[SIZE, SIZE];
   
    

    void Start()
    {



        for (int i = 0; i < SIZE; i++)
        {

            for (int j = 0; j < SIZE; j++)
            {

                PropNeed.caseoccupe[i, j] = false;
            }
        }




         for (int i = 0; i < SIZE; i++)
        {
            //le i est la ligne et le j en colonne
            for (int j = 0; j < SIZE; j++)
            {

                Vector2 position = new Vector2(i, j);
                Square tmp = Instantiate<Square>(Squares, position, Quaternion.identity);
               // tmp.setBoard(this);
                PropNeed.caseoccupe[i, j] = false;
               

                tmp.TagPosition = i.ToString() + "," + j.ToString();
                tmp.name = "Square";
                tmp.tagname = "Square";
                tab[i, j] = tmp;

                gridGame[i, j] = tmp.GetComponent<Renderer>();
                //gridSquare[i, j] = tmp;
                //tmp.tagname = "Square";
                



                if (j == 0)
                {

                    Vector2 positionCircle = new Vector2(i, j);
                    PropNeed.caseoccupe[i, j] = true;

                    Pion tmp2 = Instantiate<Pion>(Circle, positionCircle, Quaternion.identity);

                    tmp2.GetComponent<Renderer>().material.color = Color.black;
                    tmp2.TagPosition = i.ToString() + "," + j.ToString();
                    tmp2.name = "Joueur";
                    tmp2.tagname = "Joueur";
                    tab2[i, j] = tmp2;
                    gridGame[i, j] = tmp2.GetComponent<Renderer>();
                    //   tmp2.setBoard(this);
                    //tmp2.position(i, j);
                    //tmp2.tagname = "Joueur";
                    //tab[i, j] = null;
                    // gridGame[i, j] = tmp2;



                    //lié au stockage des positions 
                    List<int> positions = new List<int>();
                    positions.Add(i);
                    positions.Add(j);
                    State.allpositionjoueurs.Add(positions);
                    //tmp2.setBoard(this);
                    //[1,0]-[2,0]-[3,0]-[4,0]
                }

                if (j == (SIZE - 1))
                {

                    Vector2 positionCircle = new Vector2(i, j);

                    Pion tmp2 = Instantiate<Pion>(Circle, positionCircle, Quaternion.identity);

                    tmp2.GetComponent<Renderer>().material.color = Color.red;
                  
                    tmp2.name = "Ennemi";
                   
                    tmp2.TagPosition = i.ToString() + "," + j.ToString();
                    tab2[i, j] = tmp2;
                    tmp2.tagname = "Ennemi";
                    gridGame[i, j] = tmp2.GetComponent<Renderer>();
                    //tmp2.position(i, j);
                    // gridPion[i, j] = tmp2;
                    // tmp2.tagname = "Ennemi";
                    //tab[i, j] = null;
                    // gridGame[i, j] = tmp2;


                    PropNeed.caseoccupe[i, j] = true;

                    //lié au min max
                    List<int> positions = new List<int>();
                    positions.Add(i);
                    positions.Add(j);
                    State.allpositionennemi.Add(positions);
                    //tmp2.setBoard(this);
                    //[1,4]-[2,4]-[3,4]-[4,4]  
                }





            }
        }

        int n = 2;
        //ball 
        Vector2 position3 = new Vector2(n, n);
        Pion tmp3 = Instantiate<Pion>(Circle, position3, Quaternion.identity);

        tmp3.GetComponent<Renderer>().material.color = Color.cyan;
        //tmp3.tagname = "Ball";

        tmp3.name = "Ball";
        tmp3.TagPosition = n.ToString() + "," + n.ToString();
        // tmp3.position(n, n);
        PropNeed.caseoccupe[n, n] = true;
        tab2[n, n] = tmp3;
        gridGame[n, n] = tmp3.GetComponent<Renderer>();
        // tab[n, n] = null;
        // gridGame[n, n] = tmp3;
        //gridPion[n, n] = tmp3;
        //gridSquare[n, n] = null;


        //lié au min -max 
        State.Stockvalueballball.Add(n);
        State.Stockvalueballball.Add(n);
        // tmp3.setBoard(this);

     
       Debug.Log(gridGame.ToString());
       Debug.Log(tab.ToString());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    
}
