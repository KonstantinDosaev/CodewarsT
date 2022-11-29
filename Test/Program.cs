
using System.Dynamic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoCard card = new VideoCard("videocarta","nvidia", "1660", "2");

            Product prod = new Product("Product", "Houm", "Hand Maid");

            HardDisc hard = new HardDisc("hard", "kingston", "128", "7500");

            List<Product> list = new List<Product>(){prod, card, hard};
            //for (int i = 0; i < list.Count; i++)
            //{
            //    list[i].Print();
            //    Console.WriteLine($"\n\n");
            //}
            list[2].Print();
            Console.WriteLine(RoundBy2DecimalPlaces(22.788977m));
        }
        public static decimal RoundBy2DecimalPlaces(decimal number)
        {
            return Math.Round(number, 2);
        }
    }

    internal class Product
    {

        public string? TypProduct { get; set; }
        public string? Manufacture { get; set; }
        public string? Model { get; set; }

        public Product(string typ,string manufacture, string model)
        {
            TypProduct = typ;
            Manufacture = manufacture;
            Model = model;
        }

        public virtual void Print()
        {
            Console.WriteLine($"{TypProduct}\n{Model}\n{Manufacture}");
        }

    }

    class VideoCard : Product
    {
        public string? VideoMemory { get; set; }

        public VideoCard (string typ, string manufacture, string model, string videoMemory ) : base (typ, manufacture, model)
        {
            VideoMemory = videoMemory;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(VideoMemory);
        }
    }

    class HardDisc: Product

    {
    public string? RotationSpeed { get; set; }

        public HardDisc(string typ, string manufacture, string model, string rotationSpeed) : base(typ, manufacture, model)
        {
            RotationSpeed = rotationSpeed;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(RotationSpeed);
        }
    }

}
