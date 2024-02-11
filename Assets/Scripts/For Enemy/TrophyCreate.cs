using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyCreate : MonoBehaviour
{
    [SerializeField] private GameObject runePref;
    [SerializeField] private Transform crPoint;

    void Create() 
    {
        GameObject rune = Instantiate(runePref, crPoint.position, Quaternion.identity);
    }
}
