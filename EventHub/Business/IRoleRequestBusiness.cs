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
    }
}
