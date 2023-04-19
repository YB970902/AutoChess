using System.Collections.Generic;

namespace BehaviourTree
{
    public class RootNode : NodeBase
    {
        private NodeBase Child => children[0];

        public override void Evaluation()
        {
            Child.Evaluation();
        }

        public override void OnChildEvaluated(Define.BehaviourTree.Result _result)
        {
            treeController.ChangeCurrentNode(this);
        }

        public override void Close() { }
    }
}