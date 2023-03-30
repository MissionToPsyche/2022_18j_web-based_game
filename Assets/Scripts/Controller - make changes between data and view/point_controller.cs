using PlasticPipe.PlasticProtocol.Messages;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class point_controller
{
    private static point_controller pointC = new point_controller();
    private score game_score = new score();

    // Sequences of puzzle piece order
    // Will be selected based on which room player is located
    private sequence officeSeq = new sequence(new string[] { "Calendar", "OfficeSafe", "OfficeDesk", "Maze", "WhiteBoard", "Magnet", "TrashCan"});
    private sequence conferenceSeq = new sequence(new string[] {"Whiteboard","WiFi Router"});
    private sequence currentSeq;

    // Text GUI's to interact with the view and
    // set the points for the player to view
    private TextMeshProUGUI mainmission;
    private TextMeshProUGUI sidemission;
    private TextMeshProUGUI totalmission;
    private string initial_main;
    private string initial_side;
    private string initial_total;

    private point_controller() {
        currentSeq = officeSeq;
    }
    public static point_controller getInstance() { return pointC; }
    public void incScore(GameObject GO)
    {
        // increment the score of the game
        // based on which type of mission was interacted with by the player
        string go = "nothing";
        string parent = GO.transform.parent.name;
        

        MonoBehaviour[] mono = GO.GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour mn in mono)
        {
            if(mn.GetType().Name == "main_mission" || mn.GetType().Name == "side_mission")
            {
                go = mn.GetType().Name;
                break;
            }
        }
        
        // if the puzzle piece calling the incScore function was of the type "main_mission"
        // and the container's name equals the current puzzle piece sequence of the current room
        // increment the main mission score
        if(go == typeof(main_mission).Name && currentSeq.incrementSeq(parent)) {

            //-------------try to make another controller to determine how many points should be received by player-------------------------------------
            game_score.updateMain(100);
        }

        // if the puzzle piece calling the incScore function was of the type "side_mission"
        // increment the side mission score
        else if(go == typeof(side_mission).Name){

            //------------another controller for specific side missions--------------------------------------------------------------------------------
            game_score.updateSide(100);
        }

        // update the game score visible to the player
        updatePoints();
    }
    public void initializeTextMesh(TextMeshProUGUI[] missions, string[] initialtext)
    {
        // called when the scene initially loads
        // gets the textMeshProGuis from the UI
        // update the points based on the kept score
        mainmission = missions[0];
        sidemission = missions[1];
        totalmission = missions[2];
        initial_main = initialtext[0];
        initial_side = initialtext[1];
        initial_total = initialtext[2];
        updatePoints();
    }
    private void updatePoints()
    {
        // visually changes the points shown to the player
        mainmission.text = initial_main + " " + game_score.getMain();
        sidemission.text = initial_side + " " + game_score.getSide();
        totalmission.text = initial_total + " " + game_score.getTotal();

    }

    public void timerMission(int tpoints)
    {
        game_score.updateMain(tpoints);
    }


    public string currentSequence()
    {
        return currentSeq.getCurrentSeq();
    }

    public void changeToConSequence()
    {
        currentSeq = conferenceSeq;
    }

    public void changeToOffSequence()
    {
        currentSeq = officeSeq;
    }
}
