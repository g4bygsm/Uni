// Se da o matrice cu valori 0 si 1. Se cere distanta minima de la o pozitie 0,0 pana la alta pozitie
// n-1,n-1.

// 0 0 0 0 1 0 0 0  - - - -
// 0 0 1 0 1 0 0 0        |
// 0 1 0 0 0 1 1 0        |-
// 0 0 0 1 0 0 1 0         |
// 1 1 0 1 0 1 0 0         |
// 0 0 0 0 0 0 0 0         | - - -

// raspuns 12


// COADA 

// =====================================================
// 4 2 2 3 3 1 3 0 2 1 0 1 0 0
// 2 2 4 2 1 3 0 3 0 1 2 0 1 0
// 7 7 7 6 5 5 4 4 3 3 3 2 2 1
// =====================================================


// ( (2+31) - (5x7) ) + ( 3 x (9-2) + 7 - 25 ) - 1 =

//     
//                        minus
//                   /           \
//          plus                   1
//        /           \
//     minus                    minus 
//    /    \                    /      \
//  plus      ori             plus       25
//  /  \     /  \           /       \
//  2   3   5     7    ori            7
//                /    \
//              3      minus
//                     /    \
//                    9       2

// RPN



// t1 = S.Pop();
// t2 = S.Pop();
// S.Push(t2 op t1);




// sir
// 2 31 + 5 7 x - 3 9 2 - x 7 + 25 - + 1 -




//using System.Security;

//namespace StackQueue
//{



//    public class Stack
//    {
//        int[] v;



//        public void Push(int x)
//        {
//            int[] t = new int[v.Length + 1];
//            for (int i = 0; i < v.Length; i++)
//            {
//                t[i + 1] = v[i];
//                t[0] = x;
//                v = t;
//            }
//        }
//        public int Pop()
//        {
//            int tor = v[0];
//            int[] t = new int[v.Length-1];
//            for(int i = 0;i < v.Length-1;i++)
//            {
//                t[i] = v[i + 1];
//            }
//            v = t;
//            return tor;
//        }
//    }
//}


using System;

namespace StackQueue
{

}