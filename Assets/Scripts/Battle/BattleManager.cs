using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Util;

namespace Battle
{
    /// <summary>
    /// 전투에 필요한 매니저이다.
    /// 모든 유저들의 데이터를 가지고 있다.
    /// </summary>
    public class BattleManager : MonoSingleton<BattleManager>
    {
        /// <summary> 유저의 정보. 인덱스와 유저의 ID가 일치한다. </summary>
        private List<BoUser> users = new List<BoUser>(Define.GameData.MaxUserCount);

        /// <summary>
        /// 내 유저 아이디.
        /// </summary>
        private int myUserID;

        /// <summary>
        /// 나와 전투를 치루는 적 유저의 아이디.
        /// -1인경우 적이 없는 상태이다.
        /// </summary>
        private int enemyUserID;
        
        public BoUser GetUser(int _index) => users[_index];

        /// <summary>
        /// 인게임에 들어가면 데이터를 세팅하기 위한 함수.
        /// 게임이 시작되면 단 한번 호출된다.
        /// </summary>
        public void Set(List<DtoUser> _dtoUsers, int _userID)
        {
            myUserID = _userID;
            
            users.Clear();

            for (int i = 0, count = _dtoUsers.Count; i < count; ++i)
            {
                users.Add(new BoUser(_dtoUsers.Find(_ => _.ID == i)));
            }
        }

        /// <summary>
        /// 적 캐릭터 정보를 모두 가져온다.
        /// </summary>
        public List<BoCharacter> GetEnemyCharacters()
        {
            return users[enemyUserID].Characters;
        }

        /// <summary>
        /// 적 캐릭터 중 필드에 위치하는 캐릭터의 정보를 가져온다.
        /// </summary>
        public List<BoCharacter> GetEnemyCharactersInField()
        {
            if (GetEnemyCharacters() == null) return null;

            return GetEnemyCharacters().FindAll(_ => _.FieldIndex > 0).ToList();
        }

        public override void OnStart() { }
    }
}