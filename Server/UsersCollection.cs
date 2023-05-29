using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Server
{
    public class UsersCollection
    {
        private List<KeyValuePair<User, Dictionary<string, object>>> _users = new();

        public void AddUser(User user)
        {
            _users.Add(new KeyValuePair<User, Dictionary<string, object>>(user, new()));
        }

        public KeyValuePair<User, Dictionary<string, object>>? GetPair(string login)
        {
            return UserExists(login) ? _users.First(pair => pair.Key.Login == login) : null;
        }

        public KeyValuePair<User, Dictionary<string, object>>? GetPair(User user)
        {
            return UserExists(user) ? _users.First(pair => pair.Key == user) : null;
        }

        public KeyValuePair<User, Dictionary<string, object>>? GetPair(string login, string passwordHash)
        {
            return UserExists(login, passwordHash) ? _users.FirstOrDefault(pair => pair.Key.Login == login && pair.Key.PasswordHash == passwordHash) : null;
        }

        public User? GetUser(string login)
        {
            return GetPair(login)?.Key;
        }

        public User? GetUser(string login, string passwordHash)
        {
            return GetPair(login, passwordHash)?.Key;
        }

        public User? GetUserByMetadata(string key, object value)
        {
            if (_users.Exists(pair => pair.Value.ContainsKey(key) && pair.Value[key] == value))
                return _users.First(pair => pair.Value.ContainsKey(key) && pair.Value[key] == value).Key;

            return null;
        }

        public bool UserExists(string login)
        {
            return _users.Exists(pair => pair.Key.Login == login);
        }

        public bool UserExists(User user)
        {
            return _users.Exists(pair => pair.Key == user);
        }

        public bool UserExists(string login, string passwordHash)
        {
            return _users.Exists(pair => pair.Key.Login == login && pair.Key.PasswordHash == passwordHash);
        }

        public void RemoveUser(string login)
        {
            _users.RemoveAll(pair => pair.Key.Login == login);
        }

        public void RemoveUser(User user)
        {
            _users.RemoveAll(pair => pair.Key == user);
        }
        
        public void AddUserMetadata(string login, string key, object metadata)
        {
            GetPair(login)?.Value.Add(key, metadata);
        }
        
        public void AddUserMetadata(User user, string key, object metadata)
        {
            GetPair(user)?.Value.Add(key, metadata);
        }

        public object? GetUserMetadata(string login, string key)
        {
            return GetPair(login)?.Value[key];
        }

        public void RemoveUserMetadata(string login, string key)
        {
            GetPair(login)?.Value.Remove(key);
        }
    }
}
