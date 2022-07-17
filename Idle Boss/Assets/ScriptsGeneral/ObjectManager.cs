using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject devlog;
    public GameObject mining;
    public GameObject minions;
    public GameObject story;


    public static ObjectManager instance;
    private void Awake() => instance = this;

    public void tabselected(int val)
    {
        if (val == 0)
        {
            devlog.SetActive(true);
        }
        else
        {
            devlog.SetActive(false);
        }

        if (val == 1)
        {
            mining.SetActive(true);
        }
        else
        {
            mining.SetActive(false);  
        }
    }
}
