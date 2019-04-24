using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    public Renderer renderer;
    public Material validMaterial;
    public Material invalidMaterial;

    void Start() {
        if (renderer) renderer.material = validMaterial;
        else throw new UnityException("No renderer assigned to IndicatorController");
    }

    public void SetValid() {
        renderer.material = validMaterial;
    }

    public void SetInvalid() {
        renderer.material = invalidMaterial;
    }
}
