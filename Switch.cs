class LoopProgram
{

    static void Main()
    {
        Console.WriteLine("Enter your lucky no:(enter choice in b/w 1 to 5)");
        int choice  = Convert.ToInt32(Console.ReadLine());

        switch(choice)
        {
            case 1:
                Console.WriteLine("Product is added to a cart");
                break;
            case 2:
                Console.WriteLine("Product is deleted from a cart");
                break;
            case 3:
                Console.WriteLine("Total amount to pay");
                break;
            case 4:
                Console.WriteLine("Successfully you have purchased");
                break;
            case 5:
                break;
                //default is optional
             default:
                Console.WriteLine("All Days are lucky(but you may try by entering choices b/w 1 to 5)");
                break;

        }
        
    }
}