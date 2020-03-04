﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SogeniKatas.FbGame
{
    public interface IFizzBuzzRule
    {
        bool Is(int number);

        string Output { get; }
    }
}
