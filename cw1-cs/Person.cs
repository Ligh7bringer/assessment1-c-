using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/********************************************************************************
* Author: Svetlozar Georgiev, 40203970                                          *
* Date of last change: 25/10/2016                                               *
* Person SuperClass                                                             *
* Contains names of an attendee, Attendee class inherits from it                *
********************************************************************************/

namespace cw1_cs
{
    class Person
    {
        private string firstname;
        private string secondname;

        public string FirstName
        {
            get { return firstname; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name is a mandatory field.");
                }
                firstname = value;
            }
        }

        public string SecondName
        {
            get { return secondname; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name is a mandatory field.");
                }
                secondname = value;
            }
        }
    }
}
