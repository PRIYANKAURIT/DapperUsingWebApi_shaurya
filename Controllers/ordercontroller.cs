using DapperUsingWebApi_shaurya.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using static DapperUsingWebApi_shaurya.model.order;

namespace DapperUsingWebApi_shaurya.Controllers
{
    
        [Route("api/order")]
        [ApiController]
        public class ordercontroller : Controller
        {
            private readonly IorderRepository _orderRepo;
            public ordercontroller(IorderRepository orderRepo)
            {
                this._orderRepo = orderRepo;
            }
            [HttpGet]
            public async Task<IActionResult> GetOrders()
            {
                try
                {
                    var d_order = await _orderRepo.GetOrders();
                    return Ok(d_order);
                }
                catch (Exception ex)
                {
                    //log error
                    return StatusCode(500, ex.Message);
                }
            }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOrderById(int Id)
        {
            try
            {
                var d_order = await _orderRepo.GetOrderById(Id);
                return Ok(d_order);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Createorder(orderForCreationDto order)
        {
            try
            {
                var result = await _orderRepo.Createorder(order);

                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Inserted Successfuly with compnay Id {0}", result));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Updateorder(orderForUpdateDto order)
        {
            try
            {
                var result = await _orderRepo.Updateorder(order);
                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Updated Successfuly"));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteorder(int id)
        {
            try
            {
                var result = await _orderRepo.Deleteorder(id);
                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Deleted Successfuly"));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
