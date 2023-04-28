using PlasticPipe.PlasticProtocol.Messages;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class point_controller
{
    private static point_controller pointC = new point_controller();
    private score game_score = new score();
    private int sSFails = 0;

    // Sequences of puzzle piece order
    // Will be selected based on which room player is located
    private sequence officeSeq = new sequence(new string[] { "Calendar_Main", "DeskKey_Main", "DeskDrawer_Main", "WhiteBoard_Main", "Magnet_Main", "TrashBin_Main", "Switch_Main" });

    private string[] officeHints = new string[] {
        "Look at WHEN the Psyche Mission was accepted by NASA!",
        "Check out the safe to see what's inside! You've encountered the 4 digit code already!",
        "Looks like you found a desk key! Check around the desk to find what it unlocks! (Make sure you have it selected in your inventory!)",
        "Hmmm... the image from the maze craze game looked like it was a spacecraft. Is there another spacecraft in the room?",
        "The magnet on the board looks useful for later.",
        "Maybe something got thrown away?",
        "The note may be onto something!",
        "Check out the planets to explore space!"
    };
    private sequence conferenceSeq = new sequence(new string[] { "Whiteboard", "ProjectorBody", "WiFi Router", "CT Hitbox", "Box of Markers", "CoffeeMachine", "FM Hitbox", "Television", "Clock"});

    private string[] conferenceHints = new string[] {
        "Maybe the whiteboard has some important information on it?",
        "Projector",
        "Need more information? Use the internet!",
        "Where might you enter a password?",
        "Placeholder (markers)",
        "All this thinking may have you tired, need a refresher?",
        "That seems like an important number, try to type it in somewhere.",
        "Take a break and watch some cartoons",
        "Time to clock out!"
    };
    private sequence currentSeq;

    // Text GUI's to interact with the view and
    // set the points for the player to view
    private TextMeshProUGUI mainmission;
    private TextMeshProUGUI sidemission;
    private TextMeshProUGUI totalmission;
    private string initial_main;
    private string initial_side;
    private string initial_total;

    private int spaceExplorerScore = 0;

    private point_controller() {
        currentSeq = officeSeq;
    }
    public static point_controller getInstance() { return pointC; }
    public void incScore(GameObject GO)
    {
        // increment the score of the game
        // based on which type of mission was interacted with by the player
        string go = "nothing";
        string obj = GO.name;
        

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
        if(go == typeof(main_mission).Name && currentSeq.incrementSeq(obj)) {

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
    public string hintTxt()
    {
        if(currentSeq == conferenceSeq)
        {
            return conferenceHints[currentSeq.getPos()];
        }
        else
        {
            return officeHints[currentSeq.getPos()];
        }
    }

    public void SpaceExplorerIncScore(int score)
    {
        // first time playing the mini game and winning
        if(spaceExplorerScore == 0)
        {
            spaceExplorerScore= score;
            game_score.updateMain(score);
        }

        // has played previously, but scored better on the current run through
        else
        {
            if(score > spaceExplorerScore)
            {
                // the previous score gets subtracted from the current main score
                // the new score is now saved
                // the new score is now added to the main score
                game_score.updateMain(0 - spaceExplorerScore);
                spaceExplorerScore= score;
                game_score.updateMain(score);
            }
        }
    }

    public void SSFailed()
    {
        sSFails += 1;
    }

    public int getSSFails()
    {
        return sSFails;
    }
}
