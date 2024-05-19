using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
    private Material originalMaterial;
    public Material highlightMaterial;

    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }
    public void Highlight()
    {
        GetComponent<Renderer>().material = highlightMaterial;
    }
    public void RemoveHighlight()
    {
        GetComponent<Renderer>().material = originalMaterial;
    }
}
