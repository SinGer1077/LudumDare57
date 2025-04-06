using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private EventSystem eventSystem;

    [SerializeField]
    private GraphicRaycaster raycaster;

    [SerializeField]
    private InputManager InputMan;

    [SerializeField]
    private FruitManager fruitManager;

    [SerializeField]
    private TextMeshProUGUI Messages;

    private bool AntSummoned;
    private bool AntChosen;
    private bool AntMoving;
    private float numberOfFruits;

    //steps:
    //Click on spawn
    //Click on Ant
    //Click one on cell
    //Click two

    private void Start()
    {
        Messages.transform.parent.parent.gameObject.SetActive(true);
        Messages.text = "I am dying... Please, help me... I need food... We need summon workers to find it...Choose type of Ant-worker... Faster, my energy is slowly decreasing...";
        numberOfFruits = fruitManager.FruitsCountOnLvl;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(eventSystem)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerData, results);

            if (results.Count > 0)
            {
                if (results[0].gameObject.name == "Junior" || results[0].gameObject.name == "Sensor")
                {
                    if (!AntSummoned)
                    {
                        AntSummoned = true;
                        Messages.text = "Good...But summoing ants decrease my energy...Please, hurry, choose worker...";
                    }
                }
            }

        }

        if (!AntChosen && InputMan.CurrentChosenAnt != null)
        {
            AntChosen = true;
            Messages.text = "Now click on cell to build path, and then click ones more to approve it...";
        } 

        if (!AntMoving && InputMan.CurrentChosenAnt != null && InputMan.CurrentBlock != null)
        {
            AntMoving = true;
            Messages.text = "Good job...Now you need to find fruits...You can see sensor-area around worker...It will help you...";
        }

        if (numberOfFruits != fruitManager.FruitsCountOnLvl)
        {
            Messages.text = "You found a fruit! Thank you...Now I am feeling better...But we need them all to survive...";
        }
    }
}
