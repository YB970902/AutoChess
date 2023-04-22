using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class BoUser : MonoBehaviour
    {
        private int id;
        private long idx;
        
        public void Set(DtoUser _dto)
        {
            id = _dto.ID;
            idx = _dto.Idx;
        }
    }
}