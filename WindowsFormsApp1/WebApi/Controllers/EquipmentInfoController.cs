using System;
using System.Collections.Generic;
using System.DJ.ImplementFactory;
using System.DJ.ImplementFactory.Commons.Attrs;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbInterfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentInfoController : ControllerBase
    {
        [AutoCall]
        IEquipmentInfoMapper equipmentInfoMapper;

        public EquipmentInfoController()
        {
            ImplementAdapter.Register(this);
        }

        [HttpPost, Route("Insert")]
        public dynamic Insert(object data)
        {
            if (null == data) return new { success = 0 };
            string dt = data.ToString();
            EquipmentInfo ei = new EquipmentInfo();
            ei.fromJsonUnit(dt);
            equipmentInfoMapper.insert(ei);
            return new { success = 1 };
        }

        [HttpPost, Route("Update")]
        public dynamic Update(object data)
        {
            if (null == data) return new { success = 0 };
            string dt = data.ToString();
            EquipmentInfo ei = new EquipmentInfo();
            ei.fromJsonUnit(dt);
            equipmentInfoMapper.update(ei);
            return new { success = 1 };
        }
    }
}
