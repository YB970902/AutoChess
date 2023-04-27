using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class BoUser
    {
        private int id;
        public int ID => id;
        private long idx;
        public long Idx => idx;

        public List<BoCharacter> Characters { get; private set; }

        public BoUser(DtoUser _dto)
        {
            id = _dto.ID;
            idx = _dto.Idx;
            Characters = new List<BoCharacter>(_dto.Characters.Count);
            for (int i = 0, count = _dto.Characters.Count; i < count; ++i)
            {
                Characters.Add(new BoCharacter(_dto.Characters[i]));
            }
        }

        public void UpdateData(DtoUser _dto)
        {
            for(int i = 0, count = Characters.Count; i < count; ++i)
            {
                Characters[i].UpdateData(_dto.Characters.Find(_ => _.ID == Characters[i].ID));
            }
        }
    }
}