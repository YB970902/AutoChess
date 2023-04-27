using Unity.VisualScripting;
using UnityEngine;

namespace BehaviourTree
{
    /// <summary>
    /// 조건식의 결과에 따라 Yes or No 노드를 평가하는 노드 
    /// </summary>
    public class IfNode : NodeBase
    {
        [SerializeField] private Define.BehaviourTree.IfType type = Define.BehaviourTree.IfType.None;

        /// <summary> 평가의 결과가 true인경우 호출될 노드 </summary>
        [SerializeField] private NodeBase yesNode = null;
        /// <summary> 평가의 결과가 false인경우 호출될 노드 </summary>
        [SerializeField] private NodeBase noNode = null;
        
        /// <summary> 현재 평가중인 노드 </summary>
        private NodeBase curEvaluateNode = null;
        
        public override void Evaluation()
        {
            bool result = GetConditionResult();
            
            if (ReferenceEquals(curEvaluateNode, null))
            {
                // curEvaluateNode가 null이면 Evaluate함수의 첫 호출이여서 할당되지 않은것이니, 할당해준다.
                curEvaluateNode = result ? yesNode : noNode;
            }
            else
            {
                // 결과가 이전 결과와 다르다면 실행중이던 노드를 중지시키고 새 노드를 할당한다.
                var resultNode = result ? yesNode : noNode;
                if (resultNode != curEvaluateNode)
                {
                    curEvaluateNode.Close();
                    curEvaluateNode = resultNode;
                }
            }

            curEvaluateNode.Evaluation();
        }

        public override void OnChildEvaluated(Define.BehaviourTree.Result _result) { }

        public override void Close()
        {
            curEvaluateNode.Close();
            curEvaluateNode = null;
        }

        /// <summary>
        /// type에 맞는 조건식을 계산한 후에 반환하는 함수.
        /// TODO : 이걸 여기에서 할지 BehaviourTreeController에서 할지 고민을 좀 해야 할것 같음.
        /// </summary>
        private bool GetConditionResult()
        {
            switch (type)
            {
                case Define.BehaviourTree.IfType.None:
                    return false;
                case Define.BehaviourTree.IfType.CanUseUltSkill:
                    return false;
                case Define.BehaviourTree.IfType.IsTargetInAttackRange:
                    return false;
                case Define.BehaviourTree.IfType.IsTargetInUltSkillRange:
                    return true;
                default:
                    return false;
            }
        }
    }
}