﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DRS
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale();
    }
}
