using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pion : MonoBehaviour
{

   


    public string TagPosition;
    public string tagname;
    public string selectSolution_;
    // public  Board  board; 
    // Start is called before the first frame update


   /* grille grille;
    public void setBoard(grille grille)
    {
        this.grille = grille;

    }*/
 

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
     }


    private CommandPattern_select CommandPatternSelect;
    private void Awake()
    {
        CommandPatternSelect = new movement_SelectCommand();
    }


    /*
      private void OnMouseDown()
    {

        int y = (int)this.GetComponent<Renderer>().transform.position.y;
        int x = (int)this.GetComponent<Renderer>().transform.position.x;
        board2.Onclick(x, y);
    }
     */

     private void OnMouseDown()
      {

        //   Onmousedown_function(this);
        Debug.Log(grille.gridGame.ToString());
        CommandPatternSelect.select(this);


       
      }
   /*  void OnMouseDown()
    {

     //   try
      //  {
            int y = (int)this.transform.position.y;
            int x = (int)this.transform.position.x;

            this.grille.Onclick(x, y);
       // }
      //  catch (NullReferenceException e) { }
    }*/

    /*private void moving(int antx, int anty, int nextx, int nexty)
    {
       

        if (PropNeed.caseoccupe[nextx, nexty] == false)
        {
            


            if (grille.tab2[antx, anty].name == "Ennemi" && PropNeed.compteurdetours == 3)
            {

              
                Destroy(grille.tab2[antx, anty].gameObject);


                Vector2 positionCircle = new Vector2(nextx, nexty);
                Pion tmp2 = Instantiate<Pion>(this, positionCircle, Quaternion.identity);
                tmp2.GetComponent<Renderer>().material.color = Color.red;
                tmp2.TagPosition = nextx.ToString() + "," + nexty.ToString();
                tmp2.tagname = "Ennemi";
                grille.tab2[nextx, nexty] = tmp2;

                PropNeed.caseoccupe[antx, anty] = false;
                PropNeed.caseoccupe[nextx, nexty] = true;





                //pour le nombre de tour
                PropNeed.compteurdetours++;



                //allpositionennemi player state
                for (int i = 0; i < State.allpositionennemi.Count; i++)
                {
                    if (State.allpositionennemi[i][0] == antx && State.allpositionennemi[i][1] == anty)
                    {
                        State.allpositionennemi[i][0] = nextx;
                        State.allpositionennemi[i][1] = nexty;
                    }

                }


            }





            //on supprimer les deux pictures et on remplace par les picturebox qui correspond
            // less pions bleu
            else if (grille.tab2[antx, anty].name == "Joueur" && PropNeed.compteurdetours == 1)
            {
                
                Destroy(grille.tab2[antx, anty].gameObject);

                Vector2 positionCircle = new Vector2(nextx, nexty);
                Pion tmp2 = Instantiate<Pion>(this, positionCircle, Quaternion.identity);
                tmp2.GetComponent<Renderer>().material.color = Color.black;
                tmp2.TagPosition = nextx.ToString() + "," + nexty.ToString();
                tmp2.tagname = "Joueur";
                grille.tab2[nextx, nexty] = tmp2;

                PropNeed.caseoccupe[antx, anty] = false;
                PropNeed.caseoccupe[nextx, nexty] = true;


                //allposition player state
                for (int i = 0; i < State.allpositionjoueurs.Count; i++)
                {
                    if (State.allpositionjoueurs[i][0] == antx && State.allpositionjoueurs[i][1] == anty)
                    {
                        State.allpositionjoueurs[i][0] = nextx;
                        State.allpositionjoueurs[i][1] = nexty;
                    }

                }

                PropNeed.compteurdetours++;


            }
            else if (grille.tab2[antx, anty].name == "Ball" && (PropNeed.compteurdetours == 0 || PropNeed.compteurdetours == 2))
            {
               
                Destroy(grille.tab2[antx, anty].gameObject);

                Vector2 positionCircle = new Vector2(nextx, nexty);
                Pion tmp2 = Instantiate<Pion>(this, positionCircle, Quaternion.identity);
                tmp2.GetComponent<Renderer>().material.color = Color.green;
                tmp2.TagPosition = nextx.ToString() + "," + nexty.ToString();
                tmp2.tagname = "Ball";
                grille.tab2[nextx, nexty] = tmp2;

                PropNeed.caseoccupe[antx, anty] = false;
                PropNeed.caseoccupe[nextx, nexty] = true;
                //ball state
                State.Stockvalueballball[0] = nextx;
                State.Stockvalueballball[1] = nexty;

                PropNeed.compteurdetours++;

            }



            if (PropNeed.compteurdetours == 4)
            {
                PropNeed.compteurdetours = 0;
               
            }






        }
    }
    */









}
