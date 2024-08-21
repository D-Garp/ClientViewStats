using ClientDataLibrary;
using ClientInfo = CommonModels.ClientDataModel;

namespace ClientDataConsole
{
    class Program 
    {
        static void Main(string[] args)
        {

            //Console app start
            Console.WriteLine("Hi, \n Welcome Client Data Capture. \n ");

            //will always want user input unless userer exits
            bool exit = false;
            while (!exit) {

                appDataCapture();

                Console.WriteLine("Would you like to Continue adding clients?  \n please enter (Y) if yes ");
                string toSave = Console.ReadLine();

                //exit if not yes
                if (!"Yy".Contains(toSave))
                {
                    exit=true;
                }
            }

            LocalMethods.ExitApp();
        }

        private static void appDataCapture()
        {
            ClientInfo clientInfo = new ClientInfo();
            bool Valid = false;

            //While the name entered is invalid do this alow user to input data
            while (!Valid)
            {

                clientInfo.ClientName = "";
                LocalMethods.Warning();
                Console.WriteLine("Please enter Client Name: ");
                clientInfo.ClientName = Console.ReadLine();

                //if the user entered an empty string then there is nothing to save
                if (String.IsNullOrEmpty(clientInfo.ClientName))
                    LocalMethods.ExitApp();

                //Check if name does not already exist in the database
                Valid = LocalMethods.NameIsUnique(clientInfo.ClientName);
            }

            //While the date entered is invalid do this
            while (clientInfo.DateRegistered == null)
            {
                Console.WriteLine("Enter Registration Date (yyyy/mm/dd)");
                string date = Console.ReadLine();

                if (!String.IsNullOrEmpty(date))
                {
                    //try parsing user input as date
                    try
                    {
                        clientInfo.DateRegistered = DateTime.Parse(date);
                    }
                    catch (Exception ex)
                    {
                        //clear dateRegistered
                        clientInfo.DateRegistered = null;
                        Console.WriteLine($"Entered date ({date}) is invalid\n");
                    }
                }

            }
            //While no location is entered
            while (String.IsNullOrEmpty(clientInfo.Location))
            {
                Console.WriteLine("Please enter Location: ");
                clientInfo.Location = Console.ReadLine();
            }

            //clear number of users before validating
            clientInfo.NumberOfUsers = 0;

            //while user numbers not set yet
            while (clientInfo.NumberOfUsers <= 0)
            {
                Console.WriteLine("Please enter Number of Users (Can not conatain any characters): ");
                string num = Console.ReadLine();

                //try parse input as int32
                try
                {
                    clientInfo.NumberOfUsers = Int32.Parse(num);
                }
                catch (Exception ex)
                {
                    clientInfo.NumberOfUsers = -1;
                    Console.WriteLine($"Provided integer ({num}) is invalid\n");
                }
            }
            //confirm if user is happy to save
            Console.WriteLine("Would you like to save the provide data \n please enter (Y) if yes ");
            string toSave = Console.ReadLine();

            //save if yes
            if ("Yy".Contains(toSave))
            {
                LocalMethods.Save(clientInfo);
            }

        }
    }

}

