using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Util;

namespace PathFind
{
    /// <summary>
    /// 길찾기 매니저.
    /// 길찾기를 요청하면 길찾기 핸들러를 반환해준다. 길찾기에 관련된 모든 것들은 핸들러를 통해서 한다.
    /// 핸들러는 오브젝트 풀로 관리한다. 활성화된 핸들러에 있는 정보를 기반으로 매 턴마다 길찾기를 수행한다.
    /// 한 턴에 할 수 있는 최대 
    /// </summary>
    public class PathFindManager : MonoSingleton<PathFindManager>
    {
        public const int InvalidTileIndex = -1;

        [SerializeField] private int handlerPoolSize;
        private List<PathFindHandler> handlerPool;
        
        public PathFindHandler GetHandler()
        {
            foreach (var handler in handlerPool)
            {
                if (handler.IsActive == false) return handler;
            }
            return null;
        }

        public override void OnStart()
        {
            handlerPool = new List<PathFindHandler>(new PathFindHandler[handlerPoolSize]);
            foreach (var handler in handlerPool)
            {
                handler.Init();
            }
        }
    }
}