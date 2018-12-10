using System;
namespace modelSpace
{
    [System.Serializable]
    public class UserData
    {

        public int id;
        public string name;
        public string username;
        public string cell_number;
        public string email;
        public int shiptype;
        public int weapontype;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }

        }
        public string Cell_number
        {
            get { return cell_number; }
            set { cell_number = value; }

        }
        public string Email
        {

            get { return email; }
            set { email = value; }

        }

        public int Shiptype
        {

            get { return shiptype; }
            set { shiptype = value; }

        }

        public int Weapontype
        {

            get { return weapontype; }
            set { weapontype = value; }

        }




    }


}
