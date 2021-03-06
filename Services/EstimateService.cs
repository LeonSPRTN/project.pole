using System;
using System.Collections.Generic;
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
        private readonly ISettingEstimateRepository _settingEstimateRepository;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectWorkRepository"></param>
        /// <param name="customerRepository"></param>
        /// <param name="priceRepository"></param>
        /// /// <param name="settingEstimateRepository"></param>
        public EstimateService(
            IObjectWorkRepository objectWorkRepository, 
            ICustomerRepository customerRepository, 
            IPriceRepository priceRepository, 
            ISettingEstimateRepository settingEstimateRepository)
        {
            _objectWorkRepository      = objectWorkRepository;
            _customerRepository        = customerRepository;
            _priceRepository           = priceRepository;
            _settingEstimateRepository = settingEstimateRepository;
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
                var settingEstimate = _settingEstimateRepository.Find(false);
                var customerName = _customerRepository.Find(objectWork.CustomerId).Name;

                byte[] outFile;
                using (var excel =  new ExcelPackage(new FileStream(
                    @$"{Directory.GetCurrentDirectory()}\wwwroot\estimate\layout.xlsx",
                    FileMode.Open)))
                {
                    var worksheets = excel.Workbook.Worksheets[0];

                    var culture = CultureInfo.GetCultureInfo("ru-RU");

                    //?????????? ??????????????????. ?????????????????? ?? ???????? ???????????? ?????????????????????? ?????????? ?????? ???? ???? ???????????????????? ?????????? ?? ????????????
                    List<double> fullSum = new();
                    
                    //??????????????????????
                    worksheets.Cells[7, 7].Value = "?????? ????????????????????????";
                    //????????????????
                    worksheets.Cells[8, 7].Value = customerName;
                    //?????????????? ??????????????
                    worksheets.Cells[9, 7].Value = objectWork.PlotArea.ToString(culture);
                    //?????????????? ????????????
                    worksheets.Cells[10, 7].Value = objectWork.BuildingArea.ToString(culture);
                    //?????????????? ??????????????????
                    worksheets.Cells[11, 7].Value = objectWork.PitDepth.ToString(culture);

                    //??????????????????????????
                    var quantityBacteriology = objectWork.PlotArea * 2;
                    worksheets.Cells[52, 7].Value = quantityBacteriology;
                    
                    var priceBacteriology =
                        prices.FirstOrDefault(x => x.TypePrice == TypePrice.Bacteriology).PriceValue;
                    worksheets.Cells[52, 9].Value = priceBacteriology;
                    
                    var sumBacteriology = quantityBacteriology * quantityBacteriology;
                    worksheets.Cells[52, 10].Value = sumBacteriology;
                    fullSum.Add(sumBacteriology);
                    
                    //?????????? ?????????????????????????? ???????? ????????????
                    var quantitySamplingSurfaceSoilSamples = objectWork.PlotArea * 6 + quantityBacteriology;
                    worksheets.Cells[16, 7].Value = quantityBacteriology;
                    
                    var priceSamplingSurfaceSoilSamples = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.SamplingSurfaceSoilSamples).PriceValue;
                    worksheets.Cells[16, 9].Value = priceSamplingSurfaceSoilSamples;
                    
                    var sumSamplingSurfaceSoilSamples =
                        quantitySamplingSurfaceSoilSamples * priceSamplingSurfaceSoilSamples * 0.85;
                    worksheets.Cells[16, 10].Value = sumSamplingSurfaceSoilSamples;
                    fullSum.Add(sumSamplingSurfaceSoilSamples);
                    
                    //?????????? ???????????? ???? ?????????????? ???? ??????????-????????????????????????
                    double meterWell = objectWork.PitDepth + 10; //???????????? ????????????????

                    double quantitySamplingSoilFromWellsGammaSpectrometry;

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

                    var sumSamplingSoilFromWellsGammaSpectrometry = quantitySamplingSoilFromWellsGammaSpectrometry *
                                                                    priceSamplingSoilFromWellsGammaSpectrometry * 0.85;
                    worksheets.Cells[19, 10].Value = sumSamplingSoilFromWellsGammaSpectrometry;
                    fullSum.Add(sumSamplingSoilFromWellsGammaSpectrometry);
                    
                    //?????????? ???????????? ???? ?????????????? ???? ??????????????????-???????????????????? ????????????????????????
                    double quantitySoilSamplingFromWellsFsanitaryAndChemicalInspection = objectWork.PitDepth;
                    worksheets.Cells[20, 7].Value = quantitySoilSamplingFromWellsFsanitaryAndChemicalInspection;
                    
                    var priceSoilSamplingFromWellsFsanitaryAndChemicalInspection = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.SoilSamplingFromWellsFsanitaryAndChemicalInspection).PriceValue;
                    
                    worksheets.Cells[20, 9].Value = priceSoilSamplingFromWellsFsanitaryAndChemicalInspection;

                    var sumSoilSamplingFromWellsFsanitaryAndChemicalInspection =
                        quantitySoilSamplingFromWellsFsanitaryAndChemicalInspection *
                        priceSoilSamplingFromWellsFsanitaryAndChemicalInspection * 0.85;
                    worksheets.Cells[20, 10].Value = sumSoilSamplingFromWellsFsanitaryAndChemicalInspection;
                    fullSum.Add(sumSoilSamplingFromWellsFsanitaryAndChemicalInspection);
                    
                    
                    //y-????????????(?????????????? ????????????)
                    var quantityGammasHooting = objectWork.PlotArea;
                    worksheets.Cells[24, 7].Value = quantityGammasHooting;
                    
                    var priceGammasHootingFieldWork = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.GammasHootingFieldWork).PriceValue;
                    worksheets.Cells[24, 9].Value = priceGammasHootingFieldWork;

                    var sumGammasHootingFieldWork = quantityGammasHooting * priceGammasHootingFieldWork;
                    worksheets.Cells[24, 10].Value = sumGammasHootingFieldWork;
                    fullSum.Add(sumGammasHootingFieldWork);

                    //y-????????????(?????????????????????? ????????????)
                    worksheets.Cells[25, 7].Value = quantityGammasHooting;
                    
                    var priceGammasHootingDeskWork = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.GammasHootingDeskWork).PriceValue;
                    worksheets.Cells[25, 9].Value = priceGammasHootingDeskWork;

                    var sumGammasHootingDeskWork = priceGammasHootingDeskWork * quantityGammasHooting;
                    worksheets.Cells[25, 10].Value = sumGammasHootingDeskWork;
                    fullSum.Add(sumGammasHootingDeskWork); 
                    
                    //y-????????????????????????
                    var quantityGammaSpectrometry = objectWork.PlotArea * 6;
                    worksheets.Cells[27, 7].Value = quantityGammaSpectrometry;
                    
                    var priceGammaSpectrometry = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.GammaSpectrometry).PriceValue;
                    worksheets.Cells[27, 9].Value = priceGammaSpectrometry;

                    var sumGammaSpectrometry = quantityGammaSpectrometry * priceGammaSpectrometry;
                    worksheets.Cells[27, 10].Value = sumGammaSpectrometry;
                    fullSum.Add(sumGammaSpectrometry); 
                    
                    //?????????????????? ?????????????????? ???????????? ???????????? ???? ????????????
                    #region MeasurementOfRadonFluxDensityFromTheGround 

                    var quantityMeasurementRadonFluxDensityCalculation = objectWork.BuildingArea / 200;
                    var quantityMeasurementRadonFluxDensity = quantityMeasurementRadonFluxDensityCalculation < 20
                        ? 20
                        : quantityMeasurementRadonFluxDensityCalculation;

                    double sumMeasurementRadonFluxDensityFromGroundFieldWork = 0;
                    double sumMeasurementRadonFluxDensityFromGroundDeskWork = 0;
                    double sumMeasurementRadonFluxDensityFromGroundBetaSpectrometry = 0;
                    
                    if (!objectWork.Track)
                    {
                        //?????????????? ????????????
                        worksheets.Cells[30, 7].Value = quantityMeasurementRadonFluxDensity;
                        
                        var priceMeasurementRadonFluxDensityFromGroundFieldWork = prices
                            .FirstOrDefault(x => x.TypePrice == TypePrice.MeasurementRadonFluxDensityFromGroundFieldWork).PriceValue;
                        worksheets.Cells[30, 9].Value = priceMeasurementRadonFluxDensityFromGroundFieldWork;
                        sumMeasurementRadonFluxDensityFromGroundFieldWork = priceMeasurementRadonFluxDensityFromGroundFieldWork * quantityMeasurementRadonFluxDensity * 1.1 * 0.85;
                        worksheets.Cells[30, 10].Value = sumMeasurementRadonFluxDensityFromGroundFieldWork;
                        fullSum.Add(sumMeasurementRadonFluxDensityFromGroundFieldWork); 
                        
                        //?????????????????????? ????????????
                        worksheets.Cells[31, 7].Value = quantityMeasurementRadonFluxDensity;
                        
                        var priceMeasurementRadonFluxDensityFromGroundDeskWork = prices
                            .FirstOrDefault(x => x.TypePrice == TypePrice.MeasurementRadonFluxDensityFromGroundDeskWork).PriceValue;
                        worksheets.Cells[31, 9].Value = priceMeasurementRadonFluxDensityFromGroundDeskWork;
                        sumMeasurementRadonFluxDensityFromGroundDeskWork = priceMeasurementRadonFluxDensityFromGroundDeskWork * quantityMeasurementRadonFluxDensity;
                        worksheets.Cells[31, 10].Value = sumMeasurementRadonFluxDensityFromGroundDeskWork;
                        fullSum.Add(sumMeasurementRadonFluxDensityFromGroundDeskWork); 
                        
                        //????????-??????????????????????????
                        worksheets.Cells[32, 7].Value = quantityMeasurementRadonFluxDensity;
                        
                        var priceMeasurementRadonFluxDensityFromGroundBetaSpectrometry = prices
                            .FirstOrDefault(x => x.TypePrice == TypePrice.MeasurementRadonFluxDensityFromGroundBetaSpectrometry).PriceValue;
                        worksheets.Cells[31, 9].Value = priceMeasurementRadonFluxDensityFromGroundBetaSpectrometry;
                        sumMeasurementRadonFluxDensityFromGroundBetaSpectrometry = priceMeasurementRadonFluxDensityFromGroundBetaSpectrometry * quantityMeasurementRadonFluxDensity;
                        worksheets.Cells[32, 10].Value = sumMeasurementRadonFluxDensityFromGroundBetaSpectrometry;
                        fullSum.Add(sumMeasurementRadonFluxDensityFromGroundBetaSpectrometry);
                    }

                    #endregion
                    //?????????? ?????????????????? ?????????????????? ???????????? ???????????? ???? ????????????
                    
                    //?????????? ???????????????????? ?????? ??????????????????????????????, ?????????????????????? ?????????????? ????????????????,
                    //?????????????????????? ???????????????????????????? ?? ?????????????????????? ??????????????????????
                    var qiantity = objectWork.PitDepth + quantityBacteriology; 
                        
                    //??????????????????????????????
                    worksheets.Cells[34, 7].Value = qiantity;
                    var priceSamplePreparation = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.SamplePreparation).PriceValue;
                    worksheets.Cells[34, 9].Value = priceSamplePreparation;

                    var sumSamplePreparation = qiantity * priceSamplePreparation;
                    worksheets.Cells[34, 10].Value = sumSamplePreparation;
                    fullSum.Add(sumSamplePreparation);
                    
                    //?????????????????????? ?????????????? ????????????????
                    worksheets.Cells[35, 7].Value = qiantity;
                    var priceDeterminationHeavyMetals = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.DeterminationHeavyMetals).PriceValue;
                    worksheets.Cells[35, 9].Value = priceDeterminationHeavyMetals;

                    var sumDeterminationHeavyMetals = qiantity * priceDeterminationHeavyMetals;
                    worksheets.Cells[35, 10].Value = sumDeterminationHeavyMetals;
                    fullSum.Add(sumDeterminationHeavyMetals);
                    
                    //?????????????????????? ????????????????????????????
                    worksheets.Cells[36, 7].Value = qiantity;
                    
                    var priceDefinitionPetroleumProducts = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.DefinitionPetroleumProducts).PriceValue;
                    worksheets.Cells[36, 9].Value = priceDefinitionPetroleumProducts;

                    var sumDefinitionPetroleumProducts = qiantity * priceDefinitionPetroleumProducts;
                    worksheets.Cells[36, 10].Value = sumDefinitionPetroleumProducts;
                    fullSum.Add(sumDefinitionPetroleumProducts);
                    
                    //?????????????????????? ?????????????????????? 
                    worksheets.Cells[37, 7].Value = qiantity;
                    
                    var priceDefinitionBenzopyrene = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.DefinitionBenzopyrene).PriceValue;
                    worksheets.Cells[37, 9].Value = priceDefinitionBenzopyrene;

                    var sumDefinitionBenzopyrene = priceDefinitionBenzopyrene * priceDefinitionBenzopyrene;
                    worksheets.Cells[37, 10].Value = sumDefinitionBenzopyrene;
                    fullSum.Add(sumDefinitionBenzopyrene);
                    
                    
                    //?????????? ???????????????????????? ????????????(??????????: ??????????????????????????????, ?????????????????????? ?????????????? ????????????????,
                    //?????????????????????? ???????????????????????????? ?? ?????????????????????? ??????????????????????)
                    var priceLaboratoryWork = sumSamplePreparation + sumDeterminationHeavyMetals +
                                              sumDefinitionPetroleumProducts + sumDefinitionBenzopyrene;
                    worksheets.Cells[38, 10].Value = priceLaboratoryWork;
                    fullSum.Add(priceLaboratoryWork);
                    
                    
                    //?????????????????????? ????????????
                    var priceDeskWork = priceLaboratoryWork * 0.20;
                    worksheets.Cells[39, 10].Value = priceDeskWork * 0.20;
                    fullSum.Add(priceDeskWork);
                    
                    //?????????????????????? ?? ???????????? ???????????????????????? ???????????? ?? ?????????????????????? ???????????????????? ????????????????????????
                    var pricePreparationIssuanceTechnicalReportWithApplicationResearchProtocols = priceDeskWork * 0.18;
                    worksheets.Cells[41, 10].Value = pricePreparationIssuanceTechnicalReportWithApplicationResearchProtocols;
                    fullSum.Add(pricePreparationIssuanceTechnicalReportWithApplicationResearchProtocols);
                    
                    //?????????????? ???????????????????????????? ????????????, ??????????(??????????: ?????????? ?????????????????????????? ???????? ????????????, ?????????? ???????????? ???? ?????????????? ???? ??????????-????????????????????????,
                    //?????????? ???????????? ???? ?????????????? ???? ??????????????????-???????????????????? ????????????????????????, y-???????????????????????? ?? ?????????????????? ?????????????????? ???????????? ???????????? ???? ????????????(?????????????? ????????????))
                    var priceFieldSurveyWork = sumSamplingSurfaceSoilSamples + sumSamplingSoilFromWellsGammaSpectrometry 
                                                                             + sumSoilSamplingFromWellsFsanitaryAndChemicalInspection + sumGammaSpectrometry + sumMeasurementRadonFluxDensityFromGroundFieldWork;
                    worksheets.Cells[43, 10].Value = priceFieldSurveyWork;
                    fullSum.Add(priceFieldSurveyWork);
                    
                    //?????????????? ???? ???????????????????? ??????????????????
                    var priceDomesticTransportCosts = priceFieldSurveyWork * 0.0875;
                    worksheets.Cells[44, 10].Value = priceDomesticTransportCosts;
                    fullSum.Add(priceDomesticTransportCosts);
                    
                    //?????????????? ???? ?????????????????????? ?? ???????????????????? ??????????
                    var priceExpensesOrganizationLiquidationWorks = priceDomesticTransportCosts * 0.06;
                    worksheets.Cells[45, 10].Value = priceExpensesOrganizationLiquidationWorks;
                    fullSum.Add(priceExpensesOrganizationLiquidationWorks);
                    
                    //??????????
                    var sum = fullSum.Sum();
                    worksheets.Cells[48, 10].Value = sum;
                    
                    //??????????
                    var total = settingEstimate.InflationRate * sum * (objectWork.Budget
                        ? settingEstimate.BudgetCoefficient
                        : 1);
                    worksheets.Cells[50, 10].Value = total;
                    
                    var textTotal = $"{Math.Round(sum, 2)} x {settingEstimate.InflationRate} = ";
                    var textNote =
                        $"{settingEstimate.InflationRate} - ?????????????????????? ????????????????, ?????????????????????????? ?? ???????????????????????? ?? ?????????????? ???????????????? ???????????? ??? 20289-????/02 ???? 05.11.2021 ??.;";
                    
                    //???????? ???????? ?????????????????????? ?????????????? ?? ??????????
                    if (objectWork.Budget)
                    {
                        textTotal = $"{textTotal.Replace("=", "")} x {settingEstimate.BudgetCoefficient}= ";
                        textNote = $"{textNote}0,59 - ???????????????????? ?????????????????????? ?????? ?????????????????? ??????????????????????";
                    }

                    //?????????????????? - ?????????????????????????? ???????????????????? ???????????????????????????????? ?? ???????????????????????? ???????????????????????? ?? ??????????????
                    //??????????????????????????(??????????????????) ???????????????????????? ?? ???????????????????????????? ????????????????????????????(????????????????)
                    var radiation = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.SanitaryEnvironmentalExpertiseRadiation).PriceValue;
                    worksheets.Cells[54, 9].Value = radiation;
                    worksheets.Cells[54, 10].Value = 0;
                    
                    //??????????????????-?????????????????????????? ???????????????????? ???????????????????????????????? ?? ???????????????????????? ???????????????????????? ?? ??????????????
                    //?????????????????????????? (??????????????????) ???????????????????????? ?? ???????????????????????????? ???????????????????????????? (?????????? ?? ??????????????????????????)
                    var chemistryAndBacteriology = prices
                        .FirstOrDefault(x => x.TypePrice == TypePrice.SanitaryEnvironmentalExpertiseChemistryAndBacteriology).PriceValue;
                    worksheets.Cells[55, 9].Value = chemistryAndBacteriology;
                    worksheets.Cells[55, 10].Value = 0;
                    
                    //??????????
                    var totalFull = total + radiation + chemistryAndBacteriology;
                    worksheets.Cells[57, 10].Value = totalFull;
                    
                    //TODO ?????????? ?????????? ???????????? ???????? ???? ????????
                    //????????????
                    var discount = totalFull * 0;
                    worksheets.Cells[58, 10].Value = discount;
                    
                    //?????????? ?? ???????????? ????????????
                    var totalDdiscount = totalFull - discount;
                    worksheets.Cells[59, 10].Value = totalFull - discount;
                    
                    // ??????
                    worksheets.Cells[60, 9].Value = $"{settingEstimate.Nds}%";
                    var nds = totalDdiscount * (settingEstimate.Nds/100);
                    worksheets.Cells[60, 10].Value = nds;
                    
                    //?????????? ??????????????????
                    worksheets.Cells[61, 10].Value = totalDdiscount + nds;
                    
                    worksheets.Cells[50, 11].Value = textNote;
                    worksheets.Cells[50, 7].Value = textTotal;

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