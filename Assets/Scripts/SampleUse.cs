using SaG.Dependencies;
using UnityEngine;

public class SampleUse : MonoBehaviour
{
    [SerializeField]
    private Dependency_Animator _animator = default;

    private Animator Animator => _animator.Resolve(this);
    
    void Start()
    {
        Animator.speed = 1;
    }
}
