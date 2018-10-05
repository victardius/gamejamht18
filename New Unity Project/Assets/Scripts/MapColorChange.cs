using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {


    private List<char> letters = new List<char>();
    private Color mapColor;
    private string hexColor;
    private int number = 6;
    public GameObject cube;
	// Use this for initialization
	void Start () {
        letters.Add('d');
        letters.Add('d');
        letters.Add('c');
        letters.Add('8');
        letters.Add('6');
        letters.Add('1');

        for(int i = 0; i < 6; i++)
        {
            int current = Random.Range(0, number);
            hexColor += letters[current];
            letters.RemoveAt(current);
            number--;
        }

        mapColor = HexToColor(hexColor);

        Renderer rend = cube.GetComponent <Renderer>();
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", mapColor);
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", mapColor);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }
}
