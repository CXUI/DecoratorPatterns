using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//命令模式
namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receive = new Robot();
            Command comand = new ConcreteCommand(receive);
            Invoke invoke = new Invoke(comand);
            
            invoke.ExecuteCommand();
            Console.ReadKey();
        }

        //抽象命令类
        public abstract class Command
        {
            protected Receiver _rectiver;
            public Command(Receiver receiver)
            {
                _rectiver = receiver;
            }
            public abstract void Action();
        }

        public class ConcreteCommand : Command
        {
            public ConcreteCommand(Receiver receiver) : base(receiver) { }

            public override void Action()
            {
                _rectiver.Run();
            }
        }


        //命令者
        public class Invoke
        {
            protected Command _command;
            public Invoke(Command command)
            {
                _command = command;
            }

            public void ExecuteCommand()
            {
                _command.Action();
            }

        }

        //执行者

        public abstract class Receiver
        {

            public abstract void Run();
            //public void Run()
            //{
            //    Console.WriteLine("run");
            //}
        }

        public class Robot : Receiver
        {
            public override void Run()
            {
                Console.WriteLine("Robot Run");
            }
        }

        public class RobotB : Receiver
        {
            public override void Run()
            {
                Console.WriteLine("RobotB Run");
            }
        }
    }
}
