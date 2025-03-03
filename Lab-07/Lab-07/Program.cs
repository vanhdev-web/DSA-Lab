using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07
{
    public class Point
    {
        private double x { get; set; }
        private double y { get; set; }

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(double x, double y)
        {
            this.x=x;
            this.y=y;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}({x},{y})";
        }

        public double Distance(Point other)
        {
            return Math.Sqrt((other.x - this.x) * (other.x - this.x) + (other.y - this.y) * (other.y - this.y));
        }
    }

    public class Cluster
    {
        public List<Point> points;

        public Cluster()
        {
            points = new List<Point>();
        }

        public Cluster(params Point[] other)
        {
            points = new List<Point>();
            foreach ( Point p in other)
            {

                points.Add(p);
            }
        }

        public override string ToString()
        {
            string list = $"{this.GetType().Name} " + "{ ";
            
            foreach (Point p in points)
            {
                list += p.ToString();
                list += " ";
            }
            list += "}";
            return list;
        }

        public double Distance ( Cluster other )
        {
            double min = this.points[0].Distance(other.points[0]);
            for ( int i = 0; i < this.points.Count; i++ )
            {
                for (int j = 0; j < other.points.Count; j++ )
                {
                    if (this.points[i].Distance(other.points[j])< min)
                    {
                        min = this.points[i].Distance(other.points[j]);
                    }
                }
            }
            return min;
            
        }

        public static Cluster operator +(Cluster a, Cluster b)
        {
            Cluster cluster = new Cluster();
            foreach (Point p in a.points)
            {
                cluster.points.Add(p);
            }

            foreach (Point p in b.points)
            {
                cluster.points.Add(p);
            }
            return cluster;
        }

        public List<Cluster> HierarchicalClustering(int k)
        {
            List<Cluster> clusters = new List<Cluster>();
            
            foreach (Point p in points)
            {
                clusters.Add(new Cluster(p));
            }

            while (clusters.Count > k)
            {
                double min = double.MaxValue;
                int indexA = -1;
                int indexB = -1;    

                for (int i = 0; i < clusters.Count; i++)
                {
                    for (int j = 0; j < clusters.Count; j++)
                    {
                        if (clusters[i].Distance(clusters[j]) < min && i != j)
                        {
                            min = clusters[i].Distance(clusters[j]);
                            indexA = i;
                            indexB = j;
                        }
                    }
                }

                clusters[indexA] = clusters[indexA] + clusters[indexB];
                clusters.RemoveAt(indexB);


                
            }
            

            return clusters;    
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 

            //In ra một điểm
            Point pointA = new Point();
            Console.WriteLine(pointA.ToString());
    
            //Khoảng cách giưa 2 điểm
            Point pointB = new Point(3,4);
            Console.WriteLine(pointB.Distance(pointA));

            //In một cluster
            Cluster clusterA = new Cluster(
                pointA, 
                pointB, 
                new Point(5,4), 
                new Point(2,2)
            );

            Console.WriteLine(clusterA.ToString());


            //Tính khoảng cách giữa 2 vector
            Cluster clusterB = new Cluster(
                new Point(7, 5),
                new Point(3, 3),
                new Point(6, 8),
                new Point(4, 2)
            );

    
            Cluster clusterC = new Cluster(
                new Point(9, 6),
                new Point(5, 5),
                new Point(8, 7),
                new Point(6, 4)
            );

            Console.WriteLine(clusterB.Distance(clusterC));


            //Cộng 2 cluster
            clusterC = clusterB + clusterC;
            Console.WriteLine(clusterC.ToString());


            //HierarchicalClustering
            Console.WriteLine("-----------------------------------------");    
            List<Cluster> hier = clusterB.HierarchicalClustering(2);
            foreach (Cluster cluster in hier)
            {
                Console.WriteLine(cluster.ToString());
            }

           
            Console.ReadKey();

        }
    }
}
