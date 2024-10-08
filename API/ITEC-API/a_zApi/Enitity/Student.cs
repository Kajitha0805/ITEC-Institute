﻿using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace a_zApi.Enitity
{
    public class Student
    {
        public string NicNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseId {  get; set; }
        public Course Course { get; set; }
        public string Batch {  get; set; }
        public DateTime Date {  get; set; }
        public string MobileNo {  get; set; }
        public string Email {  get; set; }
        public string Address {  get; set; }
        public decimal RegFee {  get; set; }
        public decimal AdditionalFee {  get; set; }
    }
}
