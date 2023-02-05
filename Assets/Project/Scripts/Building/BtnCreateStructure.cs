using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCreateStructure : MonoBehaviour
{
    public void CreateGhostObject(SO_Structure structure)
    {
        Instantiate(structure.GhostPrefab);
    }
}
