﻿namespace a_zApi.DTO.ResponseDto
{
    public class FeeResponse
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }

        public decimal Dueamount { get; set; }
        public decimal Payamount { get; set; }
    }
}
