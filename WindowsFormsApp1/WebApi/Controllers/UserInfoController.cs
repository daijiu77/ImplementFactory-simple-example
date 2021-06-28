using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.DJ.ImplementFactory;
using System.DJ.ImplementFactory.Commons.Attrs;
using WebApi.DbInterfaces;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        [AutoCall]
        IUserInfoMapper userInfoMapper;

        public UserInfoController()
        {
            ImplementAdapter.Register(this);
        }

        [HttpPost, Route("Insert")]
        public dynamic Insert(object data)
        {
            if (null == data) return new { success = 0 };
            string dt = data.ToString();
            UserInfo ui = new UserInfo();
            ui.fromJsonUnit(dt);
            userInfoMapper.insert(ui);
            return new { success = 1 };
        }

        [HttpPost, Route("Update")]
        public dynamic Update(object data)
        {
            if (null == data) return new { success = 0 };
            string dt = data.ToString();
            UserInfo ui = new UserInfo();
            ui.fromJsonUnit(dt);
            userInfoMapper.update(ui);
            return new { success = 1 };
        }
    }
}
