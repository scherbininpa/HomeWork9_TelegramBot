using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_TelegramBot
{
    public class BotSettings
    {
        public string Token { get { return this.token; } }
        private string token;
        public BotSettings()
        {
            try
            {
                this.token = System.IO.File.ReadAllText(@"O:\Telegram\token.txt");
            }
            catch (Exception)
            {

                throw new ArgumentNullException("Проблема при загрузке файла с токеном");
            }

        }
    }
}
