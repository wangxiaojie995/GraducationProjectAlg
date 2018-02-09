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
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LEFTBRACET);
            nodeList.Add((int)'1');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'2');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_RIGHTBRACET);
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'3');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'4');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'5');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
            nodeList.Add((int)'6');
            nodeList.Add((int)VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO);
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
            Class1 class1 = new Class1();
            Console.WriteLine();
            Console.WriteLine("****************树状结构是*****************");
            Node root = class1.BuildRegExTree(nodeList);
            Console.WriteLine(root == null);
        }
    }
}
