using System;
using Banking_System.Enums;
using System.Collections.Generic;

namespace Banking_System
{
    public interface ICard
    {
        void ChangePin(string pin);
        bool CheckPin(string pin);
    }
}
