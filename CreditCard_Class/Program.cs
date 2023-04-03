namespace CreditCard_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CreditCard CC = new CreditCard("MasterCard","5626 3819 3827 1636",193,2026,1,1);
                Console.WriteLine(CC);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);}
        }
    }
}