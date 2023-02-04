using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Structure", menuName = "SO/Structure")]
public class SO_Structure : ScriptableObject
{
    public GameObject GhostPrefab;

    public string StructureName;
    public int ReqResourceOne;

    public void StartPlacingStructure()
    {
        Instantiate(GhostPrefab);
    }
}
