using System.Collections;
using System.Collections.Generic;
using FixMath.NET;
using UnityEngine;

namespace Battle
{
    public class BoCharacter
    {
        /// <summary>
        /// 유저가 보유중인 캐릭터들끼리 구분짓기 위한 아이디.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// 캐릭터의 고유 아이디. 캐릭터의 종류마다 아이디가 다르다.
        /// </summary>
        private int characterId;
        
        public int FieldIndex { get; private set; }

        /// <summary>
        /// 궁극기 사용 가능 여부
        /// TODO : 임시로 프로퍼티로 사용 중이나, 메소드로 변경될수도 있음
        /// </summary>
        public bool CanUseUlt { get; private set; }
        
        /// <summary>
        /// 스킬 사거리.
        /// TODO : 임시로 프로퍼티이나, 나중엔 Status라는 클래스로 관리.
        /// </summary>
        public Fix64 SkillRange { get; private set; }
        
        public BoCharacter(DtoCharacter _dto)
        {
            ID = _dto.ID;
            characterId = _dto.CharacterID;
        }

        public void UpdateData(DtoCharacter _dto)
        {
            characterId = _dto.CharacterID;
        }
    }
}