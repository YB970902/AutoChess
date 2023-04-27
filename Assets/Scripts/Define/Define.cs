namespace Define
{
    public class GameData
    {
        public const int MaxUserCount = 8;
    }
    
    public class BehaviourTree
    {
        public enum Result
        {
            Success, // 성공
            Fail, // 실패
            Running, // 동작중
        }
        
        /// <summary>
        /// 조건식
        /// </summary>
        public enum IfType
        {
            None,
            CanUseUltSkill, // 궁극기 사용 가능 여부.
            IsTargetInUltSkillRange, // 적이 궁극기 범위 내에 있는지 여부.
            IsTargetInAttackRange, // 적이 공격 범위 내에 있는지 여부.
        }
    }
}