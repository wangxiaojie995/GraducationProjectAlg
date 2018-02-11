using bbbbb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nodeList = new List<int>();
            //（1|2）|3|4|5|6|7|8|9*
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LEFTBRACET);
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LEFTBRACET);
            nodeList.Add((int)'1');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'2');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_RIGHTBRACET);
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'3');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'4');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_RIGHTBRACET);
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_BIBAO);
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'5');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'6');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LIANJIE);
            nodeList.Add((int)'7');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'8');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'9');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_BIBAO);

            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_MINPOR);


            Console.WriteLine("****************正规式是*****************");
            for (int i = 0; i < nodeList.Count; i++)
            {
                Console.Write(nodeList[i] + " ");
            }
            RE re = new RE(nodeList);
            Console.WriteLine();
            Console.WriteLine("****************树状结构是***************");

            re.PrintRE();
            Console.WriteLine("--------------------------------------------");
            NFA nfa = RE.GetNFA_(re.GetRoot());
            Console.WriteLine("--------------------------------------------");
            for (int i = 0; i < nfa.fa.headVerList.Count; i++)
            {
                Console.Write(i + ": ");
                for(int j = 0; j < nfa.fa.headVerList[i].arcList.Count; j++)
                {
                    Console.Write("(" + nfa.fa.headVerList.IndexOf(nfa.fa.headVerList[i].arcList[j].eVertex) + "," + nfa.fa.headVerList[i].arcList[j].transfer_char + ")");
                }
                Console.WriteLine();
            }
        }
    }
}
