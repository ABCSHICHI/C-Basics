using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    class Program
    {
        static void Main1(string[] args)
        {
            int[] myTicket = BuyTicket();
            int level;
            int count = 0;
            do
            {
                count++;
                int[] randomTicket = CreateRandomTicket();
                level = TicketEquals(myTicket, randomTicket);
                if (level != 0)
                    Console.WriteLine("恭喜，{0}等奖。累计消费：{1:c}元",
                        level,
                        count * 2);
            } while (level != 1);
            
            
        }

        private static int[] BuyTicket()
        {
            int[] ticket = new int[7];

            //前6个球
            for (int i = 0; i < 6;)
            {
                Console.WriteLine("请输入第{0}个红球号码：",i+1);
                int redNumber = int.Parse(Console.ReadLine());
                if (redNumber < 1 || redNumber > 33)
                    Console.WriteLine("购买的号码超过范围");
                else if (Array.IndexOf(ticket,redNumber)>=0)
                    Console.WriteLine("号码已经存在");
                else
                    ticket[i++] = redNumber;
                

            }

            //di7个篮球
            while (true)
            {
                Console.WriteLine("请输入篮球号码：");
                int blueNumber = int.Parse(Console.ReadLine());
                if (blueNumber >= 1 && blueNumber <= 16)
                {
                    ticket[6] = blueNumber;
                    break;
                }
                    
                else
                    Console.WriteLine("号码超过范围");
            }

            return ticket;
        }
        static Random random = new Random();
        private static int[] CreateRandomTicket()
        {
            int[] ticket = new int[7];
            for (int i = 0; i < 6; i++)
            {
                int redNumber = random.Next(1, 34);

                if (Array.IndexOf(ticket, redNumber) == -1)
                    ticket[i++] = redNumber;
            }
            ticket[6] = random.Next(1, 17);
            Array.Sort(ticket,0,6);
            return ticket;
        }
        private static int TicketEquals(int[] myTicket,int[] randomTicket)
        {
            //计算红球、篮球中奖数量
            int blueCount = myTicket[6] == randomTicket[6]?1:0;
            int redCount = 0;
            //我的第i个红球号码，在随机彩票中的红球号码中是否存在
            for (int i = 0; i < 6; i++)
            {
                if (Array.IndexOf(randomTicket, myTicket[i], 0, 6) >= 0)
                    redCount++;

            }
            int level;
            if (blueCount + redCount == 7)
                level = 1;
            else if (redCount == 6)
                level = 2;
            else if (redCount + blueCount == 6)
                level = 3;
            else if (redCount + blueCount == 5)
                level = 4;
            else if (redCount + blueCount == 4)
                level = 5;
            else if (redCount == 1)
                level = 6;
            else
                level = 0;
            return level;
        }

        //两层for循环
        static void Main2(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                for (int r = 0; r < 4-i; r++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }
        

        /*
         *自定义排序 
         */
         static void Main3(string[] args)
        {
            int[] array = { 2, 11, 55, 8, 6, 1, 12, 8, 9, 6, 45, 0 };
            int maxIdex = 0;
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    if(array[j] > array[maxIdex])
                    {
                        maxIdex = j;
                    }
                }
                temp = array[maxIdex];
                array[maxIdex] = array[i];
                array[i] = temp;
                maxIdex = i+1;
            }
            foreach (var item in array)
            {
                Console.Write(item + ",");
            }
        }
        static void Main4(string[] args)
        {
            //二维数组
            /*
            *行长：array.GetLength(0)
            * 列长： array.GetLength(1);
            */
            //创建5行3列数组
            int[,] array = new int[5, 3];

        }


        /*
         2048核心算法

        需求分析：
         上移：
         --从上到下 获取列数据，形成一维数组
         --合并数据：
                    1.去零：将0元素移到末尾
                    2.相邻相同，则合并（将后一个元素累加到前一个元素上，后一个元素清零）
                    3.去零：将0元素移至末尾
         --将一维数组元素 还原至原列

         下移：
         1.0
         --从上到下 获取列数据，形成一维数组
          --合并数据：
                    1.去零：将0元素移到开头
                    2.相邻相同，则合并（将前一个元素累加到后一个元素上，前一个元素清零）
                    3.去零：将0元素移至开头
         --将一维数组元素 还原至原列
         2.0
         --从下到上 获取列数据，形成一维数组
         --合并数据：
                    1.去零：将0元素移到末尾
                    2.相邻相同，则合并（将后一个元素累加到前一个元素上，后一个元素清零）
                    3.去零：将0元素移至末尾
         --将一维数组元素 还原至原列

         左移：
         右移：

        编码：
        1.定义去零的方法（针对一维数组）：将0移至末尾
        2.合并数据（针对一维数组）：
                    1.去零：将0元素移到开头
                    2.相邻相同，则合并（将前一个元素累加到后一个元素上，前一个元素清零）
                    3.去零：将0元素移至开头
        3.上移：
         --从上到下 获取列数据，形成一维数组
         --调用合并数据方法
         --将一维数组元素 还原至原列
         4.下移：
         --从下到上 获取列数据，形成一维数组
         --调用合并数据方法
         --将一维数组元素 还原至原列
         5.左移
         6.有移
             */
            
        static void Main5(string[] args)
        {
            int[,] map = {
                {2,2,4,8 },
                {2,4,4,4 },
                {0,8,4,0 },
                {2,4,0,4 }
            };
            PrintDoubleArray(map);

            Console.WriteLine("上移：");
            map = MoveUp(map);
            PrintDoubleArray(map);
            Console.WriteLine("下移：");
            map = MoveDown(map);
            PrintDoubleArray(map);
            Console.WriteLine("左移：");
            map = MoveLeft(map);
            PrintDoubleArray(map);
            Console.WriteLine("右移：");
            map = MoveRight(map);
            PrintDoubleArray(map);
        }
        private static void PrintDoubleArray(Array array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array.GetValue(i,j) + "\t");
                }
                Console.WriteLine();

            }
        }
        //去零
        //2 0 0 2
        private static int[] RemoveZero(int[] array)
        {
            //0 0 0 0 
            //新建数组，初始化数组元素都为0
            int[] newArray = new int[array.Length];
            int index = 0;
            //将非零元素 依次 赋值给新数组
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                    newArray[index++] = array[i];
            }
            return newArray;
        }
        //2 2 0 2
        //合并数组
        private static int[] Merge(int[] array)
        {
            array = RemoveZero(array);//去零
            for (int i = 0; i < array.Length - 1; i++)
            {
                //相邻元素是否相同
                if(array[i]!=0 && array[i] == array[i + 1])
                {
                    array[i] += array[i + 1];
                    array[i + 1] = 0;
                }
                
            }
            array = RemoveZero(array);
            return array;
        }

        //上移
        private static int[,] MoveUp(int[,] map)
        {
            int[] newArray = new int[map.GetLength(0)];
            for (int j = 0; j < map.GetLength(1); j++)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    newArray[i] = map[i, j];
                }
                newArray = Merge(newArray);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    map[i, j] = newArray[i];
                }
            }
            return map;
        }
        //下移
        private static int[,] MoveDown(int[,] map)
        {
            int[] newArray = new int[map.GetLength(0)];
            for (int j = 0; j < map.GetLength(1); j++)
            {
                for (int i = map.GetLength(0) - 1; i >= 0; i--)
                {
                    newArray[3 - i] = map[i, j];
                }
                newArray = Merge(newArray);
                for (int i = map.GetLength(0) - 1; i >= 0; i--)
                {
                    map[i, j] = newArray[3 - i];
                }
            }
            return map;
        }
        //左移动
        private static int[,] MoveLeft(int[,] map)
        {
            int[] newArray = new int[map.GetLength(1)];
            for (int j = 0; j < map.GetLength(0); j++)
            {
                for (int i = 0; i < map.GetLength(1); i++)
                {
                    newArray[i] = map[j, i];
                }
                newArray = Merge(newArray);
                for (int i = 0; i < map.GetLength(1); i++)
                {
                    map[j, i] = newArray[i];
                }
            }
            return map;
        }
        //右移动
        private static int[,] MoveRight(int[,] map)
        {
            int[] newArray = new int[map.GetLength(1)];
            for (int j = 0; j < map.GetLength(0); j++)
            {
                for (int i = map.GetLength(1) - 1; i >= 0; i--)
                {
                    newArray[3 - i] = map[j, i];
                }
                newArray = Merge(newArray);
                for (int i = map.GetLength(1) - 1; i >= 0; i--)
                {
                    map[j, i] = newArray[3 - i];
                }
            }
            return map;
        }



        static void Main(string[] args)
        {
            //交错数组
            int[][] array;//null
            //创建有4个元素的交错数组
            array = new int[4][];
            //创建一维数组 赋值给交错数组
            array[0] = new int[3];
            array[1] = new int[5];
            array[2] = new int[4];
            array[3] = new int[1];

            //赋值
            array[0][0] = 1;
            array[1][2] = 2;
            foreach (var item in array)
            {
                foreach (var element in item)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
