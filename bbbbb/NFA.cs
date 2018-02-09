
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbbbb
{
    public class NFA
    {
        private FA fa;
    }

    public class DFA
    {
        private FA fa;
    }

    public class SDFA
    {
        private FA fa;
    }

    /// <summary>
    /// 状态机
    /// </summary>
    public class FA
    {
        public Vertex startVertex;
        public Vertex endVertex;

        public List<Vertex> headVerList = new List<Vertex>();

        public static FA GetNewFAByOlds(FA fa1, FA fa2, VALUE_TYPE_CONCRETE value_type_concrete)
        {
            if (fa1 == null && fa2 == null) return null;
            if(value_type_concrete.Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LIANJIE))
            {
                Arc arc = new Arc(fa2.startVertex, TRANSFER_CHARACTER.TRANSFER_CHARACTER_EPSILON);
                fa1.endVertex.AddArc(arc);
                fa2.startVertex = null;
                fa1.endVertex = null;
                fa1.headVerList.AddRange(fa2.headVerList);
                return fa1;
            }
            else if(value_type_concrete.Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO))
            {
                Vertex newStart = new Vertex();
                Vertex newEnd = new Vertex();
                Arc arc1 = new Arc(fa1.startVertex, TRANSFER_CHARACTER.TRANSFER_CHARACTER_EPSILON);
                Arc arc2 = new Arc(fa1.startVertex, TRANSFER_CHARACTER.TRANSFER_CHARACTER_EPSILON);
                Arc arc3 = new Arc(newEnd, TRANSFER_CHARACTER.TRANSFER_CHARACTER_EPSILON);
                Arc arc4 = new Arc(newEnd, TRANSFER_CHARACTER.TRANSFER_CHARACTER_EPSILON);
                newStart.AddArc(arc1);
                newStart.AddArc(arc2);
                fa1.endVertex.AddArc(arc3);
                fa2.endVertex.AddArc(arc4);

                fa1.headVerList.Add(newStart);
                fa2.headVerList.Add(newEnd);

                fa1.startVertex = newStart;
                fa1.endVertex = newEnd;
                fa1.headVerList.AddRange(fa2.headVerList);
                
                return fa1;
            }
            else if(value_type_concrete.Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_BIBAO))
            {
                if (fa1 == null) return null;
                if (fa2 != null) return null;

                Vertex newStart = new Vertex();
                Vertex newEnd = new Vertex();
                Arc arc1 = new Arc(fa1.startVertex, TRANSFER_CHARACTER.TRANSFER_CHARACTER_EPSILON);
                Arc arc2 = new Arc(newEnd, TRANSFER_CHARACTER.TRANSFER_CHARACTER_EPSILON);
                Arc arc3 = new Arc(newEnd, TRANSFER_CHARACTER.TRANSFER_CHARACTER_EPSILON);
                Arc arc4 = new Arc(fa1.startVertex, TRANSFER_CHARACTER.TRANSFER_CHARACTER_EPSILON);
                fa1.headVerList.Add(newStart);
                fa1.headVerList.Add(newEnd);
                newStart.AddArc(arc1);
                newStart.AddArc(arc2);
                fa1.endVertex.AddArc(arc3);
                fa1.endVertex.AddArc(arc4);
                fa1.startVertex = newStart;
                fa1.endVertex = newEnd;
                return fa1;
            }
            else
            {
                return null;
            }
            return null;
        }
    }

    public class Vertex
    {
        public List<Arc> arcList = new List<Arc>();

        public void AddArc(Arc arc)
        {
            if(arc != null)
            {
                arcList.Add(arc);
            }
        }

        public void Remove(Arc arc)
        {
            if(arcList.Contains(arc))
            {
                arcList.Remove(arc);
            }
        }
    }

    public class Arc
    {
        //private Vertex sVertex;
        private Vertex eVertex;
        TRANSFER_CHARACTER transfer_char = TRANSFER_CHARACTER.TRANSFER_CHARACTER_UNDEFINE;

        public Arc(Vertex eVertex, TRANSFER_CHARACTER transfer_char)
        {
            this.eVertex = eVertex;
            this.transfer_char = transfer_char;
        }
    }

    public enum TRANSFER_CHARACTER
    {
        TRANSFER_CHARACTER_UNDEFINE = -1,
        TRANSFER_CHARACTER_0 = 0,
        TRANSFER_CHARACTER_1 = 1,
        TRANSFER_CHARACTER_2 = 2,
        TRANSFER_CHARACTER_3 = 3,
        TRANSFER_CHARACTER_4 = 4,
        TRANSFER_CHARACTER_5 = 5,
        TRANSFER_CHARACTER_6 = 6,
        TRANSFER_CHARACTER_7 = 7,
        TRANSFER_CHARACTER_8 = 8,
        TRANSFER_CHARACTER_9 = 9,
        TRANSFER_CHARACTER_10 = 10,
        TRANSFER_CHARACTER_11 = 11,
        TRANSFER_CHARACTER_12 = 12,
        TRANSFER_CHARACTER_13 = 13,
        TRANSFER_CHARACTER_14 = 14,
        TRANSFER_CHARACTER_15 = 15,
        TRANSFER_CHARACTER_16 = 16,
        TRANSFER_CHARACTER_17 = 17,
        TRANSFER_CHARACTER_18 = 18,
        TRANSFER_CHARACTER_19 = 19,
        TRANSFER_CHARACTER_20 = 20,
        TRANSFER_CHARACTER_21 = 21,
        TRANSFER_CHARACTER_22 = 22,
        TRANSFER_CHARACTER_23 = 23,
        TRANSFER_CHARACTER_24 = 24,
        TRANSFER_CHARACTER_25 = 25,
        TRANSFER_CHARACTER_26 = 26,
        TRANSFER_CHARACTER_27 = 27,
        TRANSFER_CHARACTER_28 = 28,
        TRANSFER_CHARACTER_29 = 29,
        TRANSFER_CHARACTER_30 = 30,
        TRANSFER_CHARACTER_31 = 31,
        TRANSFER_CHARACTER_32 = 32,
        TRANSFER_CHARACTER_33 = 33,
        TRANSFER_CHARACTER_34 = 34,
        TRANSFER_CHARACTER_35 = 35,
        TRANSFER_CHARACTER_36 = 36,
        TRANSFER_CHARACTER_37 = 37,
        TRANSFER_CHARACTER_38 = 38,
        TRANSFER_CHARACTER_39 = 39,
        TRANSFER_CHARACTER_40 = 40,
        TRANSFER_CHARACTER_41 = 41,
        TRANSFER_CHARACTER_42 = 42,
        TRANSFER_CHARACTER_43 = 43,
        TRANSFER_CHARACTER_44 = 44,
        TRANSFER_CHARACTER_45 = 45,
        TRANSFER_CHARACTER_46 = 46,
        TRANSFER_CHARACTER_47 = 47,
        TRANSFER_CHARACTER_48 = 48,
        TRANSFER_CHARACTER_49 = 49,
        TRANSFER_CHARACTER_50 = 50,
        TRANSFER_CHARACTER_51 = 51,
        TRANSFER_CHARACTER_52 = 52,
        TRANSFER_CHARACTER_53 = 53,
        TRANSFER_CHARACTER_54 = 54,
        TRANSFER_CHARACTER_55 = 55,
        TRANSFER_CHARACTER_56 = 56,
        TRANSFER_CHARACTER_57 = 57,
        TRANSFER_CHARACTER_58 = 58,
        TRANSFER_CHARACTER_59 = 59,
        TRANSFER_CHARACTER_60 = 60,
        TRANSFER_CHARACTER_61 = 61,
        TRANSFER_CHARACTER_62 = 62,
        TRANSFER_CHARACTER_63 = 63,
        TRANSFER_CHARACTER_64 = 64,
        TRANSFER_CHARACTER_65 = 65,
        TRANSFER_CHARACTER_66 = 66,
        TRANSFER_CHARACTER_67 = 67,
        TRANSFER_CHARACTER_68 = 68,
        TRANSFER_CHARACTER_69 = 69,
        TRANSFER_CHARACTER_70 = 70,
        TRANSFER_CHARACTER_71 = 71,
        TRANSFER_CHARACTER_72 = 72,
        TRANSFER_CHARACTER_73 = 73,
        TRANSFER_CHARACTER_74 = 74,
        TRANSFER_CHARACTER_75 = 75,
        TRANSFER_CHARACTER_76 = 76,
        TRANSFER_CHARACTER_77 = 77,
        TRANSFER_CHARACTER_78 = 78,
        TRANSFER_CHARACTER_79 = 79,
        TRANSFER_CHARACTER_80 = 80,
        TRANSFER_CHARACTER_81 = 81,
        TRANSFER_CHARACTER_82 = 82,
        TRANSFER_CHARACTER_83 = 83,
        TRANSFER_CHARACTER_84 = 84,
        TRANSFER_CHARACTER_85 = 85,
        TRANSFER_CHARACTER_86 = 86,
        TRANSFER_CHARACTER_87 = 87,
        TRANSFER_CHARACTER_88 = 88,
        TRANSFER_CHARACTER_89 = 89,
        TRANSFER_CHARACTER_90 = 90,
        TRANSFER_CHARACTER_91 = 91,
        TRANSFER_CHARACTER_92 = 92,
        TRANSFER_CHARACTER_93 = 93,
        TRANSFER_CHARACTER_94 = 94,
        TRANSFER_CHARACTER_95 = 95,
        TRANSFER_CHARACTER_96 = 96,
        TRANSFER_CHARACTER_97 = 97,
        TRANSFER_CHARACTER_98 = 98,
        TRANSFER_CHARACTER_99 = 99,
        TRANSFER_CHARACTER_100 = 100,
        TRANSFER_CHARACTER_101 = 101,
        TRANSFER_CHARACTER_102 = 102,
        TRANSFER_CHARACTER_103 = 103,
        TRANSFER_CHARACTER_104 = 104,
        TRANSFER_CHARACTER_105 = 105,
        TRANSFER_CHARACTER_106 = 106,
        TRANSFER_CHARACTER_107 = 107,
        TRANSFER_CHARACTER_108 = 108,
        TRANSFER_CHARACTER_109 = 109,
        TRANSFER_CHARACTER_110 = 110,
        TRANSFER_CHARACTER_111 = 111,
        TRANSFER_CHARACTER_112 = 112,
        TRANSFER_CHARACTER_113 = 113,
        TRANSFER_CHARACTER_114 = 114,
        TRANSFER_CHARACTER_115 = 115,
        TRANSFER_CHARACTER_116 = 116,
        TRANSFER_CHARACTER_117 = 117,
        TRANSFER_CHARACTER_118 = 118,
        TRANSFER_CHARACTER_119 = 119,
        TRANSFER_CHARACTER_120 = 120,
        TRANSFER_CHARACTER_121 = 121,
        TRANSFER_CHARACTER_122 = 122,
        TRANSFER_CHARACTER_123 = 123,
        TRANSFER_CHARACTER_124 = 124,
        TRANSFER_CHARACTER_125 = 125,
        TRANSFER_CHARACTER_126 = 126,
        TRANSFER_CHARACTER_127 = 127,
        TRANSFER_CHARACTER_EPSILON = 128 //ε
    }
}
