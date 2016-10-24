using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/********************************************************************************
* Author: Svetlozar Georgiev, 40203970                                          *
* Date of last change: 08/10/2017                                               *
* Attendee Class;                                                                *
* Allows the creation of Attendee objects containing the following properties:  *
********************************************************************************/

namespace cw1_cs
{
    class Attendee
    {
        //properties of the class
        private int attendeeref;
        private string firstname;
        private string secondname;
        private string institutionname;
        private string conferencename;
        private string registrationtype;
        private bool paid;
        private bool presenter;
        private string papertitle;

        //get and set for each property + data validation 
        public int AttendeeRef
        {
            get { return attendeeref; }
            set
            {
                if(value < 40000 || value > 60000)
                {
                    throw new ArgumentException("Number must be in the range 40000 - 60000");
                } 
                attendeeref = value;
            }
        }

        public string FirstName
        {
            get { return firstname; }
            set
            {
                if(String.IsNullOrEmpty(value))
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
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Second name is a mandatory field.");
                }
                secondname = value;
            }
        }

        public string InstitutionName
        {
            get { return institutionname; }
            set { institutionname = value; }
        }

        public string ConferenceName
        {
            get { return conferencename; }
            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Conference name is a mandatory field.");
                }
                conferencename = value;
            }
        }

        public string RegistrationType
        {
            get { return registrationtype; }
            set
            {
                if(!value.Equals("full") || !value.Equals("student") || !value.Equals("organiser"))
                {
                    throw new ArgumentException("Possible values for Registration Type: full, student, organiser.");
                }
            }
        }

        public bool Paid
        {
            get { return paid; }
            set { paid = value; }
        }

        public bool Presenter
        {
            get { return presenter; }
            set { presenter = value; }
        }

        public string PaperTitle
        {
            get { return papertitle; }
            set
            {
                if((Presenter && String.IsNullOrEmpty(value)) || (!Presenter && !String.IsNullOrEmpty(value)))
                {
                    throw new ArgumentException("Paper Title does not have a valid value.");
                }
                papertitle = value;
            }
        }

        //calculate costs
        public double getCost()
        {
            double result = 0;

            if (RegistrationType.Equals("full"))
            {
                result = 500;
            } else if(RegistrationType.Equals("student"))
            {
                result = 300;
            } else
            {
                result = 0;
            }

            if(Presenter)
            {
                return result / 10;
            }
            return result;
        }
    }
}
