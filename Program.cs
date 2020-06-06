using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Program
    {

        static void Main()
        {
            int[,] map = new int[4, 4];
            //{
            //    {0,2,4,2 },
            //    {2,0,8,2 },
            //    {0,2,4,4 },
            //    {4,2,0,2 }
            //};
            //PrintDoublearry(map);
            //Console.WriteLine("上移");
            //Moveup(map);
            //PrintDoublearry(map);
            //Console.WriteLine("下移");
            //Movedown(map);
            //PrintDoublearry(map);
            //Console.WriteLine("左移");
            //Moveleft(map);
            //PrintDoublearry(map);
            //Console.WriteLine("右移");
            //Moveright(map);
            //PrintDoublearry(map);
            Randmap(map);
            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey();//获取按键信息
                switch (info.Key)
                {
                    case ConsoleKey.LeftArrow://如果是向左键
                        Console.WriteLine("←");
                        Moveleft(map);
                        break;
                    case ConsoleKey.UpArrow://如果是向上键
                        Console.WriteLine("↑");
                        Moveup(map);
                        break;
                    case ConsoleKey.RightArrow://如果是向右键
                        Console.WriteLine("→");
                        Moveright(map);
                        break;
                    case ConsoleKey.DownArrow://如果是向下键
                        Console.WriteLine("↓");
                        Movedown(map);
                        break;
                    default:
                        break;
                }
            }
            Console.ReadLine();
        }

        static int[] RemoveZero(int[] array)//清零
        {   
            int[] newarray=new int[array.Length];
            int index = 0;  
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                    newarray[index++] = array[i];
            }
            return newarray;
        }
        static int[] Mergearray(int[] array)//合并
        {
            array=RemoveZero(array);
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i]!=0 && array[i] == array[i + 1])  
                {
                    array[i] += array[i + 1];
                    array[i + 1] = 0;
                }      
            }
            array = RemoveZero(array);
            return array;
        } 
        static int[,] Moveup(int[,] map)//上移
        {
            int[] merge = new int[map.GetLength(0)];
            for (int j = 0; j < map.GetLength(1); j++)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    merge[i] = map[i, j];
                }
                merge=Mergearray(merge);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    map[i, j] = merge[i];
                }

            }
            Rand(map);
            PrintDoublearry(map);
            return map;
        }
        static int[,] Movedown(int[,] map)//下移
        {
            int[] merge = new int[map.GetLength(0)];
            for (int j = map.GetLength(1) - 1; j >=0; j--)
            {
                for (int i = map.GetLength(0) - 1; i >= 0; i--)
                {
                    merge[map.GetLength(0) - 1 - i] = map[i, j];
                }
                merge=Mergearray(merge);
                for (int i = map.GetLength(0) - 1; i >= 0; i--)
                {
                    map[i, j] = merge[map.GetLength(0) - 1 - i];
                }

            }
            Rand(map);
            PrintDoublearry(map);
            return map;
        }
        static int[,] Moveleft(int[,] map)//左移
        {
            int[] merge = new int[map.GetLength(1)];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    merge[j] = map[i, j];
                }
                merge = Mergearray(merge);
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    map[i, j] = merge[j];
                }

            }
            Rand(map);
            PrintDoublearry(map);
            return map;
        }
        static int[,] Moveright(int[,] map)//右移
        {
            int[] merge = new int[map.GetLength(0)];
            for (int i = map.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = map.GetLength(1) - 1; j >= 0; j--)
                {
                    merge[map.GetLength(0) - 1 - j] = map[i, j];
                }
                merge = Mergearray(merge);
                for (int j = map.GetLength(1) - 1; j >= 0; j--)
                {
                    map[i, j] = merge[map.GetLength(0) - 1 - j];
                }

            }
            Rand(map);
            PrintDoublearry(map);
            return map;
        }
        static void PrintDoublearry(int[,] array)//输出二维数组
        {
            Console.Clear();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j<array.GetLength(1); j++)
                {
                    Console.Write(array[i,j]+"\t");
                }
                Console.WriteLine("\n");
            }
        }
        static int[,] Rand(int[,] array) //生成随机的2或4
        {
            Random rand = new Random();

            int i = rand.Next(array.GetLength(0));//获取随机行索引
            int j = rand.Next(array.GetLength(1));//获取随机列索引

            if (array[i, j] == 0)//如果该随机数原来等于0
            {
                int num = rand.Next(10);
                if (num == 0)//随机生成4的概率为10%
                {
                    array[i, j] = 4;
                }
                else//随机生成2的概率为90%
                {
                    array[i, j] = 2;
                }
            }
            return array;
        }
        static int[,] Randmap(int[,] array) //初始化
        {
            Random rand = new Random();

            int i = rand.Next(array.GetLength(0));//获取随机行索引
            int j = rand.Next(array.GetLength(1));//获取随机列索引

            array[i, j] = 2;
            i = rand.Next(array.GetLength(0));//获取随机行索引
            j = rand.Next(array.GetLength(1));//获取随机列索引
            if (array[i, j] == 0)//不是第一个随机的2
            {
                array[i, j] = 2; 
            }
            PrintDoublearry(array);
            return array;
        }

    }
}
