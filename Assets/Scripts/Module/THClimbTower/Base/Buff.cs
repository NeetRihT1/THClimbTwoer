﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THClimbTower
{
    public abstract class Buff : Model.Component
    {
        public int LastTime { get; set; }

        public string Icon { get; set; }

        public BattleCharactor Owner { get; set; }
        //public abstract Task<object> RunEvent(EventType eventType, object o, params object[] args);
    }
}
