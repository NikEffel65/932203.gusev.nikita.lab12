﻿namespace Web_lab_12.Models
{
    public class CalculatorResultModel
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public string Operation { get; set; }
        public double? Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}