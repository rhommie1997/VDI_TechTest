// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");



using System.Data.SqlClient;

public class Customer
{
    public String Tipe_Customer { get; set; }
    public double Point_Reward { get; set; }
    public double TOTAL_BELANJA { get; set; }
    public double Diskon { get; set; }
    public double TotalBayar { get; set; }

}

public class Program
{

    void case_1()
    {
        String input, a;
        Console.Write("Input : ");
        input = Console.ReadLine();

        if (String.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input cant be Empty !");
        }
        else
        {
            if (input.Length % 2 == 0)
            {
                Console.Write("Output : ");
                a = input.Substring(0, input.Length / 2);
                a = String.Join(" ",
                    a.Split('#')
                    .Select(x => new String(x.Reverse().ToArray())));
                Console.Write(a);
                a = input.Substring(input.Length / 2, input.Length / 2);
                a = String.Join(" ",
                    a.Split('#')
                    .Select(x => new String(x.Reverse().ToArray())));
                Console.Write(a);
            }
            else
            {
                Console.Write("Output : ");
                a = input.Substring(0, input.Length / 2);
                a = String.Join(" ",
                    a.Split('#')
                    .Select(x => new String(x.Reverse().ToArray())));
                Console.Write(a);

                a = input.Substring(input.Length / 2,1);
                Console.Write(a);

                a = input.Substring(input.Length / 2+1, input.Length / 2);
                a = String.Join(" ",
                    a.Split('#')
                    .Select(x => new String(x.Reverse().ToArray())));
                Console.Write(a);
            }
        }
    }

    void case_2()
    {
        String input_1,input_2;
        bool isError = false;
        List<String> firstWords = new List<string>();
        List<String> secondWords = new List<string>();
        int total = 0;
        
        do
        {
            try
            {
                Console.Write("Input Total words : ");
                total = Convert.ToInt32(Console.ReadLine());
                isError = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Input should be Number !!");
                isError = true;
            }
        } while (isError == true);

        for(int i = 1; i <= total; i++)
        {
            Console.Write("Input First Word "+i+" : ");
            input_1 = Console.ReadLine();
            firstWords.Add(input_1);
        }
        Console.WriteLine("");
        Console.Write("First Words : ");
        for (int i = 0; i < total; i++)
        {
            if (i == total - 1)
            {
                Console.Write("\u0022" + firstWords[i] + "\u0022");
            }
            else
            {
                Console.Write("\u0022" + firstWords[i] + "\u0022,");
            }
        }

        Console.WriteLine("");
        Console.WriteLine("");

        for (int i = 1; i <= total; i++)
        {
            Console.Write("Input Second Word " + i + " : ");
            input_2 = Console.ReadLine();
            secondWords.Add(input_2);
        }
        Console.WriteLine("");
        Console.Write("Second Words : ");
        for (int i = 0; i < total; i++)
        {
            if (i == total - 1)
            {
                Console.Write("\u0022" + secondWords[i] + "\u0022");
            }
            else
            {
                Console.Write("\u0022" + secondWords[i] + "\u0022,");
            }
        }

        Console.WriteLine("");
        Console.WriteLine("");
        Console.Write("Output : ");
        for(int i=0;i< total; i++)
        {
            char[] ch1 = firstWords[i].ToLower().ToCharArray();
            char[] ch2 = secondWords[i].ToLower().ToCharArray();

            Array.Sort(ch1);
            Array.Sort(ch2);

            String val1 = new String(ch1);
            String val2 = new String(ch2);

            if (val1 == val2)
            {
                Console.Write("1");
            }
            else
            {
                Console.Write("0");
            }
        }

        Console.WriteLine("");

        
    }


    double calculateDiskon(String Tipe_Customer, double Point_Reward, double TOTAL_BELANJA)
    {

        double calculate = 0;

        if(Tipe_Customer != "platinum" && Tipe_Customer != "gold" && Tipe_Customer != "silver")
        {
            Console.WriteLine("");
            Console.WriteLine("Validation : Type Customer should be between platinum, gold, silver");
            Console.WriteLine("It will return 0");
            Console.WriteLine("");
            return 0;
        }

        if (Point_Reward < 100)
        {
            Console.WriteLine("");
            Console.WriteLine("Validation : point reward must be greater than or equal to 100");
            Console.WriteLine("It will return 0");
            Console.WriteLine("");
            return 0;
        }
        else
        {
            if (Tipe_Customer == "platinum")
            {
                if (Point_Reward > 100 && Point_Reward < 300)
                {
                    calculate = TOTAL_BELANJA * 50 / 100 + 35;
                    return calculate;
                }
                else if (Point_Reward > 301 && Point_Reward < 500)
                {
                    calculate = TOTAL_BELANJA * 50 / 100 + 50;
                    return calculate;
                }
                else
                {
                    calculate = TOTAL_BELANJA * 50 / 100 + 68;
                    return calculate;
                }
            }
            else if(Tipe_Customer == "gold")
            {
                if (Point_Reward > 100 && Point_Reward < 300)
                {
                    calculate = TOTAL_BELANJA * 25 / 100 + 25;
                    return calculate;
                }
                else if (Point_Reward > 301 && Point_Reward < 500)
                {
                    calculate = TOTAL_BELANJA * 25 / 100 + 34;
                    return calculate;
                }
                else
                {
                    calculate = TOTAL_BELANJA * 25 / 100 + 52;
                    return calculate;
                }
            }
            else
            {
                if (Point_Reward > 100 && Point_Reward < 300)
                {
                    calculate = TOTAL_BELANJA * 10 / 100 + 12;
                    return calculate;
                }
                else if (Point_Reward > 301 && Point_Reward < 500)
                {
                    calculate = TOTAL_BELANJA * 10 / 100 + 27;
                    return calculate;
                }
                else
                {
                    calculate = TOTAL_BELANJA * 10 / 100 + 39;
                    return calculate;
                }
            }
        }
    }
    
    void insertToDb(Customer customer)
    {
        string connectionString = "Data Source=DESKTOP-TJQ5RPI;Initial Catalog=VDI_TechTest;Integrated Security=True";

        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();
        SqlCommand comm = new SqlCommand("select count(1) from Transactions", conn);
        int count = (int)comm.ExecuteScalar();

        String formatStr = DateTime.Now.ToString("yyyyMMdd" + "_" + (count + 1).ToString("00000"));

        comm = new SqlCommand("insert into transactions values(@id,@Tipe_Customer,@Point_Reward,@TOTAL_BELANJA,@Diskon,@TotalBayar)",conn);
        comm.Parameters.AddWithValue("@id", formatStr);
        comm.Parameters.AddWithValue("@Tipe_Customer", customer.Tipe_Customer);
        comm.Parameters.AddWithValue("@Point_Reward", customer.Point_Reward);
        comm.Parameters.AddWithValue("@TOTAL_BELANJA", customer.TOTAL_BELANJA);
        comm.Parameters.AddWithValue("@Diskon", customer.Diskon);
        comm.Parameters.AddWithValue("@TotalBayar", customer.TotalBayar);
        comm.ExecuteNonQuery();

        conn.Close();



    }
    
    void case_3()
    {
        //double a = 100.4552;

        Customer customer = new Customer();

        Console.Write("Input Tipe Customer : ");
        customer.Tipe_Customer = Console.ReadLine();
        Console.Write("Input Point Reward [Must be Number] : ");
        customer.Point_Reward = Convert.ToDouble(Console.ReadLine());
        Console.Write("Input Point Reward [Must be Number] : ");
        customer.TOTAL_BELANJA = Convert.ToDouble(Console.ReadLine());

        customer.Diskon = calculateDiskon(customer.Tipe_Customer, customer.Point_Reward, customer.TOTAL_BELANJA);

        customer.TotalBayar = customer.TOTAL_BELANJA - customer.Diskon;

        Console.WriteLine("");
        Console.WriteLine("Tipe Customer : " + customer.Tipe_Customer);
        Console.WriteLine("Point Reward  : " + customer.Point_Reward);
        Console.WriteLine("Total Belanja : " + customer.TOTAL_BELANJA);
        Console.WriteLine("Diskon        : " + customer.Diskon);
        Console.WriteLine("Total Bayar   : " + customer.TotalBayar);
        Console.WriteLine("");

        insertToDb(customer);

        Console.WriteLine("");
        Console.WriteLine("Data will inserted to our Database !!");
        Console.WriteLine("");




        //Console.WriteLine(string.Format("{0:.00}", a));
    }

    
    public static void Main(string[] args)
    {
        //Console.WriteLine("Hello, Bray !!");
        int menu = 0;
        Program program = new Program();
        do
        {
            Console.Clear();
            Console.WriteLine("Select Case : ");
            Console.WriteLine("1. Case 1");
            Console.WriteLine("2. Case 2");
            Console.WriteLine("3. Case 3");
            Console.WriteLine("4. Exit");
            do
            {
                Console.Write(">> ");
                menu = Convert.ToInt32(Console.ReadLine());
            } while (menu < 1 || menu > 4);

            
            if (menu == 1)
            {
                Console.Clear();
                program.case_1();
            }
            else if (menu == 2)
            {
                Console.Clear();
                program.case_2();
            }
            else if (menu == 3)
            {
                Console.Clear();
                program.case_3();
            }
            if (menu != 4)
            {
                Console.ReadLine();
            }
        } while (menu != 4);
    }

}
