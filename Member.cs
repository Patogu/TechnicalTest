using AutoFixture;
using Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestPatricia
{
    public class Member : Person
    {
        public string User { get; set; }

        public Member Random()
        {
           var mc = new Fixture().Build<Member>()
                                  .With(x => x.Username, NameFaker.Name())                                  
                                  .With(x => x.Email, "patogun+" + StringFaker.AlphaNumeric(10) + "@gmail.com")
                                  .With(x => x.Password, "Password123")
                                  .OmitAutoProperties()
                                  .Create();
           return mc;
        }



    }
}
