using System;
using System.Globalization;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using project.pole.Data.Base;
using project.pole.Models;

namespace project.pole.Services
{
    public class EstimateService : IEstimateService
    {
        private readonly IObjectWorkRepository _objectWorkRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPriceRepository _priceRepository;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectWorkRepository"></param>
        /// <param name="customerRepository"></param>
        /// <param name="priceRepository"></param>
        public EstimateService(IObjectWorkRepository objectWorkRepository, ICustomerRepository customerRepository, IPriceRepository priceRepository)
        {
            _objectWorkRepository = objectWorkRepository;
            _customerRepository   = customerRepository;
            _priceRepository      = priceRepository;
        }

        /// <summary>
        /// Generates a estimate file
        /// </summary>
        /// <returns>Byte estimate file</returns>
        public byte[] Generate(long objectWorkId)
        {
            try
            {
                var objectWork = _objectWorkRepository.Find(objectWorkId, false);
                var prices = _priceRepository.FindAll(false);
                var customerName = _customerRepository.Find(objectWork.CustomerId).Name;

                byte[] outFile;
                using (var excel =  new ExcelPackage(new FileStream(
                    @$"{Directory.GetCurrentDirectory()}\wwwroot\estimate\layout.xlsx",
                    FileMode.Open)))
                {
                    var worksheets = excel.Workbook.Worksheets[0];

                    var culture = CultureInfo.GetCultureInfo("ru-RU");
                    
                    //исполнитель
                    worksheets.Cells[7, 7].Value = "ООО ГеоГрадСтрой";
                    //заказчик
                    worksheets.Cells[8, 7].Value = customerName;
                    //площадь участка
                    worksheets.Cells[9, 7].Value = objectWork.PlotArea.ToString(culture);
                    //площадь зданий
                    worksheets.Cells[10, 7].Value = objectWork.BuildingArea.ToString(culture);
                    //глубина котлована
                    worksheets.Cells[11, 7].Value = objectWork.PitDepth.ToString(culture);

                    //18. Бактериология
                    var quantityBacteriology = objectWork.PlotArea * 2;
                    worksheets.Cells[52, 7].Value = quantityBacteriology.ToString(culture);
                    var priceBacteriology =
                        prices.FirstOrDefault(x => x.TypePrice == TypePrice.Bacteriology).PriceValue;
                    worksheets.Cells[52, 9].Value = priceBacteriology.ToString(culture);
                    var sumBacteriology = quantityBacteriology * quantityBacteriology;
                    worksheets.Cells[52, 10].Value = sumBacteriology.ToString(culture);

                    //1. Отбор поверхностных проб грунта
                    var quantitySamplingSurfaceSoilSamples = objectWork.PlotArea * 6 + quantityBacteriology;
                    worksheets.Cells[16, 7].Value = quantityBacteriology.ToString(culture);
                    var priceSamplingSurfaceSoilSamples = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.SamplingSurfaceSoilSamples).PriceValue;
                    worksheets.Cells[16, 9].Value = priceSamplingSurfaceSoilSamples.ToString(culture);
                    var sumSamplingSurfaceSoilSamples =
                        quantitySamplingSurfaceSoilSamples * priceSamplingSurfaceSoilSamples * 0.85;
                    worksheets.Cells[16, 10].Value = sumSamplingSurfaceSoilSamples.ToString(culture);

                    //2. Отбор грунта из скважин на гаммо-спектометрию
                    double meterWell = objectWork.PitDepth + 10; //метраж скважины

                    double? quantitySamplingSoilFromWellsGammaSpectrometry;

                    switch (meterWell)
                    {
                        case >= 11 and < 15:
                            quantitySamplingSoilFromWellsGammaSpectrometry = 6;
                            break;
                        case 15:
                            quantitySamplingSoilFromWellsGammaSpectrometry = 7;
                            break;
                        case > 15 and < 20:
                            quantitySamplingSoilFromWellsGammaSpectrometry = 8;
                            break;
                        case >= 20:
                            quantitySamplingSoilFromWellsGammaSpectrometry = 9;
                            break;
                        default:
                            quantitySamplingSoilFromWellsGammaSpectrometry = 5;
                            break;
                    }
                    
                    worksheets.Cells[19, 7].Value = quantitySamplingSoilFromWellsGammaSpectrometry;
                    var priceSamplingSoilFromWellsGammaSpectrometry = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.SamplingSoilFromWellsGammaSpectrometry).PriceValue;
                    worksheets.Cells[19, 9].Value = priceSamplingSoilFromWellsGammaSpectrometry;
                    worksheets.Cells[19, 10].Value = quantitySamplingSoilFromWellsGammaSpectrometry * priceSamplingSoilFromWellsGammaSpectrometry * 0.85;
                    
                    //Отбор грунта из скважин на сонетарно-химическое обследование
                    double quantitySoilSamplingFromWellsFsanitaryAndChemicalInspection = objectWork.PitDepth;
                    var priceSoilSamplingFromWellsFsanitaryAndChemicalInspection = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.SoilSamplingFromWellsFsanitaryAndChemicalInspection).PriceValue;
                    worksheets.Cells[20, 7].Value = quantitySoilSamplingFromWellsFsanitaryAndChemicalInspection;
                    worksheets.Cells[20, 9].Value = priceSoilSamplingFromWellsFsanitaryAndChemicalInspection;
                    worksheets.Cells[20, 10].Value = quantitySoilSamplingFromWellsFsanitaryAndChemicalInspection * priceSoilSamplingFromWellsFsanitaryAndChemicalInspection * 0.85;

                    //y-съемка(полевые работы)
                    var quantityGammasHooting = objectWork.PlotArea;
                    worksheets.Cells[24, 7].Value = quantityGammasHooting;
                    var priceGammasHootingFieldWork = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.GammasHootingFieldWork).PriceValue;
                    worksheets.Cells[24, 9].Value = priceGammasHootingFieldWork;
                    worksheets.Cells[24, 10].Value = quantityGammasHooting * priceGammasHootingFieldWork;

                    //y-съемка(камеральные работы)
                    worksheets.Cells[25, 7].Value = quantityGammasHooting;
                    var priceGammasHootingDeskWork = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.GammasHootingDeskWork).PriceValue;
                    worksheets.Cells[25, 9].Value = priceGammasHootingDeskWork;
                    worksheets.Cells[25, 10].Value = priceGammasHootingDeskWork * quantityGammasHooting;
                     
                    //y-спектометрия
                    var quantityGammaSpectrometry = objectWork.PlotArea * 6;
                    worksheets.Cells[27, 7].Value = quantityGammaSpectrometry;
                    var priceGammaSpectrometry = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.GammaSpectrometry).PriceValue;
                    worksheets.Cells[27, 9].Value = priceGammaSpectrometry;
                    worksheets.Cells[27, 10].Value = quantityGammaSpectrometry * priceGammaSpectrometry;

                    //Измерение плотности потока радона из грунта
                    var quantityMeasurementRadonFluxDensityCalculation = objectWork.BuildingArea / 200;
                    var quantityMeasurementRadonFluxDensity = quantityMeasurementRadonFluxDensityCalculation < 20
                        ? 20
                        : quantityMeasurementRadonFluxDensityCalculation;
                    
                    if (!objectWork.Track)
                    {
                        //Полевые работы
                        worksheets.Cells[30, 7].Value = quantityMeasurementRadonFluxDensity;
                        var priceMeasurementRadonFluxDensityFromGroundFieldWork = prices
                            .FirstOrDefault(x => x.TypePrice == TypePrice.MeasurementRadonFluxDensityFromGroundFieldWork).PriceValue;
                        worksheets.Cells[30, 9].Value = priceMeasurementRadonFluxDensityFromGroundFieldWork;
                        worksheets.Cells[30, 10].Value = priceMeasurementRadonFluxDensityFromGroundFieldWork * quantityMeasurementRadonFluxDensity * 1.1 * 0.85;

                        //камеральные работы
                        worksheets.Cells[31, 7].Value = quantityMeasurementRadonFluxDensity;
                        var priceMeasurementRadonFluxDensityFromGroundDeskWork = prices
                            .FirstOrDefault(x => x.TypePrice == TypePrice.MeasurementRadonFluxDensityFromGroundDeskWork).PriceValue;
                        worksheets.Cells[31, 9].Value = priceMeasurementRadonFluxDensityFromGroundDeskWork;
                        worksheets.Cells[31, 10].Value = priceMeasurementRadonFluxDensityFromGroundDeskWork * quantityMeasurementRadonFluxDensity;

                        //бета-спектрометрия
                        worksheets.Cells[32, 7].Value = quantityMeasurementRadonFluxDensity;
                        var priceMeasurementRadonFluxDensityFromGroundBetaSpectrometry = prices
                            .FirstOrDefault(x => x.TypePrice == TypePrice.MeasurementRadonFluxDensityFromGroundBetaSpectrometry).PriceValue;
                        worksheets.Cells[31, 9].Value = priceMeasurementRadonFluxDensityFromGroundDeskWork;
                        worksheets.Cells[32, 9].Value = priceMeasurementRadonFluxDensityFromGroundBetaSpectrometry;
                        worksheets.Cells[32, 10].Value = priceMeasurementRadonFluxDensityFromGroundBetaSpectrometry * quantityMeasurementRadonFluxDensity;
                    }
                    
                    //Пробоподготовка
                    // worksheets.Cells[34, 7] = quantity_6;
                    // worksheets.Cells[34, 9] = price_6;
                    // worksheets.Cells[34, 10] = sum_6;
                    
                    
                    // worksheets.Cells[35, 7] = quantity_6;
                    // worksheets.Cells[35, 9] = price_7;
                    // worksheets.Cells[35, 10] = sum_7;
                    //
                    // worksheets.Cells[36, 7] = quantity_6;
                    // worksheets.Cells[36, 9] = price_8;
                    // worksheets.Cells[36, 10] = sum_8;
                    //
                    // worksheets.Cells[37, 7] = quantity_6;
                    // worksheets.Cells[37, 9] = price_9;
                    // worksheets.Cells[37, 10] = sum_9;
                    //
                    // worksheets.Cells[38, 10] = sum_10;
                    //
                    // worksheets.Cells[39, 10] = sum_11;
                    //
                    // worksheets.Cells[41, 10] = sum_12;
                    //
                    // worksheets.Cells[43, 10] = sum_13;
                    //
                    // worksheets.Cells[44, 10] = sum_14;
                    //
                    // worksheets.Cells[45, 10] = sum_15;
                    //
                    // worksheets.Cells[48, 10] = sum_16;
                    //
                    // worksheets.Cells[50, 10] = sum_17;
                    //
                    // worksheets.Cells[54, 9] = sum_19;
                    // worksheets.Cells[54, 10] = 0;
                    //
                    // worksheets.Cells[55, 9] = sum_20;
                    // worksheets.Cells[55, 10] = 0;
                    //
                    // worksheets.Cells[57, 10] = sum_21;
                    //
                    // worksheets.Cells[58, 10] = sum_22;
                    //
                    // worksheets.Cells[59, 10] = sum_23;
                    //
                    // worksheets.Cells[60, 9] = "20%";
                    // worksheets.Cells[60, 10] = sum_24;
                    //
                    // worksheets.Cells[61, 10] = sum_25;
                    //
                    // worksheets.Cells[50, 11] = textNote;
                    // worksheets.Cells[50, 7] = textTotal;

                    outFile = excel.GetAsByteArray();
                }

                return outFile;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}