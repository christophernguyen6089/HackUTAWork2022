using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoFade : MonoBehaviour
{
    public float desiredAlpha=1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,1f);
    }

    // Update is called once per frame
    void Update()
    {
        desiredAlpha-=Time.deltaTime;
        ChangeAlpha(gameObject.GetComponent<Renderer>().material, desiredAlpha);
    }

    void ChangeAlpha(Material mat, float alphaVal){
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}
