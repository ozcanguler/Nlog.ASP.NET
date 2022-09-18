using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        Random random = new Random();
        List<User> userList = new List<User>();

        public Service1()
        {
            User u1 = new User(1, "Fred", true, 88000,GetSomeRandomScores(random));
            User u2 = new User(2, "Wilma", true, 44000, GetSomeRandomScores(random));
            User u3 = new User(3, "Barney", false, 58000, GetSomeRandomScores(random));
            User u4 = new User(4, "Betty", true, 18000, GetSomeRandomScores(random));
            User u5 = new User(5, "Pebbles", false, 5800, GetSomeRandomScores(random));
            User u6 = new User(6, "BamBam", true, 88, GetSomeRandomScores(random));

            userList.Add(u1);
            userList.Add(u2);
            userList.Add(u3);
            userList.Add(u4);
            userList.Add(u5);
            userList.Add(u6);


        }
        private static List<int> GetSomeRandomScores(Random r)
        {
            List<int> listOfScores = new List<int>();
            for (int i = 0; i < r.Next(10); i++)
            {
                listOfScores.Add(r.Next(100));
            }
            return listOfScores;
        }

        public UserDTO GetAllUsers()
        {
            UserDTO userDTO = new UserDTO();
            userDTO.MessageCode = 1;
            userDTO.MessageText = "everybody is here";
            userDTO.userList = userList;
            return userDTO;
        }
        //public List<User> GetAllUsers()
        //{
        //    return userList;
        //}
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        //public List<User> GetUserById(string id)
        public UserDTO GetUserById(string id)
        {
            UserDTO userDTO = new UserDTO();
            List<User> returnThisPerson = userList.Where(x =>x.Id==int.Parse(id)).ToList();
            userDTO.userList = returnThisPerson;
            userDTO.MessageCode = returnThisPerson.Count;
            userDTO.MessageText = "The people who have a " + id + " as their number";
            return userDTO;
        }

        //public List<User> GetUsersByName(string name)
        public UserDTO GetUsersByName(string name)
        {
            UserDTO userDTO = new UserDTO();
            List<User> returnThesePeople = userList.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
            userDTO.userList = returnThesePeople;
            userDTO.MessageCode = returnThesePeople.Count;
            userDTO.MessageText = "The people who have a " + name + " in their name";
            return userDTO;
        }
    }
}
