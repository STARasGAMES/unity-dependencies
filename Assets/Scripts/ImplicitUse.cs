using System.Collections;
using System.Collections.Generic;
using SaG.Dependencies;
using UnityEngine;

public class ImplicitUse : MonoBehaviour
{
    [SerializeField]
    private Dependency_Transform _dependency = default;

    
    // Start is called before the first frame update
    void Start()
    {
        ((Transform) _dependency).position = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
