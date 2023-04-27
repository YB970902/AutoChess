using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class DtoUser
    {
        /// <summary>
        /// 유저의 아이디. 인게임으로 진입하게 되면 부여된다.
        /// 변경되지 않는다.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// 유저의 고유 아이디. 계정이 생성되면 부여된다.
        /// 변경되지 않는다.
        /// </summary>
        public long Idx { get; }

        /// <summary>
        /// 유저가 보유중인 캐릭터의 정보.
        /// </summary>
        public List<DtoCharacter> Characters { get; }

        public DtoUser(int _id, long _idx, List<DtoCharacter> _characters)
        {
            ID = _id;
            Idx = _idx;
            Characters = _characters;
        }
    }
}