using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    // Board2 board2 ;
   // grille grille;

    public string TagPosition = ",";
    public string tagname = "Square";
    public string selectSolution_ = "";

  /*  public void setBoard(grille grille)
    {
        this.grille = grille;

    }*/

    // private void OnMouseDown()
    //{

    // int y = (int)this.GetComponent<SpriteRenderer>().transform.position.y;
    // int x = (int)this.GetComponent<SpriteRenderer>().transform.position.x;
    // grille.Onclick(x,y);
    //}

    private CommandPattern_move CommandPatternmove;
    private void Awake()
    {
        CommandPatternmove = new Moov_Command();
    }

    private void OnMouseDown()
    {
        Debug.Log(grille.gridGame.ToString());
        CommandPatternmove.move(this);
        // Onmousedown_move(this);


    }
}
