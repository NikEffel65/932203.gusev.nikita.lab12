using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Web_lab_12.Models;

namespace Web_lab_12.Controllers
{
    public class CalcController : Controller
    {
        //Единственный метод обработки прихода на форму, а так-же выполнения submit формы. Разделение происходит по get и post.
        [HttpGet]
        [HttpPost]
        public IActionResult ManualParsingInSingleAction(CalculatorModel model)
        {

            if (Request.Method == HttpMethods.Get) // Проверяем, является ли запрос POST
            {
                return View("ManualParsingInSingleAction", model);
            }

            try
                {
                model.Operation = "+";
                // Ручной разбор значений из формы
                model.Number1 = double.Parse(Request.Form["Number1"]);
                    model.Number2 = double.Parse(Request.Form["Number2"]);
                    model.Operation = Request.Form["Operation"];
                    model.ErrorMessage = "";

                    // Выполнение операции
                    switch (model.Operation)
                    {
                        case "+":
                            model.Result = model.Number1 + model.Number2;
                            break;
                        case "-":
                            model.Result = model.Number1 - model.Number2;
                            break;
                        case "*":
                            model.Result = model.Number1 * model.Number2;
                            break;
                        case "/":
                            if (model.Number2 == 0)
                            {
                                model.ErrorMessage = "Ошибка: деление на ноль.";
                                model.Result = 0;
                            }
                            else
                            {
                                model.Result = model.Number1 / model.Number2;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    model.ErrorMessage = $"Произошла ошибка: {ex.Message}";
                }
            
            return View("ManualParsingInSingleActionResult", model);
        }

        [HttpGet]
        public IActionResult ManualParsingInSeparateActions()
        {

            ViewData["Title"] = "ManualParsingInSeparateActions";
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult ManualParsingInSeparateActionsResult()
        {
            var model = new CalculatorModel() {
                Operation = "+"
            };
            try
            {
                // Ручной разбор значений из формы
                model.Number1 = double.Parse(Request.Form["Number1"]);
                model.Number2 = double.Parse(Request.Form["Number2"]);
                model.Operation = Request.Form["Operation"];
                model.ErrorMessage = "";

                // Выполнение операции
                switch (model.Operation)
                {
                    case "+":
                        model.Result = model.Number1 + model.Number2;
                        break;
                    case "-":
                        model.Result = model.Number1 - model.Number2;
                        break;
                    case "*":
                        model.Result = model.Number1 * model.Number2;
                        break;
                    case "/":
                        if (model.Number2 == 0)
                        {
                            model.ErrorMessage = "Ошибка: деление на ноль.";
                            model.Result = 0;
                        }
                        else
                        {
                            model.Result = model.Number1 / model.Number2;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                model.ErrorMessage = $"Произошла ошибка: {ex.Message}";
            }

            return View("ManualParsingInSeparateActionsResult", model);
        }

        [HttpGet]
        public IActionResult ModelBindingInParamaters()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult ModelBindingInParamatersResult(CalculatorModel model)
        {
            try
            {
                model.ErrorMessage = "";

                // Выполнение операции
                switch (model.Operation)
                {
                    case "+":
                        model.Result = model.Number1 + model.Number2;
                        break;
                    case "-":
                        model.Result = model.Number1 - model.Number2;
                        break;
                    case "*":
                        model.Result = model.Number1 * model.Number2;
                        break;
                    case "/":
                        if (model.Number2 == 0)
                        {
                            model.ErrorMessage = "Ошибка: деление на ноль.";
                            model.Result = 0;
                        }
                        else
                        {
                            model.Result = model.Number1 / model.Number2;
                        }
                        break;
                    default:
                        model.ErrorMessage = "Неизвестная операция.";
                        break;
                }
            }
            catch (Exception ex)
            {
                model.ErrorMessage = $"Произошла ошибка: {ex.Message}";
            }

            return View("ModelBindingInParamatersResult", model);
        }

        [HttpGet]
        public IActionResult ModelBindingInSeparateModel()
        {
            return View(new CalculatorInputModel());
        }

        [HttpPost]
        public IActionResult ModelBindingInSeparateModelResult(CalculatorInputModel inputModel)
        {
            var resultModel = new CalculatorResultModel
            {
                Number1 = inputModel.Number1,
                Number2 = inputModel.Number2,
                Operation = inputModel.Operation,
                ErrorMessage = ""
            };

            try
            {
                // Выполнение операции
                switch (resultModel.Operation)
                {
                    case "+":
                        resultModel.Result = resultModel.Number1 + resultModel.Number2;
                        break;
                    case "-":
                        resultModel.Result = resultModel.Number1 - resultModel.Number2;
                        break;
                    case "*":
                        resultModel.Result = resultModel.Number1 * resultModel.Number2;
                        break;
                    case "/":
                        if (resultModel.Number2 == 0)
                        {
                            resultModel.ErrorMessage = "Ошибка: деление на ноль.";
                            resultModel.Result = 0;
                        }
                        else
                        {
                            resultModel.Result = resultModel.Number1 / resultModel.Number2;
                        }
                        break;
                    default:
                        resultModel.ErrorMessage = "Неизвестная операция.";
                        break;
                }
            }
            catch (Exception ex)
            {
                resultModel.ErrorMessage = $"Произошла ошибка: {ex.Message}";
            }

            return View("ModelBindingInSeparateModelResult", resultModel);
        }
    }
}