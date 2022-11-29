using UnityEngine;
using System.Xml;
using System;

public class XMLManager : MonoBehaviour
{
    [SerializeField]private TextAsset playerStatFile;

    [HideInInspector] public float maxHP;
    [HideInInspector] public float initATK;
    [HideInInspector] public float initDEF;

    public static XMLManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        RoadPlayerXML();
    }

    void RoadPlayerXML()
    {
        TextAsset playerStatFile = (TextAsset)Resources.Load("playerStatus");

        XmlDocument playerXMLDoc = new XmlDocument();
        playerXMLDoc.LoadXml(playerStatFile.text);

        XmlNodeList playerNodeList = playerXMLDoc.GetElementsByTagName("row");

        foreach (XmlNode playerNode in playerNodeList)
        {                                                                                 

            foreach (XmlNode childNode in playerNode.ChildNodes)
            {
                if (childNode.Name == "maxHP")
                {
                    //< maxHP > 100 </ maxHP >
                    maxHP = Int16.Parse(childNode.InnerText);
                }

                if (childNode.Name == "initATK")
                {
                    //< initATK > 1 </ initATK >
                    initATK = Int16.Parse(childNode.InnerText);
                }

                if (childNode.Name == "initDEF")
                {
                    //< initDEF > 1 </ initDEF >
                    initDEF = Int16.Parse(childNode.InnerText);
                }

                print(childNode.Name + ":" + childNode.InnerText);
            }
        }
    }

    public void LoadPlayerParamsFromXML(PlayerStatus uParams)
    {
        uParams.maxHP = maxHP;
        uParams.initATK = initATK;
        uParams.initDEF = initDEF;
    }
}
