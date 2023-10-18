using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PhoneASPBase.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly PhoneContext _dbContext;
        public PhoneController(PhoneContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> AddPhone(Phone phone)
        {


            _dbContext.Phones.Add(phone);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet("Get Phone")]
        public async Task<ActionResult<IEnumerable<Phone>>> GetAll()
        {
            if (_dbContext.Phones == null)
                return BadRequest();

            return await _dbContext.Phones.Include(u => u.Brand).ToListAsync();
        }

        [HttpGet("Get Brands")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrand()
        {
            if (_dbContext.Brands == null)
                return BadRequest();

            return await _dbContext.Brands.ToListAsync();
        }
        [HttpGet("Get Phone by brand")]
        public async Task<ActionResult<IEnumerable<Phone>>> GetbyBrand(string brand)
        {
            if (_dbContext.Phones == null)
                return BadRequest();

            List<Phone> phonesbr = new List<Phone>();
            List<Phone> phonesall = _dbContext.Phones.Include(u => u.Brand).ToList();
            foreach (Phone phone in phonesall)
            {
                if (phone.Brand.Name.Replace(" ", "") == brand)
                    phonesbr.Add(phone);

            }


            return phonesbr;
        }

        [HttpDelete("Phone Deleted")]
        public async Task<ActionResult> DeletePhone(int id)
        {
            int idForRemove = id;
            _dbContext.Phones.Remove(_dbContext.Phones.FirstOrDefault(x => x.Id.Equals(idForRemove)));
            _dbContext.SaveChanges();
            return Ok("Phone is deleted");
        }


        [HttpGet("Get Phone Universal filter")]
        public ActionResult<IEnumerable<Phone>> GetFilterAll(int? memory, int? baterry, int? display, int? camera)
        {
            if (_dbContext.Phones == null)
                return BadRequest();

            List<Phone> phonesall = _dbContext.Phones.Include(u => u.Brand).ToList();

            List<Phone> phonesmemory = new List<Phone>();
            List<Phone> phonesbaterry = new List<Phone>();
            List<Phone> phonesdisplay = new List<Phone>();
            List<Phone> phonescamera = new List<Phone>();

            List<Phone> phonesfiltered = new List<Phone>();



            if (memory != null)
            {
                foreach (Phone phone in phonesall)
                    if (phone.Memory == memory)
                        phonesmemory.Add(phone);

            }
            else
                phonesmemory = phonesall;

            if (baterry != null)
            {
                foreach (Phone phone in phonesall)
                    if (phone.Baterry == baterry)
                        if (phone.Baterry == baterry)
                            phonesbaterry.Add(phone);

            }
            else
                phonesbaterry = phonesall;
            if (display != null)
            {
                foreach (Phone phone in phonesall)
                    if (phone.Display == display)
                        phonesdisplay.Add(phone);
            }
            else
                phonesdisplay = phonesall;

            if (camera != null)
            {
                foreach (Phone phone in phonesall)
                {
                    if (phone.Camera == camera)
                        phonescamera.Add(phone);
                }
            }
            else
                phonescamera = phonesall;


            foreach (Phone phone in phonesmemory)
            {
                foreach (Phone phone2 in phonesbaterry)
                {
                    foreach (Phone phone3 in phonesdisplay)
                    {
                        foreach (Phone phone4 in phonescamera)
                        {
                            if (phone == phone2 && phone == phone3 && phone == phone4)
                                phonesfiltered.Add(phone);

                        }
                    }
                }
            }

            return phonesfiltered;
        }

        [HttpPut("Phone Update")]
        public ActionResult PhoneUpdate(string? modename, int? memory, int? baterry, int? display, int? camera, int id)
        {

            Phone oldPhone = null;
            foreach (Phone phone in _dbContext.Phones)
            {
                if (phone.Id == id)
                    oldPhone = phone;
            }
            if (oldPhone != null)
            {
                if (modename != null) oldPhone.Model = modename;
                if (memory != null) oldPhone.Memory = (int)memory;
                if (baterry != null) oldPhone.Baterry = (int)baterry;
                if (display != null) oldPhone.Display = (int)display;
                if (camera != null) oldPhone.Camera = (int)camera;

                _dbContext.Phones.Update(oldPhone);
                _dbContext.SaveChanges();
                return Ok("Phone is update");
            }
            else
            {
                return BadRequest("Phone is not found");
            }
        }
    }

}
