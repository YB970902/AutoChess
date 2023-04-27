using Battle;
using UnityEngine;

namespace BehaviourTree
{
    /// <summary>
    /// 행동트리를 관리하는 컨트롤러.
    /// </summary>
    public class BehaviourTreeController : MonoBehaviour
    {
        /// <summary> 현재 평가중인 노드 </summary>
        private NodeBase curNode;

        /// <summary>
        /// 행동트리의 대상인 캐릭터
        /// </summary>
        private BoCharacter boCharacter;
        public BoCharacter BoCharacter => boCharacter;

        /// <summary> 최상위 노드 </summary>
        [SerializeField] RootNode root = null;

        /// <summary>
        /// 초기화 함수.
        /// 루트에서부터 초기화를 진행한다.
        /// </summary>
        public void Initialize(BoCharacter _boCharacter)
        {
            boCharacter = _boCharacter;
            
            curNode = root;
            root.Initialize(null, this);
            root.Evaluation();
        }

        /// <summary>
        /// 현재 평가중인 노드를 변경할때 호출하는 함수이다.
        /// </summary>
        public void ChangeCurrentNode(NodeBase _curNode, bool _closeWithParent = false)
        {
            if (curNode == _curNode) return;
            
            var prevNode = curNode;
            curNode = _curNode;
            CloseUntilCurrentNode(prevNode);
        }
        
        
        /// <summary>
        /// BehaviourController의 CurNode가 있을때까지 있는 모든 노드를 종료한다.
        /// </summary>
        private void CloseUntilCurrentNode(NodeBase node)
        {
            while (node != curNode && node.Parent != null)
            {
                node.Close();
                node = node.Parent;
            }
        }

        /// <summary>
        /// 현재 노드를 평가하는 노드.
        /// </summary>
        public void Evaluation()
        {
            curNode.Evaluation();
        }
    }
}