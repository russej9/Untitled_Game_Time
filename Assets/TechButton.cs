using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TechButton : MonoBehaviour
{

    private GameObject[] m_techList; //list of all techs, not sure if I will eventually need, may get rid of it
    public GameObject[] m_prereqTech; //list of prerequisit tech, can adjust how many prereq 
    public Color m_colorLine = Color.white;
    public float m_lineWidth = 1f;
    private LineRenderer m_lineRend;
    public int m_lineSortOrd;
    public Material m_lineMat;
    public bool m_researched = false;
    private UnityEngine.UI.Button m_researchButton;
    private Color m_buttonColor;
    public UnityAction a_research;

    // Start is called before the first frame update
    void Start()
    {
        m_techList = GameObject.FindGameObjectsWithTag("Tech");
        m_lineRend = gameObject.AddComponent<LineRenderer>();
        for (int i = 0; i < m_prereqTech.Length; i++) //this doesnt work, cant make appear properly on the UI canvas
        {
            m_lineRend.SetPosition(0, transform.position);
            m_lineRend.SetPosition(1, m_prereqTech[i].transform.position);
            m_lineRend.startWidth = m_lineWidth;
            m_lineRend.endWidth = m_lineWidth;
            m_lineRend.startColor = m_colorLine;
            m_lineRend.endColor = m_colorLine;
            m_lineRend.sharedMaterial = m_lineMat;
        }
        //event stuff
        a_research += DoResearch; //the only function of the listener added to the event
        m_researchButton = GetComponent<UnityEngine.UI.Button>();
        m_researchButton.onClick.AddListener(a_research); //adds listener for button press, much better way of doing this UI stuff
        m_buttonColor = m_researchButton.image.color; //original button color

        EventTrigger.Entry buttonHover = new EventTrigger.Entry(); //this allows detection of hovering over button, Use as reference when creating events with triggers
        buttonHover.eventID = EventTriggerType.PointerEnter;
        buttonHover.callback.AddListener((eventData) => { ShowPreReq(); });
        EventTrigger.Entry buttonExit = new EventTrigger.Entry();
        buttonExit.eventID = EventTriggerType.PointerExit;
        buttonExit.callback.AddListener((eventData) => { StopShowPreReq(); });
        GameObject.Find(m_researchButton.name).AddComponent<EventTrigger>(); //adds the eventtrigger component to the button
        m_researchButton.GetComponent<EventTrigger>().triggers.Add(buttonHover); //adds the event for showing prereq to the button
        m_researchButton.GetComponent<EventTrigger>().triggers.Add(buttonExit); //adds the event for stopping showing the prereq


    }



    public void DoResearch()
    {
        bool preReqComplete = true;
        for (int i = 0; i < m_prereqTech.Length; i++)
        {
            if(!(GameObject.Find(m_prereqTech[i].name).GetComponent<TechButton>().m_researched)) //checks if all prereq have been m_researched
            {
                preReqComplete = false;
            }
        }
        if(preReqComplete)
        {
            //put whatever unlocks with the tech here and other factors
            GetComponent<UnityEngine.UI.Image>().color = Color.gray; //changes the color of the button
            m_researched = true; //makes it researched, need or infinite looping will occur
            m_researchButton.onClick.RemoveAllListeners(); //gets rid of what the button does
            
        }
        else //queues all incomplete prereq a_research
        {
            for (int i = 0; i < m_prereqTech.Length; i++)
            {
                if (!(GameObject.Find(m_prereqTech[i].name).GetComponent<TechButton>().m_researched))
                {
                    GameObject.Find(m_prereqTech[i].name).GetComponent<TechButton>().a_research();
                }
            }
            DoResearch(); //tells it to do the research again
        }
    }

    void ShowPreReq()
    {
        for (int i = 0; i < m_prereqTech.Length; i++)
        {
            m_prereqTech[i].GetComponent<UnityEngine.UI.Image>().color = Color.blue;
        }
    }
    void StopShowPreReq()
    {
        for (int i = 0; i < m_prereqTech.Length; i++)
        {
            m_prereqTech[i].GetComponent<UnityEngine.UI.Image>().color = m_buttonColor;
        }
    }

}
