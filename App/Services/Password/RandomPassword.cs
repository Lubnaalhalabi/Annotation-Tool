using System;
using System.Collections.Generic;
using System.Text;
using Services.Password;

namespace Services.Password
{
     public class RandomPassword : IPasswordGenerator
     {
        private readonly string[] Symbols = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "{", "}", "[", "]", "|", "\\", ":", ";", "\"", "'", "<", ">", ",", ".", "?", "/" };

        public string GenerateRandomPassword()
        {
            const int passwordLength = 8; // Change this value to adjust the desired length of the password

            var random = new Random();
            var password = new StringBuilder();

            // Generate one random character of each type
            password.Append((char)random.Next('a', 'z' + 1)); // Small letter
            password.Append((char)random.Next('A', 'Z' + 1)); // Capital letter
            password.Append(random.Next(0, 10)); // Number
            password.Append(Symbols[random.Next(0, Symbols.Length)]); // Symbol

            // Generate remaining random characters
            for (int i = 4; i < passwordLength; i++)
            {
                var characterType = random.Next(0, 4); // 0 = Small letter, 1 = Capital letter, 2 = Number, 3 = Symbol

                switch (characterType)
                {
                    case 0:
                        password.Append((char)random.Next('a', 'z' + 1));
                        break;
                    case 1:
                        password.Append((char)random.Next('A', 'Z' + 1));
                        break;
                    case 2:
                        password.Append(random.Next(0, 10));
                        break;
                    case 3:
                        password.Append(Symbols[random.Next(0, Symbols.Length)]);
                        break;
                }
            }

            // Shuffle the characters in the password using Fisher-Yates (Knuth) shuffle algorithm
            for (int i = password.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = password[i];
                password[i] = password[j];
                password[j] = temp;
            }

            return password.ToString();
        }
    }
}
