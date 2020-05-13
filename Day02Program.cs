using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//调试
//1.在可能出错的地方加断点
//2.按F5 启动调试
//3.按F11 逐句执行
namespace Day02
{
    class Program
    {
        //循环语句 跳转语句 方法
        //for循环
        static void Main1(string[] args)
        {

            /*for (初始化; 循环条件; 增减变量)
            {
                循环体
            }**/
            //作用域：起作用的范围
            //从声明开始到 } 结束
            for (int i = 3; i < 9;)
            {
                Console.WriteLine(i);
                i += 3;
            }

            //一张纸的厚度位0.001毫米
            //计算 对折30次 以后的厚度为多少米
            float thickness = 0.001f;
            for (int i = 0; i < 30; i++)
            {
                thickness *= 2;
            }
            Console.WriteLine("厚度为：" + thickness / 100 + "m");


        }
        //while循环
        static void Main2()
        {
            /*
             * while(条件){
             *     循环体
             * }**/
            /*练习：一个球从100米高度落下
             * 每次落地后，弹回原高度一半
             * 计算，总共经过？次最终落地(弹起最小高度为0.01米)
             *       总共经过多少米
             * */
            float hight = 100.00f;
            int count = 0;
            float totalHigh = 0.00f;
            //下次弹起高度如果大于0.01米
            while (hight / 2 >= 0.01f)
            {
                totalHigh += hight * 1.50f;
                hight /= 2;
                count++;
            }
            Console.WriteLine("总共经过" + count + "次最终落地");
            Console.WriteLine("总共经过" + totalHigh + "m");
        }
        //do while
        static void Main3()
        {
            /*      
            do
            {
                循环体
            } while (条件);
            先执行1次循环体，在判断条件
            **/
            //猜数字
            /*程序产生1-100之间的随机数
             * 让晚间重复猜测，直到猜到为止
             * “大了” “小了” “恭喜，猜对了，总共猜了？次”
             * */
            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            Console.WriteLine(randomNumber);
            int count = 0;
            bool flag = true;
            do
            {
                Console.WriteLine("请输入猜测的数字：");
                count++;
                int guessNum = int.Parse(Console.ReadLine());
                if (guessNum == randomNumber)
                {
                    Console.WriteLine("恭喜，猜对了，总共猜了" + count + "次");
                    flag = false;
                    //break;可以不用对比条件，直接退出
                }
                else if (guessNum > randomNumber)
                    Console.WriteLine("大了!");
                else
                    Console.WriteLine("小了!");
            } while (flag);

        }
        #region//方法 (函数)
        static void Main4()
        {
            /*
             * 【访问修饰符】【可选修饰符】返回类型 方法名称（参数列表）
             * {
             *      方法体
             *      return 结果
             * }
             * ·调用方法：
             *      方法名称(参数)；
             * */

            Fun1();
            float num = Fun2();
            int a = 100;
            string b = "nice";
            //实参 与形参 ---对应（类型，顺序）
            Fun3(a, b);//实际参数

            //学会调用方别人创建的方法
            //1.看名字猜
            //2.看参数（类型 名称 描述）
            //3.看返回值

            string str = "shichi";
            //指定位置插入“字符串”
            str = str.Insert(3, "神");
            //寻下标：返回指定’字符‘在“字符串”中匹配到的第一个的位置
            int index = str.IndexOf('i');
            //移除字符：字符串指定起点下标移除一定数量的字符，没有数量之后全部删除，并返回移除后的”字符“
            string str1 = str.Remove(3, 1);
            //替换字符：指定新‘字符’替换指定旧‘字符’所有
            string str2 = str.Replace('i', 'a');
            //比较字符串：从起点匹配字符是否相同
            bool flag1 = str.StartsWith("shichi");
            //指定字符串是否在该字符串的子串
            bool flag2 = str.Contains("hi");
            Console.WriteLine(flag2);
        }
        //定义方法
        //方法：表示功能
        //返回值：功能结果
        //类型：数据类型 int float double string
        //void 没有返回值
        private static void Fun1()
        {
            Console.WriteLine("Fun1执行了");
        }
        private static float Fun2()
        {
            float a = 250.00f;
            Console.WriteLine("Fun2执行了");
            return a;//返回 数据
        }
        //形式参数
        private static void Fun3(int a, string b)
        {
            Console.WriteLine(a + b);
        }
        #endregion
        
        /// <summary>
        /// 获取二月份天数
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private static bool GetFebruaryDay(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取每月的天数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns>天数</returns>
        private static int GetMonthDay(int year, int month)
        {

            if (month < 1 || month > 12)
            {
                Console.WriteLine("月份数据有误！！！");
                return 0;
            }
            switch (month)
            {
                case 2:
                    return GetFebruaryDay(year) ? 29 : 28; ;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    return 31;
            }
        }


        /// <summary>
        /// 计算星期数
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="day">天数</param>
        /// <returns>星期数</returns>
        private static int GetWeekByDay(int year, int month, int day)
        {
            DateTime da = new DateTime(year, month, day);
            return (int)da.DayOfWeek;
        }

        //练习：日历
        static void Main()
        {
            /*
             * 1.在控制台中实现年历的方法
             * ----调用12遍实现月历
             * 2.在控制台中实现月历的方法
             * ----显示表头 Console.WriteLine("日\t一\t二\t三\t四\t五\t六\t");
             * ----计算当月星期数，输出空白（\t）
             *      Console.Write("\t");
             * -----计算当月天数，输入1\t2\t3\t4\t  
             * -----每逢周六换行
             * 3.根据年月日，计算星期数
             * 4.计算指定月数 的天数
             * 5.2月闰年29天， 平年28天
             *   年份能被4整除，但不能被100整除
             *   年份能被400整除
             * */
            Console.WriteLine("请输入需要查询的年份：");
            int year = int.Parse(Console.ReadLine());
            for (int i = 0; i < 12; i++)
            {
                int weekDay = GetWeekByDay(year, i + 1, 1);
                int monthDay = GetMonthDay(year, i + 1);
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("年：{0},月份：{1}，天数：{2}", year,i + 1, monthDay, weekDay);
                Console.WriteLine("日\t一\t二\t三\t四\t五\t六\t");
                for (int r = 0; r < weekDay; r++)
                    Console.Write("\t");

                for (int j = 1; j <= monthDay; j++)
                {
                    Console.Write(j + "\t");
                    if ((j+weekDay) % 7 == 0)
                        Console.Write("\n");
                }
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------");
            }

        }
       
    }
}
