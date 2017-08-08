using HyeongCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyeongTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser hp = new Parser();
            hp.혀엉코드="혀어어어어엉.....흐읏...하이X발놈앗...";
            var a = hp.명령어해석();
            foreach(혀엉명령어 명령 in a)
            {
                Console.WriteLine(string.Format("{0} {1} {2}",명령.명령,명령.글자길이,명령.줄임표길이,명령.하트구역??""));
            }
            Console.ReadKey();
        }
    }
}
