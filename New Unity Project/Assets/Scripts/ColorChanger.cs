using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    private List<char> letters = new List<char>();
    private Color mapColor;
    private string hexColor;
    private int number = 6;
    public GameObject cube;
    // Use this for initialization
    void Start()
    {

        List<Renderer> gameObjChildren = new List<Renderer>();

        Addletters();
        GetColor();

        mapColor = HexToColor(hexColor);
        ChangeChildrenColor();
        
        /* Renderer rend = cube.GetComponentInChildren<Renderer>(); 
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", mapColor);
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", mapColor); */
    }

    // Update is called once per frame
    void Update()
    {

    }

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }

    void Addletters()
    {
        letters.Add('d');
        letters.Add('d');
        letters.Add('c');
        letters.Add('8');
        letters.Add('6');
        letters.Add('1');
    }

    void GetColor()
    {
        for (int i = 0; i < 6; i++)
        {
            int current = Random.Range(0, number);
            hexColor += letters[current];
            letters.RemoveAt(current);
            number--;
        }
    }

    void ChangeChildrenColor()
    {
        foreach(Renderer child in cube.GetComponentsInChildren<Renderer>())
        {
            Renderer rend = child.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", mapColor);
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", mapColor);
        }
    }
}
