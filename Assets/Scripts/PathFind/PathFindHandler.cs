using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathFind
{
    /// <summary>
    /// 길찾기 핸들러.
    /// 길찾기 매니저가 관리하며, 사용하기 위해선 시작위치와 끝 위치를 받아야 한다.
    /// </summary>
    public class PathFindHandler
    {
        /// <summary>  활성화 여부  </summary>
        private bool isActive;
        public bool IsActive => isActive;

        private int startIndex;
        private int destIndex;

        /// <summary>
        /// 기본값으로 초기화.
        /// </summary>
        public void Init()
        {
            startIndex = PathFindManager.InvalidTileIndex;
            destIndex = PathFindManager.InvalidTileIndex;
            isActive = false;
        }

        /// <summary>
        /// 사용할 수 있도록 세팅.
        /// </summary>
        public void Set(int _startIndex, int _destIndex)
        {
            startIndex = _startIndex;
            destIndex = _destIndex;
            isActive = true;
        }
    }
}