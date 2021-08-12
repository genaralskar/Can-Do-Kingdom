using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmQuestPlot : MonoBehaviour
{
    private bool watered = false;
    [SerializeField] private GameObject interactor;
    [SerializeField] private GameObject wateredGO;
    [SerializeField] private Color wateredColor;

    public void WaterPlot()
    {
        interactor.transform.position = Vector3.down * 100;
        wateredGO.SetActive(true);
        UpdateVertexColors();
        watered = true;
    }

    private void UpdateVertexColors()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        // create new colors array where the colors will be created.
        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = wateredColor;

        // assign the array of colors to the Mesh.
        mesh.colors = colors;
    }
}
