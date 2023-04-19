using UnityEngine;

namespace BehaviourTree
{
    public class WalkingNode : BehaviourTree.ExecuteNode
    {
        [SerializeField] int maxTurn = 100;
        private int curTurn = 0;
        
        public override void Close()
        {
            curTurn = 0;
        }

        protected override void OnEnter()
        {
            curTurn = 0;
            Debug.Log("WalkingNode.OnEnter");
        }

        protected override Define.BehaviourTree.Result Execute()
        {
            var result = Define.BehaviourTree.Result.Running;
            ++curTurn;
            if (curTurn >= maxTurn)
            {
                Debug.Log("WalkingNodeEnd");
                result = Define.BehaviourTree.Result.Success;
            }

            return result;
        }
    }
}