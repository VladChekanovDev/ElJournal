using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ElJournal.Other
{
    class Validation
    {
        public static string LoginError = "Логин может состоять из латинских букв, цифр, знака подчеркивания и точки. Длина не более 32 символа.";
        public static string PasswordError = "Слабый пароль. Пароль должен содержать как минимум 1 строчную и 1 заглавную букву, 1 цифру. Длина пароля минимум 8 символов";
        public static string EmptyFieldError = "Заполните все поля";
        public static string UserNotFoundError = "Пользователь не найден. Неверный логин или пароль";
        public static string IncorrectInputError = "Неверные данные";
        public static string ImpossibleToParseError = "Недопустимое значение ввода";
        public static bool LoginValidate(string Login)
        {
            Regex LoginRegex = new Regex(@"^(?=.*[A-Za-z0-9]$)[A-Za-z][A-Za-z\d._]{0,32}$");
            if (!LoginRegex.IsMatch(Login))
            {
                return false;
            }
            else
                return true;
        }

        public static bool PasswordValidate(string Pass)
        {
            Regex PasswordRegex = new Regex(@"^(?=.*[(A-Z)|(А-Я)])(?=.*[0-9])(?=.*[(a-z)|(a-я)]).{8,}$");
            if (!PasswordRegex.IsMatch(Pass))
            {
                return false;
            }
            else
                return true;
        }

        public static bool EmptyFieldValidate(string text)
        {
            if (text.Length == 0)
            {
                return false;
            }
            else
                return true;
        }

        public static bool IncorrectInputValidate(string input, string value)
        {
            if (input != value)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool StringToIntParse(string value)
        {
            int num;
            return int.TryParse(value, out num);
        }
    }
}
