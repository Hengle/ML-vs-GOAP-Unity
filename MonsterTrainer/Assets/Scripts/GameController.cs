﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /*
    TODO LIST    
    - implement curriculum learning plan
    - learn how to use tensorflow learning graphs!
    - bug! goap agents slow down together with mlagents
    - allow mlAgents to move and rotate at the same time
    - combat training / activating goap-agents
    - get multibrain to work
    - calculate goap costs dynamically
    - bug: sometimes it resets twice after death
    - bug: when trying to move left+back the monster spins - this seems to be caused by friction with arenabase 
    ~ goap attack more persistently
    ~ goap AMonsterAgent MoveAgent() -> should check if preconditions are still true
    ~ include ml-agents in git?
    ~ Find all Entities in Initialization?
     */




    StartPositionGenerator startPosGenerator;
    MasterAreaController masterAreaControl;

    TeamController teamMLController;
    TeamController teamGOAPController;

    // Use this for initialization
    void Start()
    {
        AssignObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AssignObjects()
    {
        if (masterAreaControl == null || startPosGenerator == null || teamMLController == null || teamGOAPController == null)
        {
            masterAreaControl = FindObjectOfType<MasterAreaController>();
            startPosGenerator = FindObjectOfType<StartPositionGenerator>();

            GameObject teamMLControllerGameObject = GameObject.Find("TeamMLController");
            GameObject teamGOAPControllerGameObject = GameObject.Find("TeamGOAPController");
            teamMLController = teamMLControllerGameObject.GetComponent<TeamController>();
            teamGOAPController = teamGOAPControllerGameObject.GetComponent<TeamController>();
        }
    }

    public void initializeGame()
    {
        AssignObjects();
        startPosGenerator.AssignRandomStartPositionsForAllMonsters();
    }

    public void ResetGame()
    {
        startPosGenerator.AssignRandomStartPositionsForAllMonsters();
        masterAreaControl.ResetAllAreas();
        teamMLController.ResetAllMonsters();
        teamGOAPController.ResetAllMonsters();
    }
}
