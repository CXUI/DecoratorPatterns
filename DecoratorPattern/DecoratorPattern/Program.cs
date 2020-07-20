using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    //装饰模式
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Bumblebee();
            Console.WriteLine("------------------------");

            Decorator armor = new Armor(robot);
            armor.print();
            Decorator arms = new Arms(robot);
            arms.print();
            Console.WriteLine("------------------------");

            Decorator armora = new Armor(robot);
            Decorator armsa = new Arms(armora);
            armsa.print();

            Console.ReadKey();
        }
    }
    //机器人，抽象类
    //抽象构件（Robot）角色：给出一个抽象接口，以规范准备接受附加责任的对象。
    public abstract class Robot
    {
        public abstract void print();
    }
    /// <summary>
    /// 装饰抽象类，行为抽象类
    /// </summary>
    //装饰（Dicorator）角色：持有一个构件（Component）对象的实例，并定义一个与抽象构件接口一致的接口。
    public abstract class Decorator : Robot
    {
        public Robot _robot;
        public Decorator(Robot robot)
        {
            _robot = robot;
        }

        public override void print()
        {
            if (_robot != null)
            {
                _robot.print();
            }
        }

    }

    //具体构件（Bumblebee）角色：定义一个将要接收附加责任的类。
    public class Bumblebee : Robot
    {
        public override void print()
        {
            Console.WriteLine("这是一个大黄蜂");
        }
    }

    //具体装饰（Armor和Arms）角色：负责给构件对象 ”贴上“附加的责任。
    public class Armor : Decorator
    {
        public Armor(Robot robot) : base(robot)
        {
        }

        public override void print()
        {
            base.print();
            AddArmor();

        }
        public void AddArmor()
        {
            Console.WriteLine("添加一副盔甲");
        }
    }
    //具体装饰（Armor和Arms）角色：负责给构件对象 ”贴上“附加的责任。
    public class Arms : Decorator
    {
        public Arms(Robot robot) : base(robot)
        {
        }

        public override void print()
        {
            base.print();
            AddArmor();

        }
        public void AddArmor()
        {
            Console.WriteLine("添加一把武器");
        }
    }
}

