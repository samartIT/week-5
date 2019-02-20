using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class TerrainGenerator1 : MonoBehaviour
{
    Mesh terrain;
    Vector3[] vertices;
        int[] facets;

    public int nx = 50;
    public int nz = 50;

    void Start()
    {
        terrain = new Mesh();
        GetComponent<MeshFilter>().mesh = terrain;

        GenerateTerrain();
    }

    void Update()
    {
        UpdateTerrain();
    }

    void GenerateTerrain()
    {
        vertices = new Vector3[(nx + 1) * (nz + 1)];
        int i = 0;
        for (int indZ = 0; indZ <= nz; indZ++) {
            for (int indX = 0; indX <= nx; indX++) {
                float y = Mathf.PerlinNoise(indX * .4f, indZ * .7f) * 2f ;
                vertices[i] = new Vector3(indX, y, indZ);
                i++;
            }
        }

        facets = new int[nx * nz * 6];
        int vert = 0;
        int face = 0;

        for (int indZ = 0; indZ < nz; indZ++)
        {
            for (int indX = 0; indX < nx; indX++)
            {
                facets[face + 0] = vert + 0;
                facets[face + 1] = vert + nx + 1;
                facets[face + 2] = vert + 1;
                facets[face + 3] = vert + 1;
                facets[face + 4] = vert + nx + 1;
                facets[face + 5] = vert + nx + 2;

                vert++;
                face += 6;                
            }
            vert++;
        }
    }

    void UpdateTerrain() {
        terrain.Clear();

        terrain.vertices = vertices;
        terrain.triangles = facets;

        terrain.RecalculateNormals();
    }    
}
