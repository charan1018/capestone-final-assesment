// // class ABC {

// //    public static void  Invoice()
// //     { 
// //     // definition
// //     }
// //      //Single Cast Delegate
// //     public static void Print1(int a, int b) { }
   
// //     public delegate void MyShow(); //  this delegate will point to a method
// //     public delegate void Printing();
// //     public delegate void Admin(); // Declaring a delegate

// //     static void Main(String[] args)
// //     {

// //         MyShow my = new MyShow(Show);
// //         Printing my1 = new Printing(Print);
// //         Admin a = new Admin(Invoice);// Calling a Delegate
// //         my();
// //         my1();
// //         a();
// //     }

// //     //Static method for delegate
// //     public static void Show()
// //     {
// //         Console.WriteLine("Show method called using Delegate");

// //     }

// //     //Static method for delegate
// //     public static void Print() {
// //         Console.WriteLine("Print method called using Delegate"); 
    
// //     }
// // }

// using System;

// class Admin
// {
    
//     public delegate int CalculateInvoice(int tuitionFees, int transportFees);

    
//     public delegate void PrintInvoice(int total);


//     public static int GetTotalInvoice(int tuition, int transport)
//     {
//         return tuition + transport;
//     }

//     public static void DisplayInvoice(int total)
//     {
//         Console.WriteLine("Total Invoice Amount: ₹" + total);
//     }

    
//     static void Main(string[] args)
//     {
        
//         CalculateInvoice calc = GetTotalInvoice;
//         PrintInvoice print = DisplayInvoice;

//         int tuitionFees = 60000;
//         int transportFees = 10000;

//         int total = calc(tuitionFees, transportFees);
//         print(total);
//     }
// }

using System;

class Admin
{
    // Delegate to calculate invoice
    public delegate int CalculateInvoice(int tuition, int transport);

    // Delegate to print invoice
    public delegate void PrintInvoice(int tuition, int transport, int total);

    // Method to calculate total invoice
    public static int GetTotal(int tuition, int transport)
    {
        return tuition + transport;
    }

    // Page 1: Actual invoice
    public static void PrintPage1(int tuition, int transport, int total)
    {
        Console.WriteLine("Page 1 - Actual Invoice");
        Console.WriteLine("Tuition Fees: " + tuition);
        Console.WriteLine("Transport Fees: " + transport);
        Console.WriteLine("Total: " + total);
    }

    // Page 2: 100% tuition fee deducted
    public static void PrintPage2(int tuition, int transport, int total)
    {
        Console.WriteLine("Page 2 - After Deduction");
        Console.WriteLine("Tuition Fees: " + tuition + " (100% waived)");
        Console.WriteLine("Transport Fees: " + transport);
        Console.WriteLine("Total: " + transport);
    }

    static void Main(string[] args)
    {
        // Assign methods to delegates
        CalculateInvoice calc = GetTotal;
        PrintInvoice print1 = PrintPage1;
        PrintInvoice print2 = PrintPage2;

        // Input fees
        int tuition = 40000;
        int transport = 8000;

        // Calculate total
        int total = calc(tuition, transport);

        // Print both versions
        print1(tuition, transport, total);
        Console.WriteLine();
        print2(tuition, transport, total);
    }
}