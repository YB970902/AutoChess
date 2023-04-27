using System.Collections.Generic;

namespace BehaviourTree
{
    /// <summary>
    /// 여러개의 자식이 있는 Node
    /// </summary>
    public abstract class ControlFlowNode : NodeBase
    {
        /// <summary>
        /// 현재 평가중인 자식 노드의 인덱스
        /// </summary>
        protected int childIndex;
        
        protected NodeBase CurChild => children[childIndex];
        public override void Initialize(NodeBase _parent, BehaviourTreeController _treeController)
        {
            base.Initialize(_parent, _treeController);

            childCount = transform.childCount;

            // 자식 노드를 삽입한다.
            for (int i = 0; i < childCount; ++i)
            {
                children.Add(transform.GetChild(i).GetComponent<NodeBase>());
            }
        }
    }
}