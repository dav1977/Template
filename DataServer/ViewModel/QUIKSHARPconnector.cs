using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuikSharp;
using QuikSharp.DataStructures;
using QuikSharp.DataStructures.Transaction;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;


namespace project.ViewModel
{
    class QUIKSHARPconnector
    {
        bool isServerConnected;
        Quik _quik;
        public static event Delegate_Print Event_Print;
        public static event Delegate_Command Event_CMD;


        public void start()
        {

            Connect();
        }

        private void Connect()
        {
  
            try
            {
                add("Соединяемся со скриптом QuikSharp..." );
                _quik = new Quik(Quik.DefaultPort, new InMemoryStorage()); 
           

            }
            catch
            {
                add("Ошибка инициализации QuikSharp...");
            }
            if (_quik != null)
            {
                add("Экземпляр QuikSharp создан.");
                try
                {
                    add("Получаем статус соединения ..." );
                    isServerConnected = _quik.Service.IsConnected().Result;
                    if (isServerConnected)
                    {
                        add("Соединение с сервером установлено." );
                        
                    }
                    else
                    {
                        add("Соединение с сервером НЕ установлено." );
                       
                    }
                }
                catch
                {
                    add("Неудачная попытка получить статус соединения с сервером." );
                }
            }
        }

        void add(string s)
        {
            if (Event_Print != null)  Event_Print(s);
        }





    }
}
