using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_TelegramBot
{
    public class HandleChatFiles
    {
        //public List<ChatFiles> Files { get { return this.chatFiles; } } 
        public Dictionary<int,ChatFiles> Files { get { return this.dChat; } }
        //private List<ChatFiles> chatFiles ;
        private Dictionary<int,ChatFiles> dChat = new Dictionary<int,ChatFiles>();
        public HandleChatFiles()
        {
            //chatFiles = new List<ChatFiles>();
            try
            {
                int number = 0;
                using (StreamReader sr = new StreamReader("files.txt")) 
                {

                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        number++;
                        var arr = line.Split(";");
                        this.dChat.Add(number, new ChatFiles { Id = arr[0], Name = arr[1], Number = number });
                        //this.chatFiles.Add(new ChatFiles { Id = arr[0], Name = arr[1] ,Number=number});
                    }
                }

            }
            catch (Exception)
            {

                throw new Exception("Проблема с файлом");
            }
        }



    }
}
