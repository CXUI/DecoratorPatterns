using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 观察者模式
/// </summary>
namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            IObserver obA = new SubscriberA();
            IObserver obB = new SubscriberB("ABC");
            EventManager evemt = new Louder("eventA", "eventB");

            evemt.AddObservers(obA);
            evemt.AddObservers(obB);
             
            evemt.Update();

            Console.ReadKey();
        }


    }

    public abstract class EventManager
    {
        public List<IObserver> observers = new List<IObserver>();

        public string _eventA, _eventB;

        public EventManager(string eventA,string eventB)
        {
            _eventA = eventA;
            _eventB = eventB;
        }

        public void AddObservers(IObserver obser)
        {
            if (!observers.Contains(obser)) observers.Add(obser);
        }
        public void RemoveObservers(IObserver obser)
        {
            if(observers.Contains(obser)) observers.Remove(obser);
        }

        public void Update()
        {
            foreach(var temp in observers)
            {
                temp.ReceiveAndPrint(this);
            }
        }
    }


    public class Louder : EventManager
    {
        public Louder(string eventA, string eventB) : base(eventA, eventB)
        {
        }
    }


    public interface IObserver
    {
         void ReceiveAndPrint(EventManager manager);
    }

    public class SubscriberA : IObserver
    {
        public void ReceiveAndPrint(EventManager manager)
        {
            Console.WriteLine("观察者模式：{0}   {1}", manager._eventA, manager._eventB);
        }
    }

    public class SubscriberB : IObserver
    {
        private string _name;
        public SubscriberB(string names)
        {
            _name = names;
        }
        public void ReceiveAndPrint(EventManager manager)
        {
            Console.WriteLine("观察者模式： {0}   {1}   name{2}", manager._eventA, manager._eventB,_name);
        }
    }

}
