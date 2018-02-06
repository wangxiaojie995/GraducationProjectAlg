using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbbbb
{

    public class Node
    {
        /// <summary>
        /// value的值为-1表示优先级最低的运算符
        /// value的值为0-127表示ascii码
        /// value的值为128-129分别表示左括号，右括号
        /// value的值为130-132分别表示连接符号，或符号，闭包符号，也属于运算符
        /// value为其他值表示未定义
        /// </summary>
        public int value;

        /// <summary>
        /// 左孩子
        /// </summary>
        public Node lChild = null;

        /// <summary>
        /// 右孩子
        /// </summary>
        public Node rChild = null;


        public Node(int value = -2, Node lChild = null, Node rChild = null)
        {
            this.value = value;
            this.lChild = lChild;
            this.rChild = rChild;
        }

        /// <summary>
        /// 判断是否为叶子节点
        /// </summary>
        /// <returns></returns>
        public bool IfIsLeaf()
        {
            if(lChild == null && rChild == null)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>按枚举VALUE_TYPE的类型返回</returns>
        public VALUE_TYPE GetValueType()
        {
            if (value >= 0 && value <= 127) return VALUE_TYPE.VALUE_TYPE_ASCII;
            if (value == 128 || value == 129) return VALUE_TYPE.VALUE_TYPE_BRACKET;
            if ((value >= 130 && value <= 132) || value == -1) return VALUE_TYPE.VALUE_TYPE_OPERATOR;
            return VALUE_TYPE.VALUE_TYPE_UNDEFINE;
        }


        public VALUE_TYPE_CONCRETE GetValueTypeConcrete()
        {
            if(value >= -1 && value <= 132)
            {
                return (VALUE_TYPE_CONCRETE)value;
            }
            return VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_UNDEFINE;
        }
        //public 

        public static void PrintTree(Node root, string str = "")
        {
            if (root == null) return;
            Console.WriteLine(str + root.value);
            string str1 = "    " + str;
            string str2 = "    " + str;
            if(root.lChild != null) PrintTree(root.lChild, str1);
            if(root.rChild != null) PrintTree(root.rChild, str2);
        }

        /// <summary>
        /// 比较优先级
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public static int ComparePri(Node node1, Node node2)
        {
            if(node1.GetValueType() != VALUE_TYPE.VALUE_TYPE_OPERATOR)return -2;
            if(node2.GetValueType() != VALUE_TYPE.VALUE_TYPE_OPERATOR)return -2;
            switch(node1.GetValueTypeConcrete())
            {
                case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_MINPOR:
                    switch(node2.GetValueTypeConcrete())
                    {
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_MINPOR: return 0; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO: return -1; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LIANJIE: return -1; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_BIBAO: return -1; break;
                    }
                    break;

                case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO:
                    switch (node2.GetValueTypeConcrete())
                    {
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_MINPOR:return 1; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO: return 1; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LIANJIE:return -1; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_BIBAO:return -1; break;
                    }
                    break;

                case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LIANJIE:
                    switch (node2.GetValueTypeConcrete())
                    {
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_MINPOR:return 1; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO:return 1; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LIANJIE:return 1; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_BIBAO:return -1; break;
                    }
                    break;

                case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_BIBAO:
                    switch (node2.GetValueTypeConcrete())
                    {
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_MINPOR: return 1; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO: return 1; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LIANJIE:return 1; break;
                        case VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_BIBAO: return 1; break;
                    }
                    break;
            }
            return -2;
        }

    }

    public enum VALUE_TYPE
    {
        VALUE_TYPE_UNDEFINE = 0,//未定义
        VALUE_TYPE_ASCII = 1,//ascii码
        VALUE_TYPE_BRACKET = 2,//括号
        VALUE_TYPE_OPERATOR = 3//操作符
    }

    public enum VALUE_TYPE_CONCRETE
    {
        VALUE_TYPE_CONCRETE_UNDEFINE = -2,
        VALUE_TYPE_CONCRETE_MINPOR = -1,
        VALUE_TYPE_CONCRETE_ASCII_0 = 0,
        VALUE_TYPE_CONCRETE_ASCII_1 = 1,
        VALUE_TYPE_CONCRETE_ASCII_2 = 2,
        VALUE_TYPE_CONCRETE_ASCII_3 = 3,
        VALUE_TYPE_CONCRETE_ASCII_4 = 4,
        VALUE_TYPE_CONCRETE_ASCII_5 = 5,
        VALUE_TYPE_CONCRETE_ASCII_6 = 6,
        VALUE_TYPE_CONCRETE_ASCII_7 = 7,
        VALUE_TYPE_CONCRETE_ASCII_8 = 8,
        VALUE_TYPE_CONCRETE_ASCII_9 = 9,
        VALUE_TYPE_CONCRETE_ASCII_10 = 10,
        VALUE_TYPE_CONCRETE_ASCII_11 = 11,
        VALUE_TYPE_CONCRETE_ASCII_12 = 12,
        VALUE_TYPE_CONCRETE_ASCII_13 = 13,
        VALUE_TYPE_CONCRETE_ASCII_14 = 14,
        VALUE_TYPE_CONCRETE_ASCII_15 = 15,
        VALUE_TYPE_CONCRETE_ASCII_16 = 16,
        VALUE_TYPE_CONCRETE_ASCII_17 = 17,
        VALUE_TYPE_CONCRETE_ASCII_18 = 18,
        VALUE_TYPE_CONCRETE_ASCII_19 = 19,
        VALUE_TYPE_CONCRETE_ASCII_20 = 20,
        VALUE_TYPE_CONCRETE_ASCII_21 = 21,
        VALUE_TYPE_CONCRETE_ASCII_22 = 22,
        VALUE_TYPE_CONCRETE_ASCII_23 = 23,
        VALUE_TYPE_CONCRETE_ASCII_24 = 24,
        VALUE_TYPE_CONCRETE_ASCII_25 = 25,
        VALUE_TYPE_CONCRETE_ASCII_26 = 26,
        VALUE_TYPE_CONCRETE_ASCII_27 = 27,
        VALUE_TYPE_CONCRETE_ASCII_28 = 28,
        VALUE_TYPE_CONCRETE_ASCII_29 = 29,
        VALUE_TYPE_CONCRETE_ASCII_30 = 30,
        VALUE_TYPE_CONCRETE_ASCII_31 = 31,
        VALUE_TYPE_CONCRETE_ASCII_32 = 32,
        VALUE_TYPE_CONCRETE_ASCII_33 = 33,
        VALUE_TYPE_CONCRETE_ASCII_34 = 34,
        VALUE_TYPE_CONCRETE_ASCII_35 = 35,
        VALUE_TYPE_CONCRETE_ASCII_36 = 36,
        VALUE_TYPE_CONCRETE_ASCII_37 = 37,
        VALUE_TYPE_CONCRETE_ASCII_38 = 38,
        VALUE_TYPE_CONCRETE_ASCII_39 = 39,
        VALUE_TYPE_CONCRETE_ASCII_40 = 40,
        VALUE_TYPE_CONCRETE_ASCII_41 = 41,
        VALUE_TYPE_CONCRETE_ASCII_42 = 42,
        VALUE_TYPE_CONCRETE_ASCII_43 = 43,
        VALUE_TYPE_CONCRETE_ASCII_44 = 44,
        VALUE_TYPE_CONCRETE_ASCII_45 = 45,
        VALUE_TYPE_CONCRETE_ASCII_46 = 46,
        VALUE_TYPE_CONCRETE_ASCII_47 = 47,
        VALUE_TYPE_CONCRETE_ASCII_48 = 48,
        VALUE_TYPE_CONCRETE_ASCII_49 = 49,
        VALUE_TYPE_CONCRETE_ASCII_50 = 50,
        VALUE_TYPE_CONCRETE_ASCII_51 = 51,
        VALUE_TYPE_CONCRETE_ASCII_52 = 52,
        VALUE_TYPE_CONCRETE_ASCII_53 = 53,
        VALUE_TYPE_CONCRETE_ASCII_54 = 54,
        VALUE_TYPE_CONCRETE_ASCII_55 = 55,
        VALUE_TYPE_CONCRETE_ASCII_56 = 56,
        VALUE_TYPE_CONCRETE_ASCII_57 = 57,
        VALUE_TYPE_CONCRETE_ASCII_58 = 58,
        VALUE_TYPE_CONCRETE_ASCII_59 = 59,
        VALUE_TYPE_CONCRETE_ASCII_60 = 60,
        VALUE_TYPE_CONCRETE_ASCII_61 = 61,
        VALUE_TYPE_CONCRETE_ASCII_62 = 62,
        VALUE_TYPE_CONCRETE_ASCII_63 = 63,
        VALUE_TYPE_CONCRETE_ASCII_64 = 64,
        VALUE_TYPE_CONCRETE_ASCII_65 = 65,
        VALUE_TYPE_CONCRETE_ASCII_66 = 66,
        VALUE_TYPE_CONCRETE_ASCII_67 = 67,
        VALUE_TYPE_CONCRETE_ASCII_68 = 68,
        VALUE_TYPE_CONCRETE_ASCII_69 = 69,
        VALUE_TYPE_CONCRETE_ASCII_70 = 70,
        VALUE_TYPE_CONCRETE_ASCII_71 = 71,
        VALUE_TYPE_CONCRETE_ASCII_72 = 72,
        VALUE_TYPE_CONCRETE_ASCII_73 = 73,
        VALUE_TYPE_CONCRETE_ASCII_74 = 74,
        VALUE_TYPE_CONCRETE_ASCII_75 = 75,
        VALUE_TYPE_CONCRETE_ASCII_76 = 76,
        VALUE_TYPE_CONCRETE_ASCII_77 = 77,
        VALUE_TYPE_CONCRETE_ASCII_78 = 78,
        VALUE_TYPE_CONCRETE_ASCII_79 = 79,
        VALUE_TYPE_CONCRETE_ASCII_80 = 80,
        VALUE_TYPE_CONCRETE_ASCII_81 = 81,
        VALUE_TYPE_CONCRETE_ASCII_82 = 82,
        VALUE_TYPE_CONCRETE_ASCII_83 = 83,
        VALUE_TYPE_CONCRETE_ASCII_84 = 84,
        VALUE_TYPE_CONCRETE_ASCII_85 = 85,
        VALUE_TYPE_CONCRETE_ASCII_86 = 86,
        VALUE_TYPE_CONCRETE_ASCII_87 = 87,
        VALUE_TYPE_CONCRETE_ASCII_88 = 88,
        VALUE_TYPE_CONCRETE_ASCII_89 = 89,
        VALUE_TYPE_CONCRETE_ASCII_90 = 90,
        VALUE_TYPE_CONCRETE_ASCII_91 = 91,
        VALUE_TYPE_CONCRETE_ASCII_92 = 92,
        VALUE_TYPE_CONCRETE_ASCII_93 = 93,
        VALUE_TYPE_CONCRETE_ASCII_94 = 94,
        VALUE_TYPE_CONCRETE_ASCII_95 = 95,
        VALUE_TYPE_CONCRETE_ASCII_96 = 96,
        VALUE_TYPE_CONCRETE_ASCII_97 = 97,
        VALUE_TYPE_CONCRETE_ASCII_98 = 98,
        VALUE_TYPE_CONCRETE_ASCII_99 = 99,
        VALUE_TYPE_CONCRETE_ASCII_100 = 100,
        VALUE_TYPE_CONCRETE_ASCII_101 = 101,
        VALUE_TYPE_CONCRETE_ASCII_102 = 102,
        VALUE_TYPE_CONCRETE_ASCII_103 = 103,
        VALUE_TYPE_CONCRETE_ASCII_104 = 104,
        VALUE_TYPE_CONCRETE_ASCII_105 = 105,
        VALUE_TYPE_CONCRETE_ASCII_106 = 106,
        VALUE_TYPE_CONCRETE_ASCII_107 = 107,
        VALUE_TYPE_CONCRETE_ASCII_108 = 108,
        VALUE_TYPE_CONCRETE_ASCII_109 = 109,
        VALUE_TYPE_CONCRETE_ASCII_110 = 110,
        VALUE_TYPE_CONCRETE_ASCII_111 = 111,
        VALUE_TYPE_CONCRETE_ASCII_112 = 112,
        VALUE_TYPE_CONCRETE_ASCII_113 = 113,
        VALUE_TYPE_CONCRETE_ASCII_114 = 114,
        VALUE_TYPE_CONCRETE_ASCII_115 = 115,
        VALUE_TYPE_CONCRETE_ASCII_116 = 116,
        VALUE_TYPE_CONCRETE_ASCII_117 = 117,
        VALUE_TYPE_CONCRETE_ASCII_118 = 118,
        VALUE_TYPE_CONCRETE_ASCII_119 = 119,
        VALUE_TYPE_CONCRETE_ASCII_120 = 120,
        VALUE_TYPE_CONCRETE_ASCII_121 = 121,
        VALUE_TYPE_CONCRETE_ASCII_122 = 122,
        VALUE_TYPE_CONCRETE_ASCII_123 = 123,
        VALUE_TYPE_CONCRETE_ASCII_124 = 124,
        VALUE_TYPE_CONCRETE_ASCII_125 = 125,
        VALUE_TYPE_CONCRETE_ASCII_126 = 126,
        VALUE_TYPE_CONCRETE_ASCII_127 = 127,

        VALUE_TYPE_CONCRETE_LEFTBRACET = 128,
        VALUE_TYPE_CONCRETE_RIGHTBRACET = 129,
        VALUE_TYPE_CONCRETE_LIANJIE = 130,
        VALUE_TYPE_CONCRETE_HUO = 131,
        VALUE_TYPE_CONCRETE_BIBAO = 132,

    }

}
