using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfopoleProject
{
    //Интерфейс для возможности тестирования методов с вводом данных
    public interface IConsoleReader 
    {
        string ReadLine();
    }
}
