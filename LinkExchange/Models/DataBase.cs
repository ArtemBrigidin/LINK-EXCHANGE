using System.Collections.Generic;
using System.Linq;

namespace LinkExchange.Models
{
    public class DataBase
    {
        // Приватный статический экземпляр
        private static DataBase? _instance;
        private int _userIdCounter;

        // Приватный конструктор, чтобы предотвратить создание экземпляров извне
        private DataBase()
        {
            users = new List<UserModel>();
            links = new List<LinkModel>();
            _userIdCounter = 1;
    }

        // Публичное статическое свойство для доступа к экземпляру
        public static DataBase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataBase();
                }
                return _instance;
            }
        }

        private readonly List<UserModel> users;
        private readonly List<LinkModel> links;

        public void AddUser(UserModel user)
        {
            user.Id = _userIdCounter++;
            users.Add(user);
        }

        public void AddLink(LinkModel model)
        {
            links.Add(model);
        }

        public List<LinkModel> GetLinksList()
        {
            // Возвращаем копию списка для предотвращения прямого изменения
            return new List<LinkModel>(links);
        }

        public UserModel? GetUserById(int id)
        {
            // Используем LINQ для поиска пользователя по id
            return users.FirstOrDefault(user => user.Id == id);
        }

        public int GetNextUserId()
        {
            return _userIdCounter++;
        }

        public UserModel? GetUserByName(string username) {
            return users.FirstOrDefault(user => user.Username == username);
        }
    }
}
