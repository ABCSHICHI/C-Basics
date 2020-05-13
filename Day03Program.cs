using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Program
    {
        static void Main1(string[] args)
        {
            //声明,动态数组
            int[] array;
            //初始化 new 数据类型【容量】
            array = new int[7];
            float[] ScoreArray = CreateScoreArray();
            Console.WriteLine("本次最高成绩为：{0}", GetMax(ScoreArray));
        }
        private static float[] CreateScoreArray()
        {
            Console.WriteLine("请输入学生数目：");
            int count = int.Parse(Console.ReadLine());
            float[] ScoreArray = new float[count];
            for (int i = 0; i < count; )
            {
                Console.WriteLine("请输入第{0}个学生的成绩：", i + 1);
                float score = float.Parse(Console.ReadLine());
                if (score >= 0 && score <= 100)
                    ScoreArray[i++] = score;
                else
                    Console.WriteLine("输入的成绩有误。");

            }
            return ScoreArray;

        }

        private static float GetMax(float[] array) {
            float maxNumber = array[0];
            for (int i = 0; i < array.Length-1; i++)
            {
                if (maxNumber < array[i + 1])
                    maxNumber = array[i];
                    
            }
            return maxNumber;
        }

        static void Main1()
        {
            //数组其他写法
            //初始化+赋值
            string[] array01 = new string[2] { "a", "b" };

            //声明+初始化+赋值
            bool[] array02 = { true, false, true };

            int[] array = new int[] { 10, 22, 33, 55, 88, 54, 21 };
            /*
             * foreach(元素类型 变量名 in数组名)
             * {
             *      变量名 即数组每个元素
             * }
             * */
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }

            //推断类型：根据所赋值数据类型，推断出类型
            var v1 = 1;
            var v2 = "1";
            var v3 = '1';
            var v4 = true;
            var v5 = 1.0;

            //声明 父类类型 赋值 子类对象
            Array arr01 = new int[2];
            Array arr02 = new double[2];
            Array arr03 = new string[2];
            PrintElement(new int[] { 22, 33, 55, 88, 77 });
            PrintElement(new float[] { 22, 33, 55, 88, 77 });

            //object 万类之祖
            //声明object类型 赋值 任意类
            object o1 = 1;
            object o2 = true;
            object o3 = new int[3];
        }
        private static void PrintElement(Array arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        static void Main()
        {
            int angle = 0;
            
            for (int i = 0; i < 100; i++)
            {
                angle ++;
      
                double x = angle * Math.Sin(angle);
                double y = angle * Math.Sin(angle);
                Console.WriteLine(x.ToString()+","+y.ToString());
                
            }
            
        }
    }
}
