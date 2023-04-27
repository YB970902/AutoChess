using BehaviourTree;
using UnityEngine;
using UnityEngine.Serialization;

public class TestPlayer : MonoBehaviour
{
    [FormerlySerializedAs("controller")] [SerializeField] private BehaviourTreeController treeController;

    private void Start()
    {
        treeController.Initialize(null);
    }

    private void FixedUpdate()
    {
        treeController.Evaluation();
    }
}
