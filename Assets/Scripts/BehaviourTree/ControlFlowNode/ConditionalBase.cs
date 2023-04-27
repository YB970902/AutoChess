
using Battle;

namespace BehaviourTree
{
    /// <summary>
    /// IfNode의 조건식 인터페이스
    /// </summary>
    public abstract class ConditionalBase
    {
        protected BehaviourTreeController controller;
        
        public void Set(BehaviourTreeController _controller)
        {
            controller = _controller;
        }
        
        /// <summary>
        /// 조건식 결과
        /// </summary>
        public abstract bool GetResult();
    }
    
    /// <summary>
    /// 궁극기 사용 가능 여부.
    /// </summary>
    public class CanUseUltSkill : ConditionalBase
    {   
        public override bool GetResult()
        {
            return controller.BoCharacter.CanUseUlt;
        }
    }
    
    /// <summary>
    /// 적이 궁극기 범위 내에 있는지 여부.
    /// </summary>
    public class IsTargetInUltSkillRange : ConditionalBase
    {
        public override bool GetResult()
        {
            var enemyCharacters = BattleManager.Instance.GetEnemyCharactersInField();
            if (enemyCharacters == null) return false;
            

            return false;
        }
    }
    
    /// <summary>
    /// 적이 공격 범위 내에 있는지 여부.
    /// </summary>
    public class IsTargetInAttackRange : ConditionalBase
    {
        public override bool GetResult()
        {
            return false;
        }
    }
}