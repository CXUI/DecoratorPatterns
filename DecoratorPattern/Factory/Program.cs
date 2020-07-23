using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
namespace Factory
{
    public enum FactoryType
    {
        SimpleFactoryModel,
        AbstractFactoryModel,
        FactoryModel,
    }
    class Program
    {
        static void Main(string[] args)
        {
            Factory _simpleFactoryModel = CreateFactoryModel.Factory(FactoryType.AbstractFactoryModel);
            _simpleFactoryModel.Print();

            Console.ReadKey();
        }
    }

   public abstract  class Factory
    {
        public abstract void Print();
    }

    public class CreateFactoryModel
    {
        public static Factory Factory(FactoryType type)
        {
            switch (type)
            {
                case FactoryType.SimpleFactoryModel: return new SimpleFactoryModel();
                case FactoryType.AbstractFactoryModel:return new AbstractFactoryModel();
                case FactoryType.FactoryModel:return new FactoryModel();
                default:return new SimpleFactoryModel();
            }
        }
    }


    //简单工程模式
   public  class SimpleFactoryModel: Factory
    {
        public enum RobotType
        {
            Megatron,
            Bumblebee,
        }
        public override void Print()
        {
            Console.WriteLine("------简单工厂模式-------");

            Robot _bumbleebee = RobotFactory.RobotFactor(RobotType.Bumblebee);
            _bumbleebee.Print();

            Robot _megatron = RobotFactory.RobotFactor(RobotType.Megatron);
            _megatron.Print();

        }


        public abstract  class Robot
        {
            public abstract void Print();
        }

        public class Bumblebee : Robot
        {
            public override void Print()
            {
                Console.WriteLine("这是一个大黄蜂");
            }
        }

        public class Megatron : Robot
        {
            public override void Print()
            {
                Console.WriteLine("这是一个威震天");
            }
        }
        public class OtherTobot : Robot
        {
            public override void Print()
            {
                Console.WriteLine("这是一个其他类型");
            }
        }


        //机器人工厂
        class RobotFactory
        {
            public static Robot RobotFactor(RobotType type)
            {
                switch (type)
                {
                    case RobotType.Bumblebee:return new Bumblebee();
                    case RobotType.Megatron:return new Megatron();
                    default:return new OtherTobot();
                }
            }
        }

   
    }

    //抽象工厂模式
    public class AbstractFactoryModel : Factory
    {
        public override void Print()
        {
            Console.WriteLine("---------抽象工厂模式----------");

            AbstractFactory APC = new APCFactory();
            //Robot car= APC._robot();
            //car.Print();
            AbstractFactory afp = new PeopleFactory(APC);
            Robot car= afp._robot();
            // Robot car = afc._robot();
              car.Print();


            //AbstractFactory afc = new ACFactory();
            //AbstractFactory afp = new PeopleFactory(afc);
            // Robot car = afc._robot();
            // car.Print();

            //AbstractFactory afp = new PeopleFactory();
            //Robot peopel = afp._robot();
            //peopel.Print();
        }

        #region 抽象工厂
        public abstract class AbstractFactory
        {
            public abstract Robot _robot();
 
        }
        public   class ACFactory:AbstractFactory
        {
            public override Robot _robot()
            {
                return new RobotCar();
            }

        }
        public class APCFactory : AbstractFactory
        {
            public override Robot _robot()
            {
                return new RobotPeople();
            }

        }
        public class CarFactory : AbstractFactory
        {
            public AbstractFactory _factory;

            public CarFactory( AbstractFactory factory)
            {
                _factory = factory;
            }
            
            public override Robot _robot()
            {
                return _factory._robot();
               // return new RobotCar();
            }
        }

        public class PeopleFactory : AbstractFactory
        {
            public AbstractFactory _factory;

            public PeopleFactory(AbstractFactory factory)
            {
                _factory = factory;
            }
            public override Robot _robot()
            {
                 
                return _factory._robot();
            }
        }
        #endregion


        #region 抽象对象

        public abstract class Robot
        {
            public abstract void Print();
        }

        //抽象机器人 --汽车形态
        public   class RobotCar:Robot
        {
            public override void Print()
            {
                Console.WriteLine("机器人 --汽车形态");
            }
        }
     
        //抽象机器人 --人形态
        public   class RobotPeople: Robot
        {
            public override void Print()
            {
                Console.WriteLine("机器人 --人形态");
            }
        }

        #endregion
    }


    //工厂模式
    public class FactoryModel : Factory
    {
   
        public override void Print()
        {
            Console.WriteLine("---------工厂模式----------");
            FactoryType bumblebeeFac = new BumblebeeFactory();
            FactoryType megatronFac = new MegatronFactory();
            // bumblebee.CreateRobot().Print();
            Robot BF = bumblebeeFac.CreateRobot();
            Robot MF = megatronFac.CreateRobot();
            BF.Print();
            MF.Print();
        }

        #region 具体模型
        public abstract class Robot
        {
            public abstract void Print();
        }

        public class Bumblebee : Robot
        {
            public override void Print()
            {
                Console.WriteLine("这是一个大黄蜂");
            }
        }

        public class Megatron : Robot
        {
            public override void Print()
            {
                Console.WriteLine("这是一个威震天");
            }
        }
        #endregion

        #region 工厂类
        public abstract class FactoryType
        {
            public abstract Robot CreateRobot();
        }

        public class BumblebeeFactory : FactoryType
        {
            public override Robot CreateRobot()
            {
                return new Bumblebee();
            }
        }
        public class MegatronFactory : FactoryType
        {
            public override Robot CreateRobot()
            {
                return new Megatron();
            }
        }

        #endregion
    }
}
