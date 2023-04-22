using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class DtoUser : MonoBehaviour
    {
        /// <summary>
        /// 유저의 아이디. 인게임으로 진입하게 되면 부여된다.
        /// </summary>
        private int id;
        public int ID => id;

        /// <summary>
        /// 유저의 고유 아이디. 계정이 생성되면 부여된다.
        /// </summary>
        private long idx;
        public long Idx => idx;
    }
}