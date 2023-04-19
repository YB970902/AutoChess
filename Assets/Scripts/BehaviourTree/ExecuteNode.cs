namespace BehaviourTree
{
    /// <summary>
    /// 행동을 수행하는 노드.
    /// </summary>
    public abstract class ExecuteNode : NodeBase
    {
        private bool isFirstExecute;

        public override void Initialize(NodeBase _parent, BehaviourTreeController _treeController)
        {
            base.Initialize(_parent, _treeController);

            Init();
        }

        /// <summary>
        /// ExecuteNode의 초기화
        /// </summary>
        private void Init()
        {
            isFirstExecute = true;
        }

        public override void Evaluation()
        {
            if (isFirstExecute)
            {
                isFirstExecute = false;
                OnEnter();
            }
            
            var result = Execute();
            
            if (result == Define.BehaviourTree.Result.Fail ||
                result == Define.BehaviourTree.Result.Success)
            {
                // 결과가 성공 혹은 실패이면 평가가 끝난것이므로 초기화를 한다.
                Init();
                Close();
            }
            parent.OnChildEvaluated(result);
        }

        public override void Close() { }
        public override void OnChildEvaluated(Define.BehaviourTree.Result _result) { }

        /// <summary>
        /// 최초로 행동에 진입했을 때 호출되는 함수이다.
        /// Execute 직전에 호출되며, Execute와 같은 프레임에 호출된다.
        /// </summary>
        protected abstract void OnEnter();
        protected abstract Define.BehaviourTree.Result Execute();
    }
}