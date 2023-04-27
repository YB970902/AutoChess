using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class DtoCharacter
    {
        /// <summary>
        /// 캐릭터의 아이디. 유저가 가지고 있는 캐릭터들을 구분하기 위해 존재한다.
        /// 다른 유저의 캐릭터와 ID가 겹칠수도 있다.
        /// 변경되지 않는다.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// 캐릭터의 정보를 가지고 있는 아이디.
        /// 정적 데이터를 통해 스텟같은 데이터를 가지고 올 수 있다.
        /// 변경되지 않는다.
        /// </summary>
        public int CharacterID { get; }
        
        /// <summary>
        /// 캐릭터가 서있는 필드의 인덱스.
        /// -1인경우 필드위에 존재하지 않는 것이다.
        /// </summary>
        public int FieldIndex { get; }

        public DtoCharacter(int _id, int _characterId, int _fieldIndex)
        {
            ID = _id;
            CharacterID = _characterId;
            FieldIndex = _fieldIndex;
        }
    }
}