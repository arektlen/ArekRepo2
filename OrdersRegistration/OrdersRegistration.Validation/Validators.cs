﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OrdersRegistration.Validation
{
    public class Validators
    {
        public static bool MailValidation(string text)
        {
            Regex regex = new Regex(@"^([a-z 0-9 \.\-])*@(([a-z 0-9])+)((\.[a-z]{2,})*)((\.[a-z]{2,3})+)$");

            return regex.IsMatch(text) ? true : false;
        }

        public static bool IsDigitValidation(string text)
        {
            Regex regex = new Regex(@"^([0-9])");

            return regex.IsMatch(text) ? true : false;
        }
    }
}