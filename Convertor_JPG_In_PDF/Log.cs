using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertor_JPG_In_PDF
{
    public class Log
    {

        public string Action { get; set; }

        public string Message { get; set; }

        public string NameFile { get; set; }

        public string NewPath { get; set; }

        public Log()
        {

        }

        public override string ToString()
        {
            return $"Файл {NameFile}, сохранен по пути {NewPath}, Операция закончилась в {DateTime.Now.ToShortTimeString()}";   
        }
    }
}
