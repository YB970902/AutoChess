using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class BoCharacter : MonoBehaviour
    {
        private int id;
        
        public void Set(DtoCharacter _dto)
        {
            id = _dto.ID;
        }
    }
}