using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RandomizeMaterial : MonoBehaviour
{
    //This is where our materials get bundled under
    private MeshRenderer rend;


    //This is which material you're wanting to affect.
    //Materials are stored in an array (even if there's only one)
    //By default, it's set to 1 (for the material in the first slot)
    //But if there are multiple materials, you can change it to whichever material it needs to be.
    [SerializeField]
    [Tooltip("1, 2, 3")]
    private int matNum = 1;

    [SerializeField]
    [Tooltip("[MainTexture] _BaseMap(\"Albedo\", 2D) = \"white\" {}")]
    private string mapName = "_BaseMap";

    [SerializeField]
    [Tooltip("These are all the texture options.")]
    private Texture2D[] opts;

    // Note: We call this in awake to call it before Start. To make sure things don't blip.
    void Awake()
    {
        //this gets the renderer component
        rend = gameObject.GetComponent<MeshRenderer>();
        //This puts it all together.
        rend.materials[matNum - 1].SetTexture(mapName, opts[Random.Range(0, opts.Length)]);
    }


}
