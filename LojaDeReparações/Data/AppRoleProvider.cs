using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LojaDeReparações.Data
{
    public class AppRoleProvider: RoleProvider
    {
        private LojaDeReparacoesContext db = new LojaDeReparacoesContext();
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                var utilizador = db.Utilizadors.Where(u => u.Email == username).First();
                if (utilizador == null) throw new Exception();
                if (utilizador.Perfil == 0)
                    return new string[] { "Administrador" };
                else if (utilizador.Perfil == 1)
                    return new string[] { "Funcionário" };
                else
                    return new string[] { "Cliente" };
            }
            catch
            {
                return new string[] { "" };
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                var utilizador = db.Utilizadors.Where(u => u.Nome == username).First();
                if (utilizador.Perfil == 0 && roleName != "Administrador")
                    throw new Exception();
                if (utilizador.Perfil == 1 && roleName != "Funcionário")
                    throw new Exception();
                if (utilizador.Perfil == 2 && roleName != "Cliente")
                    throw new Exception();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
        }

        public override bool RoleExists(string roleName)
        {
            return roleName == "Administrador" || roleName == "Funcionário" || roleName == "Cliente";
        }
    }
}