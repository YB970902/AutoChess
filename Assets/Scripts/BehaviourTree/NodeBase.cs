using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    /// <summary>
    /// 행동트리의 기본이 되는 노드
    /// 모든 노드에 사용될 수 있어야 한다.
    /// </summary>
    public abstract class NodeBase : MonoBehaviour
    {
        /// <summary> 부모 노드 </summary>
        protected NodeBase parent;
        /// <summary> 자식 노드 </summary>
        protected List<NodeBase> children;
        /// <summary> 자식의 수. 최초로 자식을 받아온 이후로 변화하지 않는다. </summary>
        protected int childCount;

        public NodeBase Parent => parent;

        /// <summary> 행동트리 컨트롤러 </summary>
        protected BehaviourTreeController treeController;

        /// <summary>
        /// 초기화.
        /// 최초에 노드가 생성되고 나서 단 한번 실행되는 함수이다.
        /// </summary>
        public virtual void Initialize(NodeBase _parent, BehaviourTreeController _treeController)
        {
            parent = _parent;
            treeController = _treeController;
            
            // 초기화
            Close();

            childCount = transform.childCount;
            children = new List<NodeBase>(childCount);
            for (int i = 0; i < childCount; ++i)
            {
                var child = transform.GetChild(i).GetComponent<NodeBase>();
                children.Add(child);
                child.Initialize(this, _treeController);
            }
        }

        /// <summary>
        /// 평가하는 함수.
        /// 노드에 정의된 행동을 수행한다.
        /// </summary>
        public abstract void Evaluation();

        /// <summary>
        /// 자식의 평가가 완료되었을때 호출되는 함수.
        /// </summary>
        /// <param name="_result">자식 노드의 평가 결과</param>
        public abstract void OnChildEvaluated(Define.BehaviourTree.Result _result);
        
        /// <summary>
        /// 노드가 종료될 때 호출되는 함수.
        /// </summary>
        public abstract void Close();
    }
}