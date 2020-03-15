using System;
using System.Collections.Generic;
using Service.DTO;

namespace Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetUser(Guid Id);
        UserDTO GetUser(string name);
        void InsertUser(UserDTO userDTO);
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(Guid Id);
        void DeleteUser(string name);
    }
}
