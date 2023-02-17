using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score
{
    // saves the data of the game_score across all rooms
    // will be accessed using the point_controller that modifies the values of score
    private int main = 0;
    private int side = 0;
    private int total = 0;

    private void updateTotal(int incAmt)
    {
        total += incAmt;
    }
    public void updateSide(int incAmt)
    {
        side += incAmt;
        updateTotal(incAmt);
    }
    public void updateMain(int incAmt)
    {
        main += incAmt;
        updateTotal(incAmt);
    }
    public int getMain() { return main; }
    public int getSide() { return side; }
    public int getTotal() { return total; }

}
