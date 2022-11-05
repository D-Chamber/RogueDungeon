using System;
using System.Collections.Generic;
using System.Text;

namespace RogueDungeon
{
     public interface IWorldEvent
     {

          Room Trigger { get; }
          void Execute();
     }
}