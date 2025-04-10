using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IRoleRequestBusiness
    {
        public Task RequestRoleChangeAsync(string userId, string description);

        public Task ApproveRoleChangeAsync(string userId);

        public Task RejectRoleChangeAsync(string userId);

        public Task<TModel> GetByUserAsync<TModel>(string userId, Func<RoleRequest, TModel> mapFunc);

        public ICollection<TModel> GetAll<TModel>(Func<RoleRequest, TModel> mapFunc);
    }
}
