
namespace Pages_Solution
{
    public static class FactoryDefault
    {
        public static Pattern  CreateTestModel()
        {
            return new  Pattern
            {
                FirstName        = "Firstname",
                LastName         = "Lastname",
                Gender           = (int)ExtendedMethods.Gender.Male,
                Password         = "Password",
                B_Date           = "3",
                B_Mounts         = "10",
                B_Year           = "1990",
                Final_FirstName  = "Firstname",
                Final_LastName   = "Lastname",
                Address          = "Address",
                City             = "City",
                Zip              = "60056",
                State            = "Arizona",
                Phone            = "123456789",
                PhoneType        = "12345",
                alias            = "alias",
                Country          = "United States"
            };
        }
    }
}
