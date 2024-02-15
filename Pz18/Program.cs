namespace Pz18
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            static void Main(string[] args)
            {
                // Создание объектов общественного транспорта
                PublicTransport transport1 = new PublicTransport("AB 123 CD", "Иванов Иван Иванович", TransportType.Bus, new TimeOnly(8, 0), new TimeOnly(17, 0));
                PublicTransport transport2 = new PublicTransport("AB 123 CD", "", TransportType.Bus, new TimeOnly(8, 0), new TimeOnly(17, 0));
                // Вывод информации о транспорте
                transport1.PrintInfo();
                Console.WriteLine();
                transport2.PrintInfo();
                Console.WriteLine();

                // Вывод общего количества транспорта
                PublicTransport.PrintTotalTransportCount();
            }
        }

    }
}
