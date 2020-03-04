﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SogeniKatas.FbGame.Rules
{
    public class Pop : IFizzBuzzRule
    {
        public string Output => "pop";

        public bool Is(int number)
        {
            return number % 7 == 0;
        }
    }
}
