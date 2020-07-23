using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    //建造者模式
    class Program
    {
        static void Main(string[] args)
        {
            Player play = new Player();

            BuildRoboter bulider = new BuildRoboter();

            play.Construct(bulider);

            Robot robot = bulider.GetRobot();
            robot.Show();
            Console.ReadKey();

        }



    }

    public class Player
    {
        public void Construct(Builder builder)
        {
            builder.AddChip();
            builder.AddEnergy();
            builder.AddShell();
        }
    }

    public class Robot
    {
        public List<string> parts = new List<string>();
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void Show()
        {
            for (int i = 0; i < parts.Count; i++)
            {
                Console.WriteLine("组装" + parts[i] + "中。。。。");
            }
            Console.WriteLine("组装完成");
        }

    }

    //建造
    public abstract class Builder
    {
        public abstract void AddShell();//加外壳
        public abstract void AddChip();//加芯片

        public abstract void AddEnergy();//加能源

        public abstract Robot GetRobot();
    }

    public class BuildRoboter : Builder
    {
        Robot robot = new Robot();
        public override void AddChip()
        {
            robot.Add("加个芯片");
        }

        public override void AddEnergy()
        {
            robot.Add("加个能源");
        }

        public override void AddShell()
        {
            robot.Add("加个外壳");
        }

        public override Robot GetRobot()
        {
            return robot;
        }
    }
}
