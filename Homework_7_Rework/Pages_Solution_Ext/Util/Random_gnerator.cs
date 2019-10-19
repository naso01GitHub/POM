using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Linq;
using AutoFixture;


namespace Framework.Util
{
    public static class Random_gnerator
    {

        public static MyClass GenerateMail_1()
        {
     
            var fixture = new Fixture();
            fixture.Customize<MyClass>(c => c.With(x =>
                          x.EmailAddress,
                          fixture.CreateMany<MailAddress>().Select(x => x.Address)));
            var result = fixture.Create<MyClass>();
            return fixture.Create<MyClass>();
        }

        public static string  GenerateMail()
        {
          
            return Guid.NewGuid().ToString().Substring(0,8)
                + "@" 
                + Guid.NewGuid().ToString().Substring(0, 4)
                +".com";
        }
    }
}
 