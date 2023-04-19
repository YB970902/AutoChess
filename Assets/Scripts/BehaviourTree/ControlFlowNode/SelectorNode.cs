namespace BehaviourTree
{
    /// <summary>
    /// 자식 노드 중 하나가 Success를 반환하면 즉시 부모 노드에게 반환하는 노드
    /// </summary>
    public class SelectorNode : ControlFlowNode
    {
        public override void Evaluation()
        {
            if (childIndex >= childCount)
            {
                Close();
                parent.OnChildEvaluated(Define.BehaviourTree.Result.Fail);
                return;
            }
            
            CurChild.Evaluation();
        }

        public override void OnChildEvaluated(Define.BehaviourTree.Result _result)
        {
            if (_result == Define.BehaviourTree.Result.Running)
            {
                treeController.ChangeCurrentNode(this, true);
                return;
            }

            switch (_result)
            {
                case Define.BehaviourTree.Result.Fail:
                    // 실패할 경우 다음 노드를 수행할 수 있도록 인덱스에 1을 더한다.
                    ++childIndex;
                    if (childIndex >= childCount)
                    {
                        Close();
                        parent.OnChildEvaluated(Define.BehaviourTree.Result.Fail);
                    }
                    break;
                case Define.BehaviourTree.Result.Success:
                    Close();
                    parent.OnChildEvaluated(_result);
                    break;
                default:
                    return;
            }
        }

        public override void Close()
        {
            childIndex = 0;
        }
    }
}