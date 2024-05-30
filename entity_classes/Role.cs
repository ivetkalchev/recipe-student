using System;
using System.Collections.Generic;

namespace entity_classes
{
    public class Role
    {
        private int id;
        private string name;
        private List<Permission> permissions;

        public Role(int id, string name, List<Permission> permissions)
        {
            this.id = id;
            this.name = name;
            this.permissions = permissions;
        }

        public int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public List<Permission> GetPermissions()
        {
            return permissions;
        }

        public bool HasPermission(string permissionName)
        {
            foreach (Permission p in permissions)
            {
                if (p.GetName().Equals(permissionName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
