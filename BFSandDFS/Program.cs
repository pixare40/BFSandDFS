using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSandDFS
{
    public class Program
    {
        public Vertex<Person>[] mygraph;

        public Vertex<Person> alice;
        public Vertex<Person> tom;
        public Vertex<Person> kabaji;
        public Vertex<Person> rob;
        public Vertex<Person> prim;
        public Vertex<Person> dijkstra;
        public Vertex<Person> tiger;
        public Vertex<Person> tpain;
        public Vertex<Person> steven;
        public Vertex<Person> ian;
        public Vertex<Person> wayne;

        public Program()
        {
            mygraph = new Vertex<Person>[20];

            alice = new Vertex<Person>(new Person("Alice"));
            tom = new Vertex<Person>(new Person("Tom"));
            kabaji = new Vertex<Person>(new Person("Kabaji"));
            rob = new Vertex<Person>(new Person("Rob"));
            prim = new Vertex<Person>(new Person("Prim"));
            dijkstra = new Vertex<Person>(new Person("Dijkstra"));
            tiger = new Vertex<Person>(new Person("Tiger"));
            tpain = new Vertex<Person>(new Person("T-Pain"));
            steven = new Vertex<Person>(new Person("Steven"));
            ian = new Vertex<Person>(new Person("Ian"));
            wayne = new Vertex<Person>(new Person("Wayne"));

            //add friends

            alice.AddNeighbour(wayne);
            alice.AddNeighbour(kabaji);
            wayne.AddNeighbour(tom);
            kabaji.AddNeighbour(rob);
            rob.AddNeighbour(tiger);
            tiger.AddNeighbour(dijkstra);
            dijkstra.AddNeighbour(prim);
            tom.AddNeighbour(prim);
            tiger.AddNeighbour(tpain);
            tiger.AddNeighbour(ian);
            tiger.AddNeighbour(steven);

            //add to array to finalize graph

            mygraph[0] = alice;
            mygraph[1] = tom;
            mygraph[2] = kabaji;
            mygraph[3] = rob;
            mygraph[4] = prim;
            mygraph[5] = dijkstra;
            mygraph[6] = tiger;
            mygraph[7] = tpain;
            mygraph[8] = steven;
            mygraph[9] = ian;
            mygraph[10] = wayne;
        }
        public void BFS<T>(Vertex<T>[] G, int startvertex)
        {
            Queue<Vertex<T>> Q = new Queue<Vertex<T>>();
            Q.Enqueue(G[startvertex]);
           // G[startvertex].Discovered = true;

            while (Q.Count != 0)
            {

                var v = Q.Dequeue();
                v.Discovered = true;
                var neighbours = v.Neighbours;

                if (v.Processed != true)
                {
                    foreach (var n in neighbours)
                    {
                        if (!n.Discovered)
                        {
                            n.Discovered = true;
                            n.Parent = v;
                        }

                        Q.Enqueue(n);
                    }

                    v.Processed = true;
                    Console.WriteLine(v.Data.ToString());
                }
            }
        }

        public void DFS<T>(Vertex<T>[] G, int startvertex)
        {
            Stack<Vertex<T>> S = new Stack<Vertex<T>>();

            S.Push(G[startvertex]);

            while (S.Count != 0)
            {
                var v = S.Pop();
                v.Discovered = true;
                var neighbours = v.Neighbours;

                if (v.Processed != true)
                {
                    foreach (var n in neighbours)
                    {
                        if (!n.Discovered)
                        {
                            n.Discovered = true;
                            n.Parent = v;
                        }

                        S.Push(n);

                    }
                    v.Processed = true;

                    Console.WriteLine(v.Data.ToString());

                }
            }
           
        }
        
        static void Main(string[] args)
        {
            //initialise
            var p = new Program();

            //carry out BFS
            //Console.WriteLine("Press any key to carry out BFS");
            //Console.ReadLine();
            //Console.WriteLine("Carrying out BFS...");
            //p.BFS(p.mygraph, 1);

            //carry out DFS
            Console.WriteLine("Press Any Key to Carry out DFS");
            Console.ReadLine();
            Console.WriteLine("Carrying out DFS...");
            p.DFS(p.mygraph, 1);

            Console.WriteLine("Both Algorithms implemented, Press any key to exit");
            Console.ReadLine();
        }
    }

    public class Vertex<T>
    {
        
        private T _data;
        private LinkedList<Vertex<T>> _neighbours;
        private bool _discovered = false;
        private bool _processed = false;
        private Vertex<T> _parent;

        public Vertex(T data)
        {
            _data = data;
            _neighbours = new LinkedList<Vertex<T>>();
        }
        public T Data
        {
            get
            {
                return _data;
            }
        }

        public LinkedList<Vertex<T>> Neighbours
        {
            get { return _neighbours; }
            set
            {
                _neighbours = value;
            }
        }

        public bool Discovered
        {
            get { return _discovered; }
            set
            {
                _discovered = value;
            }
        }

        public bool Processed
        {
            get { return _processed; }
            set
            {
                if (_processed == true)
                {
                    throw new Exception("Vertex has already been processed");
                }
                else
                {
                    _processed = value;
                }
            }
        }

        public Vertex<T> Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != null)
                {
                    throw new Exception("Vertex already has a parent");
                }
                else
                {
                    _parent = value;
                }
            }
        }

        public void AddNeighbour(Vertex<T> value)
        {
            Neighbours.AddLast(value);
            if (!value.Neighbours.Contains(this))
                value.AddNeighbour(this);
        }
    }

    public class Person
    {
        private string _name;

        public Person(string name)
        {
            this._name = name;
        }
        public string Name
        {
            get
            {
                return _name;
            }

        }

        public override string ToString()
        {
            return _name;
        }
    }
}
