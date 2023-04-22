using UnityEngine;

namespace BehaviourTree
{
    public enum IfType
    {
        None,
        CanUseUltSkill, // 궁극기 사용 가능 여부.
        IsTargetInUltSkillRange, // 적이 궁극기 범위 내에 있는지 여부.
        IsTargetInAttackRange, // 적이 공격 범위 내에 있는지 여부.
    }
    public class IfNode : ControlFlowNode
    {
        [SerializeField] private IfType type = IfType.None;
        public override void Evaluation()
        {
            switch (type)
            {
                case IfType.None:
                    break;
                case IfType.CanUseUltSkill:
                    break;
                default:
                    return;
            }

            if (this == null)
            {
                
            }
        }

        public override void OnChildEvaluated(Define.BehaviourTree.Result _result) { }

        public override void Close() { }
    }
}