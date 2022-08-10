namespace DapperUsingWebApi_shaurya.model
{
    public class order
    {
        public int Id { get; set; }
        public int ordercode { get; set; }
        public string customername { get; set; }
        public string mobilenumber { get; set; }
        public string shippingaddress { get; set; }
        public string billingaddress { get; set; }
        public int totalorderamt { get; set; }

        public class orderForCreationDto : BaseModel
        {
            public int ordercode { get; set; }
            public string customername { get; set; }
            public string mobilenumber { get; set; }
            public string shippingaddress { get; set; }
            public string billingaddress { get; set; }
            public int totalorderamt { get; set; }
        }
        public class orderForUpdateDto : orderForCreationDto
        {
            public int Id { get; set; }
        }
    }
}
